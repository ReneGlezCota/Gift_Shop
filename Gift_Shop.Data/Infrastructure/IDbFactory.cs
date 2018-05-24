using System;

namespace Gift_Shop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        GiftShopContext Init();
    }
}
