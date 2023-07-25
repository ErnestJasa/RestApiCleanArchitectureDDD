using Microsoft.EntityFrameworkCore;

using RestApiDDDArchitecture.Domain.MenuAggregate;

namespace RestApiDDDArchitecture.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
	{		
	}
	
	public DbSet<Menu> Menus { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
			
		base.OnModelCreating(modelBuilder);
	}
}