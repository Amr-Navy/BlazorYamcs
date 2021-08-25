using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string description { get; set; }
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
        public UserInfo[] UserInfos { set; get; }
    }
    public class UserInfo
    {
        public string Name { get; set; }
        public string Displayname { get; set; }
        public string Email { get; set; }
        public bool Active { set; get; }
        public bool Superuser { set; get; }
        public UserInfo CreatedBy { set; get; }
        public string CreationTime { set; get; }  // RFC 3339
        public string ConfirmationTime { set; get; }
        public string LastLoginTime { set; get; }
        public ObjectPrivilageInfo[] objectPrivilege { set; get; }
        public GroupInfo[] Groups { set; get; }
        public ExternalIdentityInfo[] Identities { set; get; }
        public RoleInfo[] Roles { set; get; }
        public SignificanceLevelType Clearance { set; get; }
    }
    public class GroupInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
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
      public string  name { set; get; }
        public string displayName { set; get; }
        public string email { set; get; }
        public string password { set; get; }
}

    public class EditUserRequest
    {
     public string   displayName { set; get; }
        public string email { set; get; }
        public bool active { set; get; }
        public bool superuser{ set; get; }
    public string password { set; get; }
     public RoleAssignmentInfo  roleAssignment { set; get; }
}
public class RoleAssignmentInfo
    {
     public string[]   roles { set; get; }
    }
    public class CreateServiceAccountRequest
    {
        public string name { set; get; }
    }

    public class CreateServiceAccountResponse
    {
        public string name { set; get; }
        public string applicationId { set; get; }
        public string applicationSecret { set; get; }
    }
    public class CreateGroupRequest
    {
        public string name { set; get; }
        public string description { set; get; }
        public string[] users { set; get; }
        public string[] serviceAccounts { set; get; }
}

}
