namespace DotnetBackendDemo.Api.Contracts.Companies;

public class CompanyResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? BusinessId { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}