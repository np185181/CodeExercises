using Retalix.StoreServer.BusinessComponents.Finance.Balancing;
using Retalix.StoreServer.BusinessComponents.Finance.FundTransfer;
using Retalix.StoreServer.CoreConfiguration.CoreComponents.ConfigBuilder;
using Retalix.StoreServices.BusinessComponents.BRMS.Logging;
using Retalix.StoreServices.BusinessComponents.CDM.RetailTransactionLog;
using Retalix.StoreServices.BusinessComponents.Customer.RetailTransactionLog;
using Retalix.StoreServices.BusinessComponents.Organization.VenueShift;
using Retalix.StoreServices.BusinessComponents.Product.Legacy.Item.OnlineItem;
using Retalix.StoreServices.BusinessComponents.Promotion.Coupons.TLog;
using Retalix.StoreServices.BusinessComponents.Promotion.CustomerOrder.Log;
using Retalix.StoreServices.BusinessComponents.Selling.ConditionalRestriction.TransactionLog;
using Retalix.StoreServices.BusinessComponents.Selling.CustomerOrders.FormData;
using Retalix.StoreServices.BusinessComponents.Selling.Legacy.RetailTransaction.RetailTransactionLog.ARTSV6_0_0.Writer;
using Retalix.StoreServices.BusinessComponents.Selling.Restriction.TransactionLog;
using Retalix.StoreServices.BusinessComponents.Selling.RetailTransactionLog;
using Retalix.StoreServices.BusinessComponents.Selling.RetailTransactionLog.Adapters;
using Retalix.StoreServices.BusinessComponents.Selling.RetailTransactionLog.ItemNotFound;
using Retalix.StoreServices.BusinessComponents.Selling.RetailTransactionLog.OnlineProduct;
using Retalix.StoreServices.BusinessComponents.Selling.Returns.RetailTransactionLog;
using Retalix.StoreServices.BusinessComponents.Selling.SelfScan.TLog;
using Retalix.StoreServices.BusinessComponents.Selling.TransactionLog.Arts6LogVisitors;
using Retalix.StoreServices.BusinessComponents.Tender.RetailTransactionLog;
using Retalix.StoreServices.Connectivity.Transaction.RetailTransactionLog.Persistance;
using Retalix.StoreServices.Model.Document.TDM;
using Retalix.StoreServices.Model.Infrastructure.StoreApplication;
using Retalix.StoreServices.Model.Selling.RetailTransaction.RetailTransactionLog;

namespace Retalix.StoreServer.CoreConfiguration.CoreComponents
{
    internal class LogDocumentComponentsConfig : CastleConfigurationInstaller
    {
        public override void Install(IComponentInstaller builder)
        {
            builder.Register(Component.For<IRetailTransactionLogDocumentCreator>().ImplementedBy<RetailTransactionLogDocumentCreator>()
                .Named("RetailTransactionLogDocumentCreator").LifeStyle.Transient);
            
            RegisterRetailTransactionlogDocumentCreationVisitors(builder);

            RegisterLogDocumentDaoObservers(builder);
        }

        private static void RegisterRetailTransactionlogDocumentCreationVisitors(IComponentInstaller builder)
        {
            builder.Register(
                Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("Tran_LogCreationVisitor")
                    .ImplementedBy<TransactionForRetailTransacitonLogVisitor>().LifeStyle.Singleton);

            builder.Register(
                Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("Tend_LogCreationVisitor")
                    .ImplementedBy<TenderRetailTransactionLogCreationVisitor>().LifeStyle.Singleton);

            builder.Register(
                Component.For
                    <IRetailTransactionLogDocumentCreationCoreVisitor>().Named("OrderLinesLogVisitor")
                    .ImplementedBy<OrderLinesLogVisitor>().LifeStyle.Transient);

            builder.Register(
                Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("Cust_LogCreationVisitor")
                    .ImplementedBy<CustomerRetailTransactionLogCreationVisitor>().LifeStyle.Singleton);


            builder.Register(
                Component.For<IRetailTransactionLogDocumentCreationVisitor>().Named("TramsactionLink_LogCreationVisitor")
                    .ImplementedBy<TransactionLinkLogDocumentCreationVisitor>().LifeStyle.Singleton);

            builder.Register(
                Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("Slip_LogCreationVisitor")
                    .ImplementedBy<SlipLogDocumentCreationVisitor>().LifeStyle.Singleton);

            builder.Register(
               Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("OnlineItemBalanceInquiry_LogCreationVisitor")
                   .ImplementedBy<BalanceInquiryLogCreationVisitor>().LifeStyle.Singleton);

            builder.Register(
                Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("CentralReturns_LogCreationVisitor")
                    .ImplementedBy<ReturnsRetailTransactionLogCreationVisitor>().LifeStyle.Singleton);

            builder.Register(
                  Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("CouponRetailTransactionLogCreationVisitor")
                      .ImplementedBy<CouponRetailTransactionLogCreationVisitor>().LifeStyle.Singleton);

            builder.Register(
                    Component.For<IRetailTransactionLogDocumentCreationVisitor>().Named("RestrictionLogDocumentCreationVisitor")
                        .ImplementedBy<RestrictionLogDocumentCreationVisitor>().LifeStyle.Transient);

            //builder.Register(
            //   Component.For<IRetailTransactionLogDocumentCreationVisitor>().Named("RuleActivityLogDocumentCreationVisitor")
            //   .ImplementedBy<RuleActivityLogDocumentCreationVisitor>().LifeStyle.Singleton);

            //builder.Register(
            //   Component.For<ITipinTransactionLogDocumentVisitor>().Named("RuleActivityLogDocumentCreationVisitorTips")
            //   .ImplementedBy<RuleActivityLogDocumentCreationVisitor>().LifeStyle.Singleton);

            builder.Register(
               Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("RetailTransactionLogVisitor")
               .ImplementedBy<RetailTransactionLogVisitor>().LifeStyle.Singleton);

            builder.Register(
               Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("CustomerOrderLogVisitor")
               .ImplementedBy<CustomerOrderLogVisitor>().LifeStyle.Transient);

            builder.Register(
                Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("RewardLogVisitor").ImplementedBy
                    <RewardLogVistor>().LifeStyle.Transient);
            
            builder.Register(
                Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("PriceInqueryLinesLogVisitor").ImplementedBy
                    <PriceInqueryLinesLogVisitor>().LifeStyle.Singleton);

            builder.Register(
               Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("CustomerLogVisitor")
               .ImplementedBy<CustomerLogVisitor>().LifeStyle.Singleton);

            builder.Register(
               Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("FoodServiceLogVisistor")
               .ImplementedBy<FoodServiceLogVisistor>().LifeStyle.Singleton);

            builder.Register(
                Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("RefundablePromotionLogVisitor").ImplementedBy
                    <RefundablePromotionLogVisitor>().LifeStyle.Singleton);

            builder.Register(
                Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("RewardOnReturnLogVisitor").ImplementedBy
                    <RewardOnReturnLogVisitor>().LifeStyle.Singleton);
            
            builder.Register(Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("TaxLogVisitor")
                            .ImplementedBy<TaxLogVisitor>().LifeStyle.Transient);

            builder.Register(Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named(typeof(RestrictedSellLogVisitor).FullName)
                                      .ImplementedBy<RestrictedSellLogVisitor>().LifeStyle.Singleton);

            builder.Register(Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named(typeof(ItemNotFoundLogVisitor).FullName)
                                      .ImplementedBy<ItemNotFoundLogVisitor>().LifeStyle.Singleton);
            
            builder.Register(Component.For<IOrderLineLogDocumentCreationVisitor>().Named(typeof(IOrderLineLogDocumentCreationVisitor).FullName)
                                      .ImplementedBy<OnlineProductLineLogVisitor>().LifeStyle.Singleton);            
            
            builder.Register(Component.For<IOrderLineLogDocumentCreationVisitor>().Named("MobileProductLineLogVisitor")
                                      .ImplementedBy<MobileProductLineLogVisitor>().LifeStyle.Singleton);

            builder.Register(Component.For<IReturnLineLogDocumentCreationVisitor>().Named(typeof(IReturnLineLogDocumentCreationVisitor).FullName)
                                      .ImplementedBy<OnlineProductLineLogVisitor>().LifeStyle.Singleton);

            builder.Register(Component.For<IReturnLineLogDocumentCreationVisitor>().Named("MobileProductReturnLineLogVisitor")
                          .ImplementedBy<MobileProductLineLogVisitor>().LifeStyle.Singleton);

            builder.Register(Component.For<IOrderLineLogDocumentCreationVisitor>().Named("OrderLineStoreRangeVisitor")
                                     .ImplementedBy<StoreRangeLogVisitor>().LifeStyle.Singleton);

            builder.Register(Component.For<IReturnLineLogDocumentCreationVisitor>().Named("ReturnLineStoreRangeVisitor")
                                      .ImplementedBy<StoreRangeLogVisitor>().LifeStyle.Singleton);

            builder.Register(Component.For<IVoidOrderLineLogDocumentCreationVisitor>().Named("VoidedLineStoreRangeVisitor")
                                   .ImplementedBy<StoreRangeLogVisitor>().LifeStyle.Singleton);
            
            builder.Register(Component.For<IOrderLineLogDocumentCreationVisitor>().Named("OrderUnitLineLogVisitor")
                                   .ImplementedBy<UnitLineLogVisitor>().LifeStyle.Singleton);

            builder.Register(Component.For<IReturnLineLogDocumentCreationVisitor>().Named("ReturnUnitLineLogVisitor")
                       .ImplementedBy<UnitLineLogVisitor>().LifeStyle.Singleton);

            builder.Register(Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named(typeof(LoyaltyRewardLogVisitor).FullName)
                                      .ImplementedBy<LoyaltyRewardLogVisitor>().LifeStyle.Transient);

            builder.Register(Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named(typeof(SelfScanRetailTransactionLogVisitor).FullName).
                                       ImplementedBy<SelfScanRetailTransactionLogVisitor>().LifeStyle.Singleton);
            builder.Register(
                Component.For<IRetailTransactionLogDocumentCreationVisitor>().Named("FormDataLogVisitor").ImplementedBy
                    <FormsDataLogVisitor>().LifeStyle.Singleton);
            builder.Register(
               Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("VenueShiftRetailTransactionLogCreationVisitor").ImplementedBy
                   <VenueShiftRetailTransactionLogCreationVisitor>().LifeStyle.Singleton);

            builder.Register(Component.For<IShortRetentionPolicy>().Named(typeof(ShortRetentionPolicy).Name).
                ImplementedBy<ShortRetentionPolicy>().LifeStyle.Singleton);
            builder.Register(
                Component.For<IRetailTransactionLogDocumentCreationVisitor>().Named("R10VersionRetailTransactionLogVisitor").ImplementedBy
                    <R10VersionRetailTransactionLogVisitor>().LifeStyle.Singleton);
            builder.Register(
                Component.For<IRetailTransactionLogDocumentCreationCoreVisitor>().Named("TransactionTimeCalculationVisitor").ImplementedBy
                    <TransactionTimeCalculationVisitor>().LifeStyle.Singleton);
        }

        private void RegisterLogDocumentDaoObservers(IComponentInstaller builder)
        {
            builder.Register(Component.For<ITdmArchiveEventListener>().Named(typeof(XZReportCalculationAdaptor).Name)
                .ImplementedBy<XZReportCalculationAdaptor>().LifeStyle.Transient);

            builder.Register(Component.For<ITdmArchiveEventListener>().Named(typeof(PromotionSummaryLogObserver).Name)
                .ImplementedBy<PromotionSummaryLogObserver>().LifeStyle.Transient);

            builder.Register(Component.For<ITdmArchiveEventListener>().Named(typeof(AccountBalanceRecalculationAdapter).Name)
                .ImplementedBy<AccountBalanceRecalculationAdapter>().LifeStyle.Transient);

            builder.Register(Component.For<ITdmArchiveEventListener>().Named(typeof(TouchPointTotalizersObserver).Name)
                .ImplementedBy<TouchPointTotalizersObserver>().LifeStyle.Transient);
        }
    }
}