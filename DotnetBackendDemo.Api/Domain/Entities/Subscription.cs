using System.ComponentModel.DataAnnotations;

namespace DotnetBackendDemo.Api.Domain.Entities;

public enum SubscriptionStatus
{
	Active = 1,
	Inactive = 2
}

public class Subscription
{
	public Guid Id { get; set; } = Guid.NewGuid();

	[Required]
	public Guid CompanyId { get; set; }
	public Company? Company { get; set; }

	[Required]
	public Guid ServiceId { get; set; }
	public Service? Service { get; set; }

	public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Active;

	public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
	public DateOnly? EndDate { get; set; }
}