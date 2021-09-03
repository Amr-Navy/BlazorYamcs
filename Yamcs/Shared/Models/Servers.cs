using System.Collections.Generic;

namespace Yamcs.Shared.Models
{
    public class OpenIDConnectInfo
    {
        public string ClientId { set; get; }
        public string AuthorizationEndpoint { set; get; }
        public string Scope { set; get; }
    }

    public class TokenResponse
    {
        public string access_token { set; get; }
        public string token_type { set; get; }
        public int expires_in { set; get; }
        public string refresh_token { set; get; }
        public UserInfo user { set; get; }
    }

    public class GeneralInfo
    {
        public string YamcsVersion { set; get; }
        public string Revision { set; get; }
        public string ServerId { set; get; }
        public PluginInfo[] Plugins { set; get; }
        public CommandOption[] CommandOptions { set; get; }
    }

    public class ListRoutesResponse
    {
        public Route[] Routes { set; get; }
    }

    public class ListTopicsResponse
    {
        public Topic[] Topics { set; get; }
    }

    public class ListProcessorTypesResponse
    {
        public string[] Types { set; get; }
    }

    public class ListThreadsResponse
    {
        public ThreadInfo[] Threads { set; get; }
    }

    public class ThreadGroup
    {
        public string Name { set; get; }
        public ThreadGroup Parent { set; get; }
    }

    public class ThreadInfo
    {
        public int id { set; get; }
        public string name { set; get; }
        string state { set; get; }
        public bool native { set; get; }
        public bool suspended { set; get; }
        public ThreadGroup group { set; get; }
        public TraceElementInfo[] trace { set; get; }
    }

    public class TraceElementInfo
    {
        public string ClassName { set; get; }
        public string FileName { set; get; }
        public string MethodName { set; get; }
        public int LineNumber { set; get; }
    }

    public class ListServicesResponse
    {
        public serv[] Services { set; get; }
    }
    public class serv
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string ClassName { set; get; }
    }
    public class Route
    {
        public string Service { set; get; }
        public string Method { set; get; }
        public string Description { set; get; }
        public string InputType { set; get; }
        public string outputType { set; get; }
        public bool Deprecated { set; get; }
        public string Url { set; get; }
        public string HttpMethod { set; get; }
        public string ErrorCount { set; get; }
        public int RequestCount { set; get; }
    }

    public class Topic
    {
        public string Topics { set; get; }
        public string Service { set; get; }
        public string Method { set; get; }
        public string InputType { set; get; }
        public string OutputType { set; get; }
        public bool Deprecated { set; get; }
    }

    public class PluginInfo
    {
        public string Name { set; get; }
        public string description { set; get; }
        public string Version { set; get; }
        public string Vendor { set; get; }
    }

    public class CommandOption
    {
        public string Id { set; get; }
        public string VerboseName { set; get; }
        //type: 'BOOLEAN' | 'STRING' | 'NUMBER';
        public string Help { set; get; }
    }

    public class ServiceState
    {
        public const string NEW = "NEW";
        public const string STARTING = "STARTING";
        public const string RUNNING = "RUNNING";
        public const string STOPPING = "STOPPING";
        public const string TERMINATED = "TERMINATED";
        public const string FAILED = "FAILED";
    }

    public class InstanceState
    {
        public const string OFFLINE = "OFFLINE";
        public const string INITIALIZING = "INITIALIZING";
        public const string INITIALIZED = "INITIALIZED";
        public const string STARTING = "STARTING";
        public const string RUNNING = "RUNNING";
        public const string STOPPING = "STOPPING";
        public const string FAILED = "FAILED";
    }

    public class ListIntancesResponse
    {
        public Instance[] Instances { set; get; }
    }
    public class Instance
    {
        public string Name { set; get; }
        public MissionDatabase MissionDatabase { set; get; }
        public string State { set; get; }
        public Processor[] Processors { set; get; }
        public Dictionary<string, string> Labels { set; get; }
        public string MissionTime { set; get; }
        public string[] Capabilities { set; get; }
        public string Template { set; get; }
        // templateArgs?: { [key: string]: string; };
        public bool TemplateAvailable { set; get; }
        public bool TemplateChanged { set; get; }
    }

    public class InstanceTemplate
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public TemplateVariable[] Variables { set; get; }
    }

    public class TemplateVariable
    {
        public string Name { set; get; }
        public string Label { set; get; }
        public string Help { set; get; }
        public bool Required { set; get; }
        public string Type { set; get; }
        public string Initial { set; get; }
        public string[] Choices { set; get; }
    }

    public class ConnectionInfo
    {
        public Instance Instance { set; get; }
        public Processor Processor { set; get; }
    }
    public class ListClientConnectionInfo
    {
        public ClientConnectionInfo[] Connections { set; get; }
    }
    public class ClientConnectionInfo
    {
        public string Id { set; get; }
        public bool Open { set; get; }
        public bool Active { set; get; }
        public bool Writable { set; get; }
        public string RemoteAddress { set; get; }
        public string LocalAddress { set; get; }
        public int ReadBytes { set; get; }
        public int WrittenBytes { set; get; }
        public int ReadThroughput { set; get; }
        public int writeThroughput { set; get; }
        public HttpRequestInfo HttpRequest { set; get; }
    }

    public class ResultSet<T>
    {
        public T columns { set; get; }
        public T rows { set; get; }
    }

    public class HttpRequestInfo
    {
        public string Protocol { set; get; }
        public string Method { set; get; }
        public string Uri { set; get; }
        public bool KeepAlive { set; get; }
        public string UserAgent { set; get; }
    }

    public class EditClearanceRequest
    {
        public string Level { set; get; }
    }
}

