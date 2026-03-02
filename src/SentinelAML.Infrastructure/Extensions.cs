using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SentinelAML.Application.Interfaces;
using SentinelAML.Domain.Interfaces;
using SentinelAML.Infrastructure.Data;
using SentinelAML.Infrastructure.Data.Dictionary;
using SentinelAML.Infrastructure.Repositories;

namespace SentinelAML.Infrastructure;

public static class Extensions {
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, string? url) {
        serviceCollection.AddDbContext<AppDbContext>(options => options.UseSqlServer(url));
        
        serviceCollection.AddScoped<ITransactionRepository, TransactionRepository>();
        serviceCollection.AddScoped<IAlertRepository, AlertRepository>();
        serviceCollection.AddScoped<ITicketRepository, TicketRepository>();
        serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
        serviceCollection.AddScoped<IDictionaryProvider, DbDictionaryProvider>();
        return serviceCollection;
    }
}