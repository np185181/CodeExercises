using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.Entity;

namespace Retalix.StoreServices.Model.Infrastructure.UserRoles
{
    /// <summary>
    /// IUserRolesConfig interface
    /// </summary>
    public interface IUserRolesConfig : IEntity<int>, IExtensible<IUserRolesConfig>, IMovable
    {
        int UserRoleId { get; set; }
        string UserRoleName { get; set; }
        string UserRoleType { get; set; }
        string UserRoleDescription { get; set; }
        string IsUserRoleActive { get; set; }
    }
}
