namespace Yamcs.Shared.Models
{
    public class ListPrivilegesResponse
    {
    }
    public class ListRolesResponse
    {
        public RoleInfo[] RoleInfos { set; get; }
    }
    public class RoleInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] SystemPrivilages { get; set; }
        public ObjectPrivilageInfo[] ObjectPrivilageInfos { set; get; }

    }
    public class ObjectPrivilageInfo
    {
        public string Type { get; set; }
        public string[] Object { set; get; }
    }
    public class ListServiceAccountsResponse
    {
        public ServiceAccountInfo[] Groups { get; set; }
    }
    public class ListGroupsRespons
    {
        public GroupInfo[] Groups { get; set; }
    }
    public class ListUsersResponse
    {
        public UserInfo[] Users { set; get; }
    }
    public class UserInfo
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool active { set; get; }
        public bool Superuser { set; get; }
        public UserInfo CreatedBy { set; get; }
        public string CreationTime { set; get; }  // RFC 3339
        public string ConfirmationTime { set; get; }
        public string LastLoginTime { set; get; }
        public ObjectPrivilageInfo[] ObjectPrivilege { set; get; }
        public GroupInfo[] Groups { set; get; }
        public ExternalIdentityInfo[] Identities { set; get; }
        public RoleInfo[] Roles { set; get; }
        public SignificanceLevelType Clearance { set; get; }
    }
    public class GroupInfo
    {
        public string Name { get; set; }
        public string description { get; set; }
        public UserInfo[] Users { get; set; }
        public ServiceAccountInfo ServiceAccounts { get; set; }
    }
    public class ServiceAccountInfo
    {
        public string Name { get; set; }
        public string Displayname { get; set; }
        public bool Active { get; set; }
        public UserInfo Createdby { get; set; }
        public string Creationtime { set; get; }
        public string ConfirmationTime { set; get; }
        public string Lastlogintime { get; set; }
    }

    public class ExternalIdentityInfo
    {
        public string Identity { get; set; }
        public string Provider { get; set; }
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
            Name = _name;
            DisplayName = _displayname;
            Email = _email;
        }
        public string Name { set; get; }
        public string DisplayName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
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
