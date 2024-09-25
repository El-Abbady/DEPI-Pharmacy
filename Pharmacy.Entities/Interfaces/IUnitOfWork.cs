
using Models;

namespace Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IRepository<Category> Categories { get; }
    public IRepository<Order> Orders { get; }
    public IRepository<OrderDetail> OrderDetails { get; }
    public IRepository<Payment> Payments { get; }
    public IRepository<Product> Products { get; }
    public IRepository<ProductReview> ProductReviews { get; }
    public IRepository<Role> Roles { get; }
    public IRepository<Shipping> Shippings { get; }
    public IRepository<ShoppingCart> ShoppingCarts { get; }
    public IRepository<ShoppingCartItem> ShoppingCartItems { get; }
    public IRepository<Supplier> Suppliers { get; }
    public IRepository<User> Users { get; }
    int Save();
}
