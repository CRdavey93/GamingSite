namespace OneStopGaming.Repositories
{
    //This is the interface for the Unit of Work
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<Promotion> PromotionRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Cart> CartRepository { get; }
        IRepository<CartsProduct> CartsProductRepository { get; }
        bool Save();
    }
}