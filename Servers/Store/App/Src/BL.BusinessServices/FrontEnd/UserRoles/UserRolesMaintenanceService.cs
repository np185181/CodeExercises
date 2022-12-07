using System;
using Retalix.Contracts.Generated.Common;
using Retalix.Contracts.Generated.UserRoles;
using Retalix.StoreServices.BusinessServices.Common.Services;
using Retalix.StoreServices.BusinessServices.FrontEnd.AutoMapping;
using Retalix.StoreServices.BusinessServices.FrontEnd.UserRoles.DataMapping;
using Retalix.StoreServices.Model.UserRoles;

namespace Retalix.StoreServices.BusinessServices.FrontEnd.UserRoles
{
    /// <summary>
    /// UserRolesMaintenanceService class to perform add/update/delete operations on User Roles entity
    /// </summary>
    public class UserRolesMaintenanceService : BusinessServiceBase<UserRolesMaintenanceRequest, UserRolesMaintenanceResponse>
    {
        private readonly IUserRolesDao _userRolesDAO;
        private readonly DataMapper _mapper;

        /// <summary>
        /// Initializes UserRolesDao and DataMapper
        /// </summary>
        /// <param name="userRolesDAO"></param>
        public UserRolesMaintenanceService(IUserRolesDao userRolesDAO)
        {
            _userRolesDAO = userRolesDAO;
            _mapper = new DataMapper();
            _mapper.AddConfig(new UserRolesMappingConfiguration());
        }

        /// <summary>
        /// Entry point of the service
        /// </summary>
        /// <returns></returns>
        protected override UserRolesMaintenanceResponse InternalExecute()
        {
            switch (Request.Action1)
            {
                case ActionTypeCodes.AddOrUpdate:
                case ActionTypeCodes.AddUpdate:
                {
                    this.ManipulateUserRole(Request.UserRoles);
                    break;
                }
                case ActionTypeCodes.Delete:
                    DeleteUserRole(Request.UserRoles);
                    break;
                default:
                    break;
            }
            return (UserRolesMaintenanceResponse)(Request.Header.MessageId == null ? BuildResponse() : BuildResponse(Request.Header.MessageId.Value));
        }

        /// <summary>
        /// To perform User Role Add/Update operation.
        /// </summary>
        /// <param name="userRolesRow"></param>
        private void ManipulateUserRole(UserRolesType userRolesRow)
        {
            var userRole = new UserRolesDto()
            {
                UserRoleId = userRolesRow.UserRoleID,
                UserRoleName = userRolesRow.UserRoleName,
                UserRoleType = userRolesRow.UserRoleType,
                UserRoleDescription = userRolesRow.UserRoleDescription,
                IsUserRoleActive = userRolesRow.IsUserRoleActive
            };

            _userRolesDAO.SaveOrUpdate(userRole);
        }

        /// <summary>
        /// Deletes the user role
        /// </summary>
        /// <param name="userRoleRow"></param>
        private void DeleteUserRole(UserRolesType userRoleRow)
        {
            var userRole = new UserRolesDto
            {
                UserRoleId = userRoleRow.UserRoleID
            };

            _userRolesDAO.Delete(userRole);
        }

        /// <summary>
        /// Builds Response
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        private UserRolesMaintenanceResponse BuildResponse(string requestId = null)
        {
            return new UserRolesMaintenanceResponse
            {
                Header = new RetalixCommonHeaderType
                {
                    Response = new RetalixResponseCommonData
                    {
                        ResponseCode = "OK",
                        RequestID = requestId
                    }
                }
            };
        }

        /// <summary>
        /// Formats Error Response
        /// </summary>
        /// <param name="request"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override Model.Infrastructure.Service.IDocumentResponse FormatErrorResponse(Model.Infrastructure.Service.IDocumentRequest request, Exception exception)
        {
            string resultMessage = exception.Message;// + exception.StackTrace;
            return new DocumentStringResponse(resultMessage);
        }
    }
}
