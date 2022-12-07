namespace Retalix.Contracts.Generated.UserRoles
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    /// <summary>
    /// Maintenance service for User Roles Type.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.200.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://retalix.com/R10/services", IsNullable=false)]
    [Retalix.Commons.Contracts.ContractDocumentationAttributes.ContractSourceAttribute("Schemas\\UserRoles\\UserRolesLookupAndMaintenance.xsd")]
    public partial class UserRolesMaintenanceRequest : MaintenanceServiceRequestAbstract
    {
        
        private UserRolesType userRolesField;
        
        private ActionTypeCodes action1Field;
        
        private bool Action1FieldSpecified;
        
        /// <summary>
        /// The Application Configuration Type for maintenance (Add / Update / Delete).
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        public UserRolesType UserRoles
        {
            get
            {
                return this.userRolesField;
            }
            set
            {
                this.userRolesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Action")]
        public ActionTypeCodes Action1
        {
            get
            {
                return this.action1Field;
            }
            set
            {
                this.action1Field = value;
                this.Action1Specified = true;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual bool Action1Specified
        {
            get
            {
                return this.Action1FieldSpecified;
            }
            set
            {
                this.Action1FieldSpecified = value;
            }
        }
    }
}
