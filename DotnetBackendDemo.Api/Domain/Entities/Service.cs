using System.ComponentModel.DataAnnotations;

namespace DotnetBackendDemo.Api.Domain.Entities;

public class Service
{
	public Guid Id { get; set; } = Guid.NewGuid();

	[Required, MinLength(2), MaxLength(50)]
	public string Code { get; set; } = string.Empty;

	[Required, MinLength(2), MaxLength(200)]
	public string Name { get; set; } = string.Empty;

	public List<Subscription> Subscriptions { get; set; } = new();
}