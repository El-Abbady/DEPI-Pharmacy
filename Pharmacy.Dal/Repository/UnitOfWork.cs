using DAL;
using Data;
using Interfaces;
using Models;

namespace Repository;
public class UnitOfWork : IUnitOfWork
{
    private readonly OnlinePharmacyDbContext _context;

    public UnitOfWork(OnlinePharmacyDbContext context)
    {
        _context = context;
        
        Categories = new Repository<Category>(_context);
        Orders = new Repository<Order>(_context);
        OrderDetails = new Repository<OrderDetail>(_context);
        Payments = new Repository<Payment>(_context);
        Products = new Repository<Product>(_context);
        ProductReviews = new Repository<ProductReview>(_context);
        Roles = new Repository<Role>(_context);
        Shippings = new Repository<Shipping>(_context);
        ShoppingCarts = new Repository<ShoppingCart>(_context);
        ShoppingCartItems = new Repository<ShoppingCartItem>(_context);
        Suppliers = new Repository<Supplier>(_context);
        Users = new Repository<User>(_context);

    }
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

    public void Dispose()
    {
        _context.Dispose();
    }

    public int Save()
    {
       return _context.SaveChanges();
    }
}
