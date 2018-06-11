using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneStopGaming.Services
{
    //Interface for a Cart Service
    public interface ICartService
    {
        Cart GetCart(string status, int userId);
        Cart CreateCart(int userId, int zip = 0);
        CartsProduct UpdateCart(int cartId, int productId, int quantity);
        List<Product> GetProductsForACart(int cartId);
        List<int> GetQuantitiesForACart(int cartId);
    }
}