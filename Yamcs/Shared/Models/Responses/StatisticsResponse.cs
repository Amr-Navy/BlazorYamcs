using System;
using System.Reactive.Subjects;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Yamcs.Shared.Models
{
    public class StatisticsResponse
    {

        public string Instance { set; get; }
        public string Processor { set; get; }
        public TmStatistics[] Tmstats { set; get; }
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastUpdated { set; get; }

        public static void Handle(string msg, Subject<WebSocketResponse<StatisticsResponse>> subject)
        {

            var rep = YamcsSerialization.Deserialize<WebSocketResponse<StatisticsResponse>>(msg);
            Console.WriteLine(rep.Type);
            subject.OnNext(rep);

        }
    }

    public class TmStatistics
    {

        public string PacketName { get; set; }

        public string QulificationName { set; get; }
        public string ReceivedPackets { set; get; }
        public int SubscribedParameterCount { set; get; }
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastReceived { get; set; }
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastPacketTime { set; get; }
        public string PacketRate { set; get; }
        public string DataRate { set; get; }



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


}
