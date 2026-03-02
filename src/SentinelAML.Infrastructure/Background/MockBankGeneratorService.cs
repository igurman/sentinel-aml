using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SentinelAML.Application.DTOs;
using SentinelAML.Application.Interfaces;
using SentinelAML.Application.Services;
using SentinelAML.Domain.Enums;

namespace SentinelAML.Infrastructure.Background;

public class MockBankGeneratorService(
    TransactionProcessingService transactionProcessingService,
    ILogger<MockBankGeneratorService> logger,
    IServiceScopeFactory scopeFactory) : BackgroundService {
    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(2));
        while (await timer.WaitForNextTickAsync(stoppingToken)) {
            CallTransactionProcessingService();
            
            // just try to use repository
            using var scope = scopeFactory.CreateScope();
            var tr = scope.ServiceProvider.GetRequiredService<ICustomerRepository>();
            var cus = await tr.GetAllAsync();
            var customer = cus.Find(customer => true);
            logger.LogInformation("[***] Get Customer {}", customer);
        }
    }

    private void CallTransactionProcessingService() {
        logger.LogInformation("[***] CallTransactionProcessingService started");
        transactionProcessingService.Process(BuildRandomTransaction());
    }

    private static TransactionDto BuildRandomTransaction() {
        return new TransactionDto (
            1L,
            (decimal) Random.Shared.Next(1, 200) * 100,
            CurrencyType.USD,
            CountryType.USA,
            TransactionDirection.Outgoing,
            null,
            DateTimeOffset.Now
        );
    }
}