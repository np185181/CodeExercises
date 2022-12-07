using System;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.Versioning;
using Retalix.StoreServices.Model.Infrastructure.StoreApplication;
using Retalix.StoreServices.Model.UserRoles;

namespace Retalix.StoreServices.Connectivity.Selling.DMS
{
    /// <summary>
    /// UserRolesServiceResolver Class
    /// </summary>
    public class UserRolesServiceResolver : IMultiVersionMovableServiceResolver
    {
        private readonly IResolver _resolver;

        public UserRolesServiceResolver(IResolver resolver)
        {
            _resolver = resolver;
        }

        private const string MovableDaoName = "UserRolesDao";

        public string ComponentName
        {
            get
            {
                return "Core";
            }
        }

        public IMovableFormatter Formatter
        {
            get
            {
                return null;
            }
        }

        public IMovableDao MovableDao
        {
            get
            {
                return _resolver.Resolve<IMovableDao>(MovableDaoName);
            }
        }

        public Type MovableType
        {
            get
            {
                return typeof(IUserRolesInfo);
            }
        }

    }
}
