using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;

namespace Retalix.StoreServices.BusinessComponents.Selling.DMS.Upload
{
    /// <summary>
    /// UserRolesInfoDto class
    /// </summary>
    public class UserRolesInfoDto : INamedObject
    {
        [ProtoMember(1)]
        public string EntityName
        {
            get
            {
                return "UserRolesInfo";
            }
            set { }
        }

        [ProtoMember(2)]
        public int UserRoleId { get; set; }

        [ProtoMember(3)]
        public string UserRoleName { get; set; }

        [ProtoMember(4)]
        public string UserRoleType { get; set; }
    }
}
