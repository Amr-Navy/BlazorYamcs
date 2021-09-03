using System;
using System.Linq;
using System.Threading.Tasks;
using YamcsWebsocket.Communicator;
using YamcsWebsocket.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Websocket.Client;
using YamcsWebsocket.Json;
using YamcsWebsocket.Validations;

namespace YamcsWebsocket.Client
{
    /// <summary>
    /// Bitfinex websocket client, it wraps `IBitfinexCommunicator` and parse raw data into streams.
    /// Send subscription requests (for example: `new TradesSubscribeRequest(pair)`) and subscribe to `Streams`
    /// </summary>
    public class YamcsWebsocketClient : IDisposable
    {
      //  private static readonly ILog Log = LogProvider.GetCurrentClassLogger(); 

        private readonly IYamcsWebsocketCommunicator _communicator;
        private readonly IDisposable _messageReceivedSubscription;
        private readonly IDisposable _configurationSubscription;

       // private readonly BitfinexChannelList _channelIdToHandler = new BitfinexChannelList();

       // private readonly BitfinexAuthenticatedHandler _authenticatedHandler;
        private readonly YamcsWebsocketPublicHandler _publicHandler;

        /// <inheritdoc />
        public YamcsWebsocketClient(IYamcsWebsocketCommunicator communicator)
        {
            YamcsWebsocketValidations.ValidateInput(communicator, nameof(communicator));

            _communicator = communicator;
            _messageReceivedSubscription = _communicator.MessageReceived.Subscribe(HandleMessage);
           // _configurationSubscription = Streams.ConfigurationSubject.Subscribe(HandleConfiguration);

           // _authenticatedHandler = new BitfinexAuthenticatedHandler(Streams, _channelIdToHandler);
            _publicHandler = new YamcsWebsocketPublicHandler(Streams);
        }

        /// <summary>
        /// Provided message streams
        /// </summary>
        public YamcsWebsocketClientStreams Streams { get; } = new YamcsWebsocketClientStreams();

        /// <summary>
        /// Currently enabled features
        /// </summary>
       // public ConfigurationState Configuration { get; private set; } = new ConfigurationState();

        /// <summary>
        /// Cleanup everything
        /// </summary>
        public void Dispose()
        {
            _messageReceivedSubscription?.Dispose();
            _configurationSubscription?.Dispose();
        }

        /// <summary>
        /// Serializes request and sends message via websocket communicator. 
        /// It logs and re-throws every exception. 
        /// </summary>
        /// <param name="request">Request/message to be sent</param>
        public void Send<T>(T request)
        {
            try
            {
               // YamcsWebsocketValidations.ValidateInput(request, nameof(request));

                var serialized = JsonConvert.SerializeObject(request);
                _communicator.Send(serialized);
            }
            catch (Exception e)
            {
               // Log.Error(e, L($"Exception while sending message '{request}'. Error: {e.Message}"));
                throw;
            }
        }

     

    

        private void HandleMessage(ResponseMessage message)
        {
            try
            {
                var formatted = (message.Text ?? string.Empty).Trim();

                if (formatted.StartsWith("{"))
                {
                    _publicHandler.OnObjectMessage(formatted);
                    return;
                }

            }
            catch (Exception e)
            {
               // Log.Error(e, L("Exception while receiving message"));
            }
        }

        
    }
}
