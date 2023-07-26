using Microsoft.EntityFrameworkCore;

using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.MenuAggregate;
using RestApiDDDArchitecture.Infrastructure.Persistence.Interceptors;

namespace RestApiDDDArchitecture.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
	private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
	public AppDbContext(DbContextOptions<AppDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
	{
		_publishDomainEventsInterceptor = publishDomainEventsInterceptor;
	}

	public DbSet<Menu> Menus { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.Ignore<List<IDomainEvent>>()
			.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
			
		base.OnModelCreating(modelBuilder);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
		base.OnConfiguring(optionsBuilder);
	}
}