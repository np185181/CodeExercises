using System;

namespace Retalix.StoreServices.Model.UserRoles
{
    /// <summary>
    /// UserRolesDto Class
    /// </summary>
    [Serializable]
    public class UserRolesDto
    {
        public virtual int UserRoleId { get; set; }
        public virtual string UserRoleName { get; set; }
        public virtual string UserRoleType { get; set; }
        public virtual string UserRoleDescription { get; set; }
        public virtual string IsUserRoleActive { get; set; }
    }
}
