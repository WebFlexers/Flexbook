using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Flexbook.Services;

public class CustomerService : CrudService<Customer>, ICustomerService
{
    public CustomerService(FlexbookDbContext dbContext) : base(dbContext) { }

    [return: MaybeNull]
    public override Customer GetById(int id)
    {
        return _dbContext.Set<Customer>()
            .Include(customer => customer.Address)
            .FirstOrDefault(customer => customer.Id == id);
    }
}
