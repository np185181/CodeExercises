using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Retalix.Contract.Schemas.Schema.ARTS.PosLog_V6.Objects;
using Retalix.StoreServices.Model.Selling;
using Retalix.StoreServices.Model.Selling.RetailTransaction.RetailTransactionLog;
using Retalix.StoreServices.Model.Infrastructure.Audit;
using Retalix.StoreServices.Model.Infrastructure.Service;

namespace Retalix.StoreServices.BusinessComponents.Selling.RetailTransactionLog
{
    /// <summary>
    /// TransactionTimeCalculationVisitor Class to log Transaction start & end time
    /// </summary>
    public class TransactionTimeCalculationVisitor : IRetailTransactionLogDocumentCreationCoreVisitor
    {
        private readonly IAuditLogDao _auditLogDao;
        private readonly IFactory _factory;

        /// <summary>
        /// TransactionTimeCalculationVisitor constructor initializes auditLogDao & factory instances
        /// </summary>
        /// <param name="auditLogDao"></param>
        /// <param name="factory"></param>
        public TransactionTimeCalculationVisitor(IAuditLogDao auditLogDao, IFactory factory)
        {
            _auditLogDao = auditLogDao;
            _factory = factory;
        }
        
        /// <summary>
        /// Method implemented from interface to log transaction time
        /// </summary>
        /// <param name="retailTransaction"></param>
        /// <param name="writer"></param>
        public void Visit(IRetailTransaction retailTransaction, IRetailTransactionLogDocumentWriter writer)
        {
            var transaction = writer.LogDocument.ObjectContent as TransactionDomainSpecific;
            XmlElement transactionDurationElement =
                ToXmlElement(new XElement("TransactionTime", (retailTransaction.EndTime - retailTransaction.StartTime).ToString(@"hh\:mm\:ss"), new XAttribute("format", "hh:mm:ss")));
            transaction.Any = new List<XmlElement> { transactionDurationElement };
            writer.UpdateArtsTransaction(transaction);
        }
        
        /// <summary>
        /// ToXmlElement method to load xml element
        /// </summary>
        /// <param name="el"></param>
        /// <returns></returns>
        private static XmlElement ToXmlElement(XElement el)
        {
            var doc = new XmlDocument();
            doc.Load(el.CreateReader());
            return doc.DocumentElement;
        }
    }
}
