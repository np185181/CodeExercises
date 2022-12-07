
namespace Retalix.StoreServices.Model.UserRoles
{
    /// <summary>
    /// Interface for UserRolesDao class
    /// </summary>
    public interface IUserRolesDao
    {
        UserRolesDto GetUserRole(int userRoleId);

        //IEnumerable<IUserRolesConfig> Find(string userRoleName);

        void SaveOrUpdate(UserRolesDto userRoleRow);

        void Delete(UserRolesDto userRole);
    }
}
