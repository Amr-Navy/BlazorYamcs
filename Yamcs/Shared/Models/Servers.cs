using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class OpenIDConnectInfo
    {
        public string clientId { set; get; }
        public string authorizationEndpoint { set; get; }
        public string scope { set; get; }
    }

    public class TokenResponse
    {
        public string access_token { set; get; }
        public string token_type { set; get; }
        public int expires_in { set; get; }
        public string refresh_token { set; get; }
        UserInfo user { set; get; }
    }

    public class GeneralInfo
    {
        public string yamcsVersion { set; get; }
        public string revision { set; get; }
        public string serverId { set; get; }
        PluginInfo[] plugins { set; get; }
        CommandOption[] commandOptions { set; get; }
    }

    public class ListRoutesResponse
    {
        Route[] routes { set; get; }
    }

    public class ListTopicsResponse
    {
        Topic[] topics { set; get; }
    }

    public class ListProcessorTypesResponse
    {
        string[] types { set; get; }
    }

    public class ListThreadsResponse
    {
        ThreadInfo[] threads { set; get; }
    }

    public class ThreadGroup
    {
        public string name { set; get; }
        public ThreadGroup parent { set; get; }
    }

    public class ThreadInfo
    {
        public int id { set; get; }
        public string name { set; get; }
        string state { set; get; }
        public bool native { set; get; }
        public bool suspended { set; get; }
        public ThreadGroup group { set; get; }
        TraceElementInfo[] trace { set; get; }
    }

    public class TraceElementInfo
    {
        public string className { set; get; }
        public string fileName { set; get; }
        public string methodName { set; get; }
        public int lineNumber { set; get; }
    }

 
    public class Route
    {
        public string service { set; get; }
        public string method { set; get; }
        public string description { set; get; }
        public string inputType { set; get; }
        public string outputType { set; get; }
        public bool deprecated { set; get; }
        public string url { set; get; }
        public string httpMethod { set; get; }
        public int requestCount { set; get; }
    }

    public class Topic
    {
        public string topic { set; get; }
        public string service { set; get; }
        public string method { set; get; }
        public string inputType { set; get; }
        public string outputType { set; get; }
        public bool deprecated { set; get; }
    }

    public class PluginInfo
    {
        public string name { set; get; }
        public string description { set; get; }
        public string version { set; get; }
        public string vendor { set; get; }
    }

    public class CommandOption
    {
        public string id { set; get; }
        public string verboseName { set; get; }
        //type: 'BOOLEAN' | 'STRING' | 'NUMBER';
        public string help { set; get; }
    }

    public class ServiceState
    {
        public const string NEW = "NEW";
        public const string STARTING = "STARTING";
        public const string RUNNING = "RUNNING";
        public const string STOPPING = "STOPPING";
        public const string TERMINATED = "TERMINATED";
        public const  string FAILED = "FAILED";
    }

    public class InstanceState
    {
    public const string OFFLINE= "OFFLINE";
    public const string INITIALIZING = "INITIALIZING";
    public const string INITIALIZED = "INITIALIZED";
    public const string STARTING = "STARTING";
    public const string RUNNING = "RUNNING";
    public const string STOPPING = "STOPPING";
    public const string FAILED = "FAILED";
}

    public class ListIntancesResponse
    {
        public Instance[] instances { set; get; }
    }
    public class Instance
    {
        public string name { set; get; }
        public MissionDatabase missionDatabase { set; get; }
        public string state { set; get; }
        public Processor[] processors { set; get; }
        public Dictionary<string,string> labels { set; get; }
        public string missionTime { set; get; }
        public string[] capabilities { set; get; }
        public string template { set; get; }
        // templateArgs?: { [key: string]: string; };
        public bool templateAvailable { set; get; }
        public bool templateChanged { set; get; }
    }

    public class InstanceTemplate
    {
        public string name { set; get; }
        public string description { set; get; }
        public TemplateVariable[] variables { set; get; }
    }

    public class TemplateVariable
    {
        public string name { set; get; }
        public string label { set; get; }
        public string help { set; get; }
        public bool required { set; get; }
        public string type { set; get; }
        public string initial { set; get; }
        public string[] choices { set; get; }
    }

    public class ConnectionInfo
    {
        public Instance instance { set; get; }
        public Processor processor { set; get; }
    }

    public class ClientConnectionInfo
    {
        public string id { set; get; }
        public bool open { set; get; }
        public bool active { set; get; }
        public bool writable { set; get; }
        public string remoteAddress { set; get; }
        public string localAddress { set; get; }
        public int readBytes { set; get; }
        public int writtenBytes { set; get; }
        public int readThroughput { set; get; }
        public int writeThroughput { set; get; }
        HttpRequestInfo httpRequest { set; get; }
    }

    public class ResultSet<T>
    {
        public T columns { set; get; }
        public T rows { set; get; }
    }

    public class HttpRequestInfo
    {
        public string protocol { set; get; }
        public string method { set; get; }
        public string uri { set; get; }
        public string keepAlive { set; get; }
        public string userAgent { set; get; }
    }

    public class EditClearanceRequest
    {
        public string level { set; get; }
    }
}

