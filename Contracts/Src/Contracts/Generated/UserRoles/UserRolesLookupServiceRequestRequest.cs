namespace Retalix.Contracts.Generated.UserRoles
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.200.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://retalix.com/R10/services")]
    [Retalix.Commons.Contracts.ContractDocumentationAttributes.ContractSourceAttribute("Schemas\\UserRoles\\UserRolesLookupAndMaintenance.xsd")]
    public partial class UserRolesLookupServiceRequestRequest
    {
        
        private int userRoleIdField;
        
        private bool UserRoleIdFieldSpecified;
        
        [Retalix.Commons.Contracts.ContractValidationAttributes.ContractRequiredAttribute()]
        public int UserRoleId
        {
            get
            {
                return this.userRoleIdField;
            }
            set
            {
                this.userRoleIdField = value;
                this.UserRoleIdSpecified = true;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual bool UserRoleIdSpecified
        {
            get
            {
                return this.UserRoleIdFieldSpecified;
            }
            set
            {
                this.UserRoleIdFieldSpecified = value;
            }
        }
    }
}
