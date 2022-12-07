using System;
using Retalix.StoreServices.Model.UserRoles;

namespace Retalix.StoreServices.BusinessComponents.Selling.UserRoles
{
    /// <summary>
    /// UserRolesInfo Class
    /// </summary>
    [Serializable]
    public class UserRolesInfo : IUserRolesInfo
    {
        public virtual int UserRoleId { get; set; }

        public virtual string UserRoleName { get; set; }

        public virtual string UserRoleType { get; set; }

        public virtual string UserRoleDescription { get; set; }

        public virtual string IsUserRoleActive { get; set; }

        public virtual string EntityName
        {
            get { return "UserRolesInfo"; }
        }

    }
}
