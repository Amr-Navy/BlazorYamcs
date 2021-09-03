namespace Yamcs.Shared.Models
{
    public class ListPrivilegesResponse
    {
    }
    public class ListRolesResponse
    {
        public RoleInfo[] roleInfos { set; get; }
    }
    public class RoleInfo
    {
        public string name { get; set; }
        public string description { get; set; }
        public string[] systemPrivilages { get; set; }
        public ObjectPrivilageInfo[] objectPrivilageInfos { set; get; }

    }
    public class ObjectPrivilageInfo
    {
        public string type { get; set; }
        public string[] Object { set; get; }
    }
    public class ListServiceAccountsResponse
    {
        public ServiceAccountInfo[] groups { get; set; }
    }
    public class ListGroupsRespons
    {
        public GroupInfo[] groups { get; set; }
    }
    public class ListUsersResponse
    {
        public UserInfo[] users { set; get; }
    }
    public class UserInfo
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string email { get; set; }
        public bool active { set; get; }
        public bool superuser { set; get; }
        public UserInfo createdBy { set; get; }
        public string creationTime { set; get; }  // RFC 3339
        public string confirmationTime { set; get; }
        public string lastLoginTime { set; get; }
        public ObjectPrivilageInfo[] objectPrivilege { set; get; }
        public GroupInfo[] groups { set; get; }
        public ExternalIdentityInfo[] identities { set; get; }
        public RoleInfo[] roles { set; get; }
        public SignificanceLevelType clearance { set; get; }
    }
    public class GroupInfo
    {
        public string name { get; set; }
        public string description { get; set; }
        public UserInfo[] users { get; set; }
        public ServiceAccountInfo serviceAccounts { get; set; }
    }
    public class ServiceAccountInfo
    {
        public string name { get; set; }
        public string displayname { get; set; }
        public bool active { get; set; }
        public UserInfo createdby { get; set; }
        public string creationtime { set; get; }
        public string confirmationTime { set; get; }
        public string lastlogintime { get; set; }
    }

    public class ExternalIdentityInfo
    {
        public string identity { get; set; }
        public string provider { get; set; }
    }
    public enum SignificanceLevelType
    {
        NONE,
        WATCH,
        WARNING,
        DISTRESS,
        CRITICAL,
        SEVERE,

    }
    public class CreateUserRequest
    {
        public CreateUserRequest(string _name, string _displayname, string _email)
        {
            name = _name;
            displayName = _displayname;
            email = _email;
        }
        public string name { set; get; }
        public string displayName { set; get; }
        public string email { set; get; }
        public string password { set; get; }
    }

    public class EditUserRequest
    {
        public EditUserRequest(string displayName, string email, bool active, bool superuser)
        {
            this.DisplayName =
            this.DisplayName = displayName;
            this.Email = email;
            this.Active = active;
            this.Superuser = superuser;

        }

        public string DisplayName { set; get; }
        public string Email { set; get; }
        public bool Active { set; get; }
        public bool Superuser { set; get; }
        public string Password { set; get; }
        public RoleAssignmentInfo RoleAssignment { set; get; }
    }
    public class RoleAssignmentInfo
    {
        public string[] Roles { set; get; }
    }
    public class CreateServiceAccountRequest
    {
        public CreateServiceAccountRequest(string _name)
        {
            Name = _name;
        }
        public string Name { set; get; }
    }

    public class CreateServiceAccountResponse
    {
        public CreateServiceAccountResponse(string name, string applicationId, string applicationSecret)
        {
            this.Name = name;
            this.ApplicationId = applicationId;
            this.ApplicationSecret = applicationSecret;
        }

        public string Name { set; get; }
        public string ApplicationId { set; get; }
        public string ApplicationSecret { set; get; }
    }
    public class CreateGroupRequest
    {
        public CreateGroupRequest(string name, string description, string[] users, string[] serviceAccounts)
        {
            this.Name = name;
            this.Description = description;
            this.Users = users;
            this.ServiceAccounts = serviceAccounts;
        }

        public string Name { set; get; }
        public string Description { set; get; }
        public string[] Users { set; get; }
        public string[] ServiceAccounts { set; get; }
    }

}
