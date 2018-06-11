namespace OneStopGaming.Services
{
    //Interface for a Product Service
    public interface IProductService
    {
        Product GetFeaturedProduct();
        decimal GetProductSalePrice(int id, int zipCode);
    }
}