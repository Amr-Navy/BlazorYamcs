using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class SubscribeTMStatisticsRequest
    {
        public SubscribeTMStatisticsRequest(string Instance, string Processor)
        {
            instance = Instance;
            processor = Processor;
        }

        public string instance { set; get; }
        public string processor { set; get; }
    }
    public class StatisticsResponse 
    {

        public string instance { set; get; }
        public string processor { set; get; }
        public TmStatistics[] tmstats { set; get; }
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime lastUpdated { set; get; }
    }
    public class TmStatistics
    {

        public string packetName { get; set; }

        public string qulificationName { set; get; }
        public string receivedPackets { set; get; }
        public int subscribedParameterCount { set; get; }
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime lastReceived { get; set; }
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime lastPacketTime { set; get; }
        public string packetRate { set; get; }
        public string dataRate { set; get; }
    }
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private static readonly string _format = "yyyy-MM-dd'T'HH:mm:ss.fff'Z'";  //formato api?
        //private static readonly string _format = "yyyy-MM-dd'T'HH:mm:ss.fff";


        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            DateTime d = DateTime.ParseExact(reader.GetString(), _format, System.Globalization.CultureInfo.InvariantCulture);
            //Console.WriteLine(d.ToLongTimeString());
            return d;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToUniversalTime().ToString(_format));
    }

    public class SubscribeParametersRequest
    {
        public string instance { set; get; }
        public string processor { set; get; }
        public int[] id { set; get; }
        public bool abortOnInvalid { set; get; }
        public bool updateOnExpiration { set; get; }
        public bool sendFromCache { set; get; }
        public bool action { set; get; }
    }
    public enum action { REPLACE, ADD, REMOVE }
    public class SubscribeParametersData
    {
        //  mapping: { [key: number]: NamedObjectId; };
        public NamedObjectId[] invalid { set; get; }
        ParameterValue[] values { set; get; }
    }

    public class SubscribeProcessorsRequest
    {
        public string instance { set; get; }
        public string processor { set; get; }
    }

    public class ListProcessorResponse
    {
        public Processor[] processors { set; get; }
    }
    public class Processor
    {
        public string instance { set; get; }
        public string name { set; get; }
        public string type { set; get; }
        public string creator { set; get; }
        public bool hasAlarms { set; get; }
        public bool hasCommanding { set; get; }
        public bool checkCommandClearance { set; get; }
        public string state { set; get; }
        public bool persistent { set; get; }
        public string time { set; get; }
        public bool replay { set; get; }
        //public ReplayRequest replayRequest { set; get; }
        // public Service[]  services { set; get; }
    }

    public class ReplayRequest
    {
        public string start { set; get; }
        public string stop { set; get; }
        public ReplaySpeed speed { set; get; }
    }

    public class ReplaySpeed
    {
        //   type: 'AFAP' | 'FIXED_DELAY' | 'REALTIME';
        public int param { set; get; }
    }




}
