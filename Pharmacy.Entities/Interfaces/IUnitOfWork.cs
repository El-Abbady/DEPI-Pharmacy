
using Models;

namespace Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IRepository<Category> Categories { get; }
    public IRepository<Order> Orders { get; }
    public IRepository<OrderDetail> OrderDetails { get; }
    public IRepository<Payment> Payments { get; }
    public IRepository<Product> Products { get; }
    public IRepository<ShoppingCart> ShoppingCarts { get; }
    public IRepository<User> Users { get; }
    public IRepository<UserRole> UserRoles { get; }

    int Save();
}
