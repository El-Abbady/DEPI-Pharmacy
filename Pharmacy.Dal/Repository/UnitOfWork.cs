using DAL;
using Data;
using Interfaces;
using Models;

namespace Repository;
public class UnitOfWork : IUnitOfWork
{
    private readonly PharmacyDbContext _context;

    public UnitOfWork(PharmacyDbContext context)
    {
        _context = context;
        //Employees = new Repository<Employee>(_context);
        Categories = new Repository<Category>(_context);
        Orders = new Repository<Order>(_context);
        OrderDetails = new Repository<OrderDetail>(_context);
        Payments = new Repository<Payment>(_context);
        Products = new Repository<Product>(_context);
        ShoppingCarts = new Repository<ShoppingCart>(_context);
        Users = new Repository<User>(_context);
        UserRoles = new Repository<UserRole>(_context);

    }
    public IRepository<Category> Categories { get; }
    public IRepository<Order> Orders { get; }
    public IRepository<OrderDetail> OrderDetails { get; }
    public IRepository<Payment> Payments { get; }
    public IRepository<Product> Products { get; }
    public IRepository<ShoppingCart> ShoppingCarts { get; }
    public IRepository<User> Users { get; }
    public IRepository<UserRole> UserRoles { get; }

    public void Dispose()
    {
        _context.Dispose();
    }

    public int Save()
    {
       return _context.SaveChanges();
    }
}
