using Serilog;
using Serilog.Events;
using System;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;
using YamcsWebsocket.Client;
using YamcsWebsocket.Client.Websocket.Websockets;
using YamcsWebsocket.Logging;
using YamcsWebsocket.Requests;
using YamcsWebsocket.Resonses;

namespace Bitfinex.Client.Websocket.Sample
{
    class Program
    {
        private static readonly ManualResetEvent ExitEvent = new ManualResetEvent(false);
        public static readonly Uri ApiWebsocketUrl = new Uri("ws://localhost:8090/api/websocket");
        // private static readonly string API_KEY = "your_api_key";
        // private static readonly string API_SECRET = "";

        static void Main(string[] args)
        {
            InitLogging();

            AppDomain.CurrentDomain.ProcessExit += CurrentDomainOnProcessExit;
            AssemblyLoadContext.Default.Unloading += DefaultOnUnloading;
            Console.CancelKeyPress += ConsoleOnCancelKeyPress;

            Console.WriteLine("|=======================|");
            Console.WriteLine("|   Yamcs CLIENT    |");
            Console.WriteLine("|=======================|");
            Console.WriteLine();

            Log.Debug("====================================");
            Log.Debug("              STARTING              ");
            Log.Debug("====================================");



            using (var communicator = new YamcsWebsocketCommunicator(ApiWebsocketUrl))
            {
                communicator.Name = "Yamcs";
                // communicator.ReconnectTimeout = TimeSpan.FromSeconds(30);
                communicator.ReconnectionHappened.Subscribe(info =>
                    Log.Information($"Reconnection happened, type: {info.Type}"));

                using (var client = new YamcsWebsocketClient(communicator))
                {
                    client.Streams.ReplyStream.Subscribe(reply =>
                    {
                        Log.Information($"Info received version: {reply.replyTo}");
                        //SendSubscriptionRequests(client).Wait();
                    });
                    SendSubscriptionRequests(client);
                    SubscribeToStreams(client);

                    communicator.Start();

                    ExitEvent.WaitOne();
                }
            }

            Log.Debug("====================================");
            Log.Debug("              STOPPING              ");
            Log.Debug("====================================");
            Log.CloseAndFlush();
        }

        private static async Task SendSubscriptionRequests(YamcsWebsocketClient client)
        {
            //client.Send(new ConfigurationRequest(ConfigurationFlag.Timestamp | ConfigurationFlag.Sequencing));
            SubscribeTMStatisticsRequest Opt = new SubscribeTMStatisticsRequest("simulator", "realtime");
            client.Send(Opt);
        }

        private static void SubscribeToStreams(YamcsWebsocketClient client)
        {
            // public streams:

            //client.Streams.ReplyStream.Subscribe(x =>
            //Log.Information($"Configuration happened {x.Status}, flags: {x.Flags}, server timestamp enabled: {client.Configuration.IsTimestampEnabled}"));

            client.Streams.TmstatsStream.Subscribe(st => Log.Information($"Pong received! Id: {st.instance}"));
        }




        private static void InitLogging()
        {
            var executingDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var logPath = Path.Combine(executingDir, "logs", "verbose.log");
            Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        private static void CurrentDomainOnProcessExit(object sender, EventArgs eventArgs)
        {
            Log.Warning("Exiting process");
            ExitEvent.Set();
        }

        private static void DefaultOnUnloading(AssemblyLoadContext assemblyLoadContext)
        {
            Log.Warning("Unloading process");
            ExitEvent.Set();
        }

        private static void ConsoleOnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Log.Warning("Canceling process");
            e.Cancel = true;
            ExitEvent.Set();
        }
    }
}
