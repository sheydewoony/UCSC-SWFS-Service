using MQTTnet.Client;
using MQTTnet.Protocol;
using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSC.SWFS.SRV.Service.Common.MQTT
{
    public class MQTTBrockerService : IMQTTBrockerService
    {
        public async Task PublishMessageToMqttBroker(string topic, string payload)
        {
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("test.mosquitto.org", 1883)
                .WithClientId(Guid.NewGuid().ToString())
                .WithCleanSession()
                // Replace with your MQTT broker address and port
                .Build();

            await mqttClient.ConnectAsync(options);

            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                .Build();

            await mqttClient.PublishAsync(message);
            await mqttClient.DisconnectAsync();
        }
    }
}
