using System.ComponentModel.DataAnnotations;

namespace DotnetBackendDemo.Api.Domain.Entities;

public class Company
{
	public Guid Id { get; set; } = Guid.NewGuid();

	[Required, MinLength(2), MaxLength(200)]
	public string Name { get; set; } = string.Empty;

	[MaxLength(50)]
	public string? BusinessId { get; set; }

	public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

	public List<Subscription> Subscriptions { get; set; } = new();
}