using DotnetBackendDemo.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetBackendDemo.Api.Infrastructure;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<Company> Companies => Set<Company>();
	public DbSet<Service> Services => Set<Service>();
	public DbSet<Subscription> Subscriptions => Set<Subscription>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Service>()
			.HasIndex(s => s.Code)
			.IsUnique();

		modelBuilder.Entity<Subscription>()
			.HasIndex(s => new { s.CompanyId, s.ServiceId, s.Status });

		base.OnModelCreating(modelBuilder);
	}
}