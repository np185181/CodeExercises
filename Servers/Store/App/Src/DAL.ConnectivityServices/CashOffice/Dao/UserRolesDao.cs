using Retalix.StoreServices.Model.Infrastructure.DataAccess;
using NHibernate;

namespace Retalix.StoreServices.Model.UserRoles
{
    /// <summary>
    /// UserRolesDao class used to perform add/update/delete operations
    /// </summary>
    public class UserRolesDao : IUserRolesDao
    {
        private readonly ISessionProvider _sessionProvider;
        private ISession Session
        {
            get { return _sessionProvider.GetDefaultSession<ISession>(); }
        }

        /// <summary>
        /// Initializes ISessionProvider instance
        /// </summary>
        /// <param name="sessionProvider"></param>
        public UserRolesDao(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        /// <summary>
        /// Deletes the user role from table
        /// </summary>
        /// <param name="userRoleRow"></param>
        public void Delete(UserRolesDto userRoleRow)
        {
            UserRolesDto existingUserRoles = GetUserRole(userRoleRow.UserRoleId);
           
            using(ITransaction transaction = Session.BeginTransaction())
            {
                Session.Clear();
                
                if (existingUserRoles != null)
                {
                    Session.Delete(existingUserRoles);
                    transaction.Commit();
                }
            }
        }

        //public IEnumerable<Infrastructure.UserRoles.IUserRolesConfig> Find(string userRoleName)
        //{
        //    return null; // Session.Query<UserRole>().ToList();
        //}

        /// <summary>
        /// Retrieves User Role based on UserRoleId
        /// </summary>
        /// <param name="userRoleId"></param>
        /// <returns></returns>
        public UserRolesDto GetUserRole(int userRoleId)
        {
            var result = Session.QueryOver<UserRolesDto>().Where(x => x.UserRoleId == userRoleId).SingleOrDefault();

            UserRolesDto userRolesDto = null;

            if (result != null)
            {
                userRolesDto = new UserRolesDto()
                {
                    UserRoleId = result.UserRoleId,
                    UserRoleName = result.UserRoleName,
                    UserRoleType = result.UserRoleType,
                    UserRoleDescription = result.UserRoleDescription,
                    IsUserRoleActive = result.IsUserRoleActive
                };
            }
            return userRolesDto;
        }

        /// <summary>
        /// Saves/Updates the User Role record to table
        /// </summary>
        /// <param name="userRoleRow"></param>
        public void SaveOrUpdate(UserRolesDto userRoleRow)
        {
            var existingUserRoles = GetUserRole(userRoleRow.UserRoleId);
            if (existingUserRoles != null)
            {
                existingUserRoles.UserRoleName = userRoleRow.UserRoleName;
                existingUserRoles.UserRoleType = userRoleRow.UserRoleType;
                existingUserRoles.UserRoleDescription = userRoleRow.UserRoleDescription;
                existingUserRoles.IsUserRoleActive = userRoleRow.IsUserRoleActive;
            }
            else
            {
                existingUserRoles = userRoleRow;
            }
            Session.Merge(userRoleRow);
        }
    }
}
