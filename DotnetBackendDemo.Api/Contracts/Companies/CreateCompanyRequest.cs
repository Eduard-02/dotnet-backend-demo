using System.ComponentModel.DataAnnotations;

namespace DotnetBackendDemo.Api.Contracts.Companies;

public class CreateCompanyRequest
{
    [Required, MinLength(2), MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? BusinessId { get; set; }
}