namespace Gift_Shop.Data.Infrastructure
{
    public class DbFactory :  Disposable, IDbFactory
    {
        GiftShopContext dbContext;

        public GiftShopContext Init()
        {
            return dbContext ?? (dbContext = new GiftShopContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
