using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Yamcs.Shared;
using Yamcs.Shared.Models;

namespace Yamcs.Client.Services
{
    public class YamcsClient
    {
        HttpClient http;
        public WebSocketClient webclient;
        public YamcsClient(HttpClient _http, WebSocketClient _webSocketClient)
        {
            http = _http;
            webclient = _webSocketClient;


        }
        #region Get
        public async Task<SystemInfoResponse> GetSystemInfoAsync()
        {
            return await http.GetFromJsonAsync<SystemInfoResponse>("/api/sysinfo");
        }
        public async Task<GeneralInfo> getGeneralInfo()
        {
            return await http.GetFromJsonAsync<GeneralInfo>("/api");
        }
        public async Task<UserInfo> getUserInfo()
        {
            return await http.GetFromJsonAsync<UserInfo>("/api/user");
        }
        public async Task<ListRoutesResponse> getRoutes()
        {
            return await http.GetFromJsonAsync<ListRoutesResponse>("/api/routes");
        }
        public async Task<ListTopicsResponse> getTopics()
        {
            return await http.GetFromJsonAsync<ListTopicsResponse>("/api/topics");
        }
        public async Task<ListProcessorTypesResponse> getProcessorTypes()
        {
            return await http.GetFromJsonAsync<ListProcessorTypesResponse>("/api/processor-types");
        }
        public async Task<ListThreadsResponse> getThreads()
        {
            return await http.GetFromJsonAsync<ListThreadsResponse>("/api/threads");
        }
        public async Task<ThreadInfo> getThread(int id)
        {
            return await http.GetFromJsonAsync<ThreadInfo>($"/api/{id}");
        }
        public async Task<ReplicationInfo> getReplicationInfo()
        {
            return await http.GetFromJsonAsync<ReplicationInfo>("/api/replication");
        }
        public async Task<ListClearancesResponse> getClearances()
        {
            return await http.GetFromJsonAsync<ListClearancesResponse>("/api/clearances");
        }
        public async Task<LeapSecondsTableResponse> getLeapSeconds()
        {
            return await http.GetFromJsonAsync<LeapSecondsTableResponse>("/api/leap-seconds");
        }
        public async Task<ListIntancesResponse> getInstances()
        {

            return await http.GetFromJsonAsync<ListIntancesResponse>("/api/instances");
        }
        public async Task<Instance> getInstance(string name)
        {
            return await http.GetFromJsonAsync<Instance>($"/api/instances/{name}");
        }
        //public async Task<> getInstanceTemplates(string name)
        //{
        //    return await http.GetFromJsonAsync<>($"/api/instance-templates/{name}");
        //}
        public async Task<InstanceTemplate> getInstanceTemplate()
        {
            return await http.GetFromJsonAsync<InstanceTemplate>("/api/sysinfo");
        }
        public async Task<ListDatabasesResponse> getDatabases()
        {
            return await http.GetFromJsonAsync<ListDatabasesResponse>("/api/databases");
        }
        public async Task<DatabaseInfo> getDatabase(string name)
        {
            return await http.GetFromJsonAsync<DatabaseInfo>($"/api/databases/{name}");
        }
        public async Task<ListServicesResponse> getService(string instance)
        {
            return await http.GetFromJsonAsync<ListServicesResponse>($"/api/services/{instance}");
        }
        public async Task<ListServiceAccountsResponse> getServiceAccounts()
        {
            return await http.GetFromJsonAsync<ListServiceAccountsResponse>("/api/service-accounts");
        }
        public async Task<ServiceAccountInfo> getServiceAccount(string name)
        {
            return await http.GetFromJsonAsync<ServiceAccountInfo>($"/api/service-accounts/{name}");
        }
        public async Task<UserInfo> getUser(string name)
        {
            return await http.GetFromJsonAsync<UserInfo>($"/api/users/{name}");
        }
        public async Task<ListUsersResponse> getUsers()
        {
            return await http.GetFromJsonAsync<ListUsersResponse>("/api/users");
        }
        public async Task<GroupInfo> getGroup(string name)
        {
            return await http.GetFromJsonAsync<GroupInfo>($"/api/groups/{name}");
        }
        public async Task<ListGroupsRespons> getGroups()
        {
            return await http.GetFromJsonAsync<ListGroupsRespons>("/api/groups");
        }
        public async Task<ListRolesResponse> getRoles()
        {
            return await http.GetFromJsonAsync<ListRolesResponse>("/api/roles");
        }
        public async Task<RoleInfo> getRole(string name)
        {
            return await http.GetFromJsonAsync<RoleInfo>($"/api/roles/{name}");
        }
        public async Task<ListClientConnectionInfo> getClientConnections()
        {


            return await http.GetFromJsonAsync<ListClientConnectionInfo>("/api/connections");


        }
        public async Task<ListRocksdbResponse> getRocksDbDatabaseProperties()
        {
            return await http.GetFromJsonAsync<ListRocksdbResponse>("/api/archive/rocksdb/databases");
        }
        public async Task<ListPacketsResponse> getPackets(string instance)
        {
            return await http.GetFromJsonAsync<ListPacketsResponse>($"/api/archive/{instance}/packets");
        }
        public async Task<ListEventsResponse> getEvents(string instance)
        {
            return await http.GetFromJsonAsync<ListEventsResponse>($"/api/archive/{instance}/events/sources");
        }
        public async Task<MissionDatabase> getMissionDatabase(string instance)
        {
            return await http.GetFromJsonAsync<MissionDatabase>($"/api/mdb/{instance}");
        }
        public async Task<ListLinksResponse> getLinks(string instance)
        {
            return await http.GetFromJsonAsync<ListLinksResponse>($"/api/links/{instance}");
        }
        public async Task<Link> getLink(string instance, string link)
        {
            return await http.GetFromJsonAsync<Link>($"/api/links/{instance}/{link}");
        }
        public async Task<ListProcessorResponse> getProcessors(string instance)
        {
            return await http.GetFromJsonAsync<ListProcessorResponse>($"/api/processors/{instance}");
        }
        public async Task<Processor> getProcessor(string instance, string name)
        {
            return await http.GetFromJsonAsync<Processor>($"/api/processors/{instance}/{name}");
        }
        public async Task<ListCommandQueuesRespnse> getCommandQueues(string instance, string processorName, string queueName)
        {
            return await http.GetFromJsonAsync<ListCommandQueuesRespnse>($"/api/processors/{instance}/{processorName}/queues/");
        }
        public async Task<CommandQueue> getCommandQueue(string instance, string processorName, string queueName)
        {
            return await http.GetFromJsonAsync<CommandQueue>($"/api/processors/{instance}/{processorName}/queues/{queueName}");
        }
        //public async Task<> getActiveAlarms(string instance, string processorName)
        //{
        //    return await http.GetFromJsonAsync<>($"/api/processors/${instance}/${processorName}/alarms");
        //}
        public async Task<ListAlarmsResponse> getAlarms(string instance)
        {
            return await http.GetFromJsonAsync<ListAlarmsResponse>($"/api/archive/{instance}/alarms");
        }
        public async Task<ParameterAlarmData> getAlarmsForParameter(string instance, string qualifiedName)
        {
            return await http.GetFromJsonAsync<ParameterAlarmData>($"/api/archive/{instance}/alarms{qualifiedName}");
        }
        public async Task<StreamData> getStreams(string instance)
        {
            return await http.GetFromJsonAsync<StreamData>($"/api/archive/{instance}/streams");
        }
        public async Task<ListTableRespnse> getTables(string instance)
        {
            return await http.GetFromJsonAsync<ListTableRespnse>($"/api/archive/{instance}/tables");
        }
        public async Task<Table> getTable(string instance, string name)
        {
            return await http.GetFromJsonAsync<Table>($"/api/archive/{instance}/tables/{name}");
        }
        //public async Task<> getTableData(string instance,string name)
        //{
        //    return await http.GetFromJsonAsync<>($"/api/archive/${instance}/tables/${name}/data");
        //}
        public async Task<PacketNameResponse> getPacketNames(string instance)
        {
            return await http.GetFromJsonAsync<PacketNameResponse>($"/api//archive/{instance}/packet-names");
        }
        //public async Task<> getPacketIndex(string instance)
        //{
        //    return await http.GetFromJsonAsync<>($"/api/archive/${instance}/packet-index");
        //}
        //public async Task<> getParameterIndex(string instance)
        //{
        //    return await http.GetFromJsonAsync<>($"/api/archive/${instance}/parameter-index");
        //}
        //public async Task<> getCommandIndex(string instance)
        //{
        //    return await http.GetFromJsonAsync<>($"/api/archive/${instance}/command-index");
        //}
        //public async Task<> getEventIndex(string instance)
        //{
        //    return await http.GetFromJsonAsync<>($"/api/archive/${instance}/event-index");
        //}
        public async Task<SpaceSystemsPage> getRootSpaceSystems(string instance)
        {
            return await http.GetFromJsonAsync<SpaceSystemsPage>($"/api/mdb/{instance}");
        }
        public async Task<SpaceSystem> getSpaceSystem(string instance, string qualifiedname)
        {
            return await http.GetFromJsonAsync<SpaceSystem>($"/api/mdb/{instance}/space-systems{qualifiedname}");
        }
        public async Task<ParametersPage> getParameters(string instance, int pagee, int quantityperpage)
        {
            return await http.GetFromJsonAsync<ParametersPage>($"/api/mdb/{instance}/parameters?pos={pagee}&limit={quantityperpage}");
        }
        public async Task<Parameter> getParameter(string instance, string qualifiedName)
        {
            return await http.GetFromJsonAsync<Parameter>($"/api/mdb/{instance}/parameters{qualifiedName}");
        }
        public async Task<Parameter> getParameterById(string instance, NamedObjectId id)
        {
            return await http.GetFromJsonAsync<Parameter>($"/api/mdb/{instance}/parameters");
        }
        public async Task<Parameter> getParameterValues(string instance, string QualifiedName)
        {
            return await http.GetFromJsonAsync<Parameter>($"/api/archive/{instance}/parameters{QualifiedName}");
        }
        //public async Task<> getParameterSamples(string instance, string qualifiedName)
        //{
        //    return await http.GetFromJsonAsync<>($"/api/archive/${instance}/parameters${qualifiedName}/samples");
        //}
        //public async Task<param> getParameterRanges(string instance, string QualifiedName)
        //{
        //    return await http.GetFromJsonAsync<>($"/api/archive/${instance}/parameters${QualifiedName}/ranges");
        //}
        public async Task<CommandsPage> getCommands(string instance, int pagee, int quantityperpage)
        {
            return await http.GetFromJsonAsync<CommandsPage>($"/api/mdb/{instance}/commands?pos={pagee}&limit={quantityperpage}");
        }
        public async Task<Command> getCommand(string instance, string qualifiedName)
        {
            return await http.GetFromJsonAsync<Command>($"/api/mdb/{instance}/commands{qualifiedName}");
        }
        public async Task<ContainersPage> getContainers(string instance, int pagee, int quantityperpage)
        {
            return await http.GetFromJsonAsync<ContainersPage>($"/api/mdb/{instance}/containers?pos={pagee}&limit={quantityperpage}");
        }
        public async Task<Container> getContainer(string instance, string qualifiedName)
        {
            return await http.GetFromJsonAsync<Container>($"/api/mdb/{instance}/containers{qualifiedName}");
        }
        public async Task<ListTagsResponsecs> getTags(string instance)
        {
            return await http.GetFromJsonAsync<ListTagsResponsecs>($"/api/archive/{instance}/tags");
        }
        public async Task<AlgorithmsPage> getAlgorithms(string instance)
        {
            return await http.GetFromJsonAsync<AlgorithmsPage>($"/api/mdb/{instance}/algorithms");
        }
        public async Task<Algorithm> getAlgorithm(string instance, string qualifiedName)
        {
            return await http.GetFromJsonAsync<Algorithm>($"/api/mdb/{instance}/algorithms{qualifiedName}");
        }
        public async Task<ServicesPage> getFileTransferServices(string instance)
        {
            return await http.GetFromJsonAsync<ServicesPage>($"/api/filetransfer/{instance}/services");
        }
        public async Task<TransfersPage> getFileTransfers(string instance, string service)
        {
            return await http.GetFromJsonAsync<TransfersPage>($"/api/filetransfer/{instance}/{service}/transfers");
        }

        //public async Task<ListGapsResponse> getGaps(string instance)
        //{
        //    return await http.GetFromJsonAsync<ListGapsResponse>($"/api/dass/gaps/${instance}");
        //}

        #endregion create 

        #region Post
        public async Task<HttpResponseMessage> createProcessor(Processor p)
        {
            return await http.PostAsJsonAsync($"/api/processors", p);
        }
        public async Task<HttpResponseMessage> stopInstance(string name)
        {
            return await http.PostAsync($"/api/instances/{name}:stop", null);
        }
        public async Task<HttpResponseMessage> startInstance(string name)
        {
            return await http.PostAsync($"/api/instances/{name}:start", null);
        }
        public async Task<HttpResponseMessage> restartInstance(string name)
        {
            return await http.PostAsync($"/api/instances/{name}:restart", null);
        }
        public async Task<HttpResponseMessage> startService(string instance, string name)
        {
            return await http.PostAsync($"/api/services/{instance}/{name}:start", null);
        }
        public async Task<HttpResponseMessage> stopService(string instance, string name)
        {
            return await http.PostAsync($"/api/services/{instance}/{name}:stop", null);
        }
        public async Task<HttpResponseMessage> createServiceAccount(CreateServiceAccountRequest account)
        {
            return await http.PostAsJsonAsync($"/api/service-accounts", account);
        }
        public async Task<HttpResponseMessage> createUser(CreateUserRequest user)
        {
            return await http.PostAsJsonAsync($"/api/users/", user);
        }
        public async Task<HttpResponseMessage> createGroup(CreateGroupRequest group)
        {
            return await http.PostAsJsonAsync($"/api/groups", group);
        }
        //public async Task createInstance(CreateInstanceRequest options)
        //{
        //    await http.PostAsJsonAsync($"/api/instances",options);
        //}
        public async Task<HttpResponseMessage> createEvent(string instance, CreateEventRequest options)
        {
            return await http.PostAsJsonAsync($"/api/archive/{instance}/events", options);
        }
        public async Task<HttpResponseMessage> issueCommand(string instance, string processorName, string qualifiedName)
        {
            return await http.PostAsync($"/api/processors/{instance}/{processorName}/commands{qualifiedName}", null);
        }


        #endregion
        #region Patch
        public async Task<HttpResponseMessage> changeClearance(string username, EditClearanceRequest options)
        {
            var content = new StringContent(JsonConvert.SerializeObject(options), Encoding.UTF8, "application/json");
            return await http.PatchAsync($"/api/clearances/{username}", content);

        }
        public async Task<HttpResponseMessage> editUser(string username, EditUserRequest options)
        {
            var content = new StringContent(JsonConvert.SerializeObject(options), Encoding.UTF8, "application/json");
            return await http.PatchAsync($"/api/users/{username}", content);

        }
        //public async Task editGroup(string username, EditGroupRequest options)
        //{
        //    await http.PutAsJsonAsync($"/api/groups/{username}", options);
        //}
        public async Task<HttpResponseMessage> editLink(string instance, string name, EditLinkOptions options)
        {
            return await http.PutAsJsonAsync($"/api/links/{instance}/{name}", options);
        }
        public async Task<HttpResponseMessage> enableLink(string instance, string name)
        {
            EditLinkOptions op = new EditLinkOptions(Linkstate.enabled, true);
            return await editLink(instance, name, op);
        }
        public async Task disableLink(string instance, string name)
        {
            EditLinkOptions op = new EditLinkOptions(Linkstate.disabled, false);
            await editLink(instance, name, op);
        }

        public async Task<HttpResponseMessage> editCommandQueue(string instance, string processorName, string queueName, EditCommandQueueOptions option)
        {
            return await http.PutAsJsonAsync($"/api/processors/{instance}/{processorName}/queues/{queueName}", option);
        }
        public async Task<HttpResponseMessage> editCommandQueueEntry(string instance, string processorName, string queueName, string uuid, EditCommandQueueEntryOptions option)
        {
            return await http.PutAsJsonAsync($"/api/processors/{instance}/{processorName}/queues/{queueName}/entries/{uuid}", option);
        }
        //public async Task editAlarm(string instance, string processor, string alarm, string sequenceNumber, EditAlarmOptions opt)
        //{
        //    await http.PutAsJsonAsync($"/api/processors/{instance}/{processor}/alarms{alarm}/{sequenceNumber}",opt);
        //}
        public async Task<HttpResponseMessage> setParameterValue(string instance, string processorName, string qualifiedName, Value val)
        {
            return await http.PutAsJsonAsync($"/api/processors/{instance}/{processorName}/parameters{qualifiedName}", val);
        }
        #endregion

        #region Delete
        public async Task<HttpResponseMessage> deleteClearance(string username)
        {
            return await http.DeleteAsync($"/api/clearances/{username}");
        }
        public async Task<HttpResponseMessage> deleteUser(string username)
        {
            return await http.DeleteAsync($"/api/users/{username}");
        }
        public async Task<HttpResponseMessage> deleteServiceAccount(string name)
        {
            return await http.DeleteAsync($"/api/service-accounts/{name}");
        }
        public async Task<HttpResponseMessage> deleteIdentity(string name, string provider)
        {
            return await http.DeleteAsync($"/api/service-accounts/{name}");
        }
        public async Task<HttpResponseMessage> deleteGroup(string name)
        {
            return await http.DeleteAsync($"/api/groups/{name}");
        }
        public async Task<HttpResponseMessage> deleteReplayProcessor(string instance, string processor)
        {
            return await http.DeleteAsync($"/api/processors/{instance}/{processor}");
        }
        public async Task<HttpResponseMessage> closeClientConnection(string id)
        {
            return await http.DeleteAsync($"/api/connections/{id}");
        }
        #endregion
        #region subscribtions
        public async Task CreateTMStatisticsSubscription(string _instance, string _processor)
        {
            SubscribeTMStatisticsRequest subscribeTMStatistics = new SubscribeTMStatisticsRequest(_instance, _processor);
            var req = new WebSocketRequest<SubscribeTMStatisticsRequest>();
            req.Type = "tmstats";
            req.Options = subscribeTMStatistics;
            await webclient.Send<SubscribeTMStatisticsRequest>(req);
        }
        public async Task CreateTimeSubscription(string _instance, string _processor)
        {
            SubscribeTimeRequest subscribeTMStatistics = new(_instance, _processor);
            var req = new WebSocketRequest<SubscribeTimeRequest>
            {
                Type = "time",
                Options = subscribeTMStatistics
            };
            await webclient.Send<SubscribeTimeRequest>(req);
        }
        #endregion
    }
}
