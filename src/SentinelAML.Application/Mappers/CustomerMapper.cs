using SentinelAML.Application.DTOs;
using SentinelAML.Domain.Entities;

namespace SentinelAML.Application.Mappers;

public class CustomerMapper(/*IDictionaryProvider dictionary*/) {
    
    public CustomerDto? Map(Customer? customer) {
        if (customer == null)
            return null;
        
        return new CustomerDto(
            Id: customer.Id,
            Name: customer.Name,
            Country: customer.Country,
            IsPep: customer.IsPep,
            RiskLevel: customer.RiskLevel,
            CreatedAt: customer.CreatedAt
        );
    }

}