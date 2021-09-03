using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YamcsWebsocket.Client;

namespace YamcsWebsocket.Responses
{
   public class TmStatisticsResponse
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

        internal static void Handle(string msg, Subject<TmStatisticsResponse> subject)
        {
            var stats = YamcsWebsocketSerialization.Deserialize<TmStatisticsResponse>(msg);
            subject.OnNext(stats);
        }
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

