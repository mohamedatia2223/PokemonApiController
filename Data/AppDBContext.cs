using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data.Model;

namespace PokemonReviewApp.Data
{
    public class AppDBContext : DbContext 
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Pokemon>()
                .HasMany(a => a.Reviews)
                .WithOne(a => a.pokemon)
                .HasForeignKey(a => a.pokemonId);

            model.Entity<Reviewer>()
                .HasMany(a => a.Reviews)
                .WithOne(a => a.reviewer)
                .HasForeignKey(a => a.reviewerId);
        }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Reviewer> Reviewers{ get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Owner> Owners { get; set; }

    }
}
