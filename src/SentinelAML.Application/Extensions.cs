using Microsoft.Extensions.DependencyInjection;
using SentinelAML.Application.Mappers;
using SentinelAML.Application.Services;

namespace SentinelAML.Application;

public static class Extensions {
    public static IServiceCollection AddApplications(this IServiceCollection serviceCollection) {
        serviceCollection.AddScoped<TransactionService>();
        serviceCollection.AddScoped<AlertMapper>();
        serviceCollection.AddScoped<CustomerMapper>();
        serviceCollection.AddScoped<TicketMapper>();
        serviceCollection.AddScoped<TransactionMapper>();
        serviceCollection.AddScoped<AlertService>();
        return serviceCollection;
    }
}