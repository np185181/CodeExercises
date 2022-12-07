using Retalix.StoreServices.Model.Infrastructure.DataMovement;

namespace Retalix.StoreServices.Model.UserRoles
{
    /// <summary>
    /// IUserRolesInfo interface for UserRolesInfo class
    /// </summary>
    public interface IUserRolesInfo : IMovable
    {
        int UserRoleId { get; set; }

        string UserRoleName { get; set; }

        string UserRoleType { get; set; }
    }
}
