using Microsoft.Extensions.Logging;
using SentinelAML.Application.DTOs;

namespace SentinelAML.Application.Services;

/**
 * Main service
 */
public class TransactionProcessingService(ILogger<TransactionProcessingService> logger) {
    private readonly ILogger<TransactionProcessingService> _logger = logger;

    public void Process(TransactionDto transactionDto) {
        _logger.LogInformation("[***] Process started: {}", transactionDto);
            // 1. Save transaction
            // 2. Get client
            // 3. Start RiskEngine
            // 4. If threshold → create Alert
    }
    
}