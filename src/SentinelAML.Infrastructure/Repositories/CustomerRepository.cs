using Microsoft.EntityFrameworkCore;
using SentinelAML.Application.Interfaces;
using SentinelAML.Domain.Entities;
using SentinelAML.Infrastructure.Data;

namespace SentinelAML.Infrastructure.Repositories;

public class CustomerRepository(AppDbContext context) : ICustomerRepository {
    
    public async Task<Customer?> GetByIdAsync(long id) => await context.Customers.FindAsync(id);

    public async Task<List<Customer>> GetAllAsync() => await context.Customers.ToListAsync();

    public async Task AddAsync(Customer entity) => await context.Customers.AddAsync(entity);

    public void Update(Customer entity) => context.Customers.Update(entity);

    public void Remove(Customer entity) => context.Customers.Remove(entity);
}