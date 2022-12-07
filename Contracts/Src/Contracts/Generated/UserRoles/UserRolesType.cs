namespace Retalix.Contracts.Generated.UserRoles
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.200.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://retalix.com/R10/services", IsNullable=true)]
    [Retalix.Commons.Contracts.ContractDocumentationAttributes.ContractSourceAttribute("Schemas\\UserRoles\\UserRolesType.xsd")]
    public partial class UserRolesType
    {
        
        private int userRoleIDField;
        
        private bool userRoleIDFieldSpecified;
        
        private string userRoleNameField;
        
        private string userRoleTypeField;
        
        private string userRoleDescriptionField;
        
        private string isUserRoleActiveField;
        
        public int UserRoleID
        {
            get
            {
                return this.userRoleIDField;
            }
            set
            {
                this.userRoleIDField = value;
                this.UserRoleIDSpecified = true;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UserRoleIDSpecified
        {
            get
            {
                return this.userRoleIDFieldSpecified;
            }
            set
            {
                this.userRoleIDFieldSpecified = value;
            }
        }
        
        public string UserRoleName
        {
            get
            {
                return this.userRoleNameField;
            }
            set
            {
                this.userRoleNameField = value;
            }
        }
        
        public string UserRoleType
        {
            get
            {
                return this.userRoleTypeField;
            }
            set
            {
                this.userRoleTypeField = value;
            }
        }
        
        public string UserRoleDescription
        {
            get
            {
                return this.userRoleDescriptionField;
            }
            set
            {
                this.userRoleDescriptionField = value;
            }
        }
        
        public string IsUserRoleActive
        {
            get
            {
                return this.isUserRoleActiveField;
            }
            set
            {
                this.isUserRoleActiveField = value;
            }
        }
    }
}
