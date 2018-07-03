namespace SuperHeros.Migrations
{
    using SuperHeros.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperHeros.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SuperHeros.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            ApplicationDbContext db = new ApplicationDbContext();
            context.SuperHero.AddOrUpdate(
                s => s.Name,
                new SuperHero { Name = "Batman", AlterEgo = "Bruce Wayne", PrimaryAbility = "Fighting", SecondaryAbility = "Developing weapons", Catchprase = "It's Batman time!" },
                new SuperHero { Name = "Superman", AlterEgo = "Clark Kent", PrimaryAbility = "Super Strength", SecondaryAbility = "Flying", Catchprase = "Up, up and away!"},
                new SuperHero { Name = "Wonder Woman", AlterEgo = "Diana Prince", PrimaryAbility = "Fighting Skills", SecondaryAbility = "Super Strength", Catchprase = "Aphrodite Aid me!" }
                );
            context.SaveChanges();
        }
    }
}
