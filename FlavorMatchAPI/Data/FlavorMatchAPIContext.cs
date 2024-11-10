using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlavorMatch.Shared.Models;

    public class FlavorMatchAPIContext : DbContext
    {
        public FlavorMatchAPIContext (DbContextOptions<FlavorMatchAPIContext> options)
            : base(options)
        {
        }

        public DbSet<FlavorMatch.Shared.Models.Dishes> Dishes { get; set; } = default!;

        public DbSet<FlavorMatch.Shared.Models.Ingredients> Ingredients { get; set; } = default!;

		public DbSet<FlavorMatch.Shared.Models.UserPreferences> UserPreferences { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserPreferences>()
				.HasKey(up => up.Id);

			modelBuilder.Entity<UserPreferences>()
				.HasIndex(up => new { up.UserId, up.IngredientId })
				.IsUnique();
		}
}
