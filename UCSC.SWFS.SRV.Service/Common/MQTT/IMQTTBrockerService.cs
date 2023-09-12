using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSC.SWFS.SRV.Service.Common.MQTT
{
    public interface IMQTTBrockerService
    {
        Task PublishMessageToMqttBroker(string topic, string payload);
    }
}
