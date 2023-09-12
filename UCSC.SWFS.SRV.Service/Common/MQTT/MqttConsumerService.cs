using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MQTTnet;
using MQTTnet.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Dto;
using UCSC.SWFS.SRV.Service.Implementation;
using UCSC.SWFS.SRV.Service.Interfaces;

namespace UCSC.SWFS.SRV.Service.Common.MQTT
{
    public class MqttConsumerService : BackgroundService
    {
        private readonly IMqttClient _mqttClient;
        private readonly IServiceProvider _serviceProvider;
        public MqttConsumerService(IServiceProvider serviceProvider)
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("test.mosquitto.org", 1883)
                .Build();

           _mqttClient.ApplicationMessageReceivedAsync +=  HandleReceivedApplicationMessage;

            await _mqttClient.ConnectAsync(options, stoppingToken);

            var subscribeOptions = new MqttClientSubscribeOptionsBuilder()
                .WithTopicFilter("SWFS-sensor-data")
                .Build();

            await _mqttClient.SubscribeAsync(subscribeOptions, stoppingToken);
        }

        private async Task HandleReceivedApplicationMessage(MqttApplicationMessageReceivedEventArgs e)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var sensorDataService = scope.ServiceProvider.GetRequiredService<ISensorDataService>();
                    var message = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    if (!String.IsNullOrEmpty(message))
                    {
                        SensorValueDto deserializedMessage = JsonConvert.DeserializeObject<SensorValueDto>(message);
                        if (deserializedMessage != null)
                        {
                            await sensorDataService.SaveSensorData(deserializedMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }

}
