using System;
using Retalix.Contracts.Generated.Common;
using Retalix.Contracts.Generated.UserRoles;
using Retalix.StoreServices.BusinessServices.Common.Services;
using Retalix.StoreServices.BusinessServices.FrontEnd.AutoMapping;
using Retalix.StoreServices.BusinessServices.FrontEnd.UserRoles.DataMapping;
using Retalix.StoreServices.Model.Infrastructure.Service;
using Retalix.StoreServices.Model.UserRoles;

namespace Retalix.StoreServices.BusinessServices.FrontEnd.UserRoles
{
    /// <summary>
    /// UserRolesLookupService used to retrieve User Roles from DB 
    /// </summary>
    public class UserRolesLookupService : BusinessServiceBase<UserRolesLookupServiceRequest, UserRolesLookupServiceResponse>
    {
        private readonly IUserRolesDao _userRolesDAO;
        private readonly DataMapper _mapper;

        /// <summary>
        /// Initializes UserRolesDao and DataMapper instances
        /// </summary>
        /// <param name="userRolesDAO"></param>
        public UserRolesLookupService(IUserRolesDao userRolesDAO)
        {
            _userRolesDAO = userRolesDAO;
            _mapper = new DataMapper();
            _mapper.AddConfig(new UserRolesMappingConfiguration());
        }

        /// <summary>
        /// Overrides FormatErrorResponse
        /// </summary>
        /// <param name="request"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override IDocumentResponse FormatErrorResponse(IDocumentRequest request, Exception exception)
        {
            string resultMessage = exception.Message + exception.StackTrace;
            return new DocumentStringResponse(resultMessage);
        }

        /// <summary>
        /// Entry point for the service
        /// </summary>
        /// <returns></returns>
        protected override UserRolesLookupServiceResponse InternalExecute()
        {
            if (Request.Request.UserRoleId != 0)
                throw new NotImplementedException();

            var userRoles = _userRolesDAO.GetUserRole(Request.Request.UserRoleId);

            return CreateResponseForKey(userRoles);
        }

        /// <summary>
        /// Creates Response For user role
        /// </summary>
        /// <param name="userRolesRow"></param>
        /// <returns></returns>
        private static UserRolesLookupServiceResponse CreateResponseForKey(UserRolesDto userRolesRow)
        {
            var response = new UserRolesLookupServiceResponse { Header = new RetalixCommonHeaderType() };
            var userRoles = new UserRolesType
            {
                UserRoleName = userRolesRow.UserRoleName,
                UserRoleType = userRolesRow.UserRoleType,
                UserRoleDescription = userRolesRow.UserRoleDescription,
                IsUserRoleActive = userRolesRow.IsUserRoleActive
            };

            if (userRolesRow != null)
            {
                response.Response = new UserRolesType[1] { userRoles };
            }
            return response;
        }
    }
}
