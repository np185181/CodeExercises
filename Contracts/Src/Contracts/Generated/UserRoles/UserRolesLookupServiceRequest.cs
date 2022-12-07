namespace Retalix.Contracts.Generated.UserRoles
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.200.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://retalix.com/R10/services", IsNullable=false)]
    [Retalix.Commons.Contracts.ContractDocumentationAttributes.ContractSourceAttribute("Schemas\\UserRoles\\UserRolesLookupAndMaintenance.xsd")]
    public partial class UserRolesLookupServiceRequest : Retalix.Contracts.Interfaces.IHeaderRequest
    {
        
        private RetalixCommonHeaderType headerField;
        
        private UserRolesLookupServiceRequestRequest requestField;
        
        private string majorVersionField;
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        public RetalixCommonHeaderType Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        public UserRolesLookupServiceRequestRequest Request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MajorVersion
        {
            get
            {
                return this.majorVersionField;
            }
            set
            {
                this.majorVersionField = value;
            }
        }
    }
}
