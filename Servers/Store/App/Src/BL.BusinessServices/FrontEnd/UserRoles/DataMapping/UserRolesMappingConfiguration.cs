using Retalix.Contracts.Generated.UserRoles;
using Retalix.StoreServices.BusinessServices.FrontEnd.AutoMapping;
using Retalix.StoreServices.Model.Infrastructure.UserRoles;

namespace Retalix.StoreServices.BusinessServices.FrontEnd.UserRoles.DataMapping
{
    /// <summary>
    /// UserRoles Mapping Configuration
    /// </summary>
    public class UserRolesMappingConfiguration : DataMapperConfigurationBase
    {
        /// <summary>
        /// Overrides Configure method to map UserRolesType with IUserRolesConfig
        /// </summary>
        /// <param name="mapper"></param>
        public override void Configure(DataMapper mapper)
        {
            if (mapper.HasNoMapFor<IUserRolesConfig, UserRolesType>())
                mapper.CreateMap<IUserRolesConfig, UserRolesType>();
        }
    }
}
