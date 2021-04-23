namespace AnimalMatcher.Data
{
    using AnimalMatcher.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AnimalMatcherDbContext : IdentityDbContext
    {
        public AnimalMatcherDbContext(DbContextOptions<AnimalMatcherDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Owner>()
                .HasMany(owner => owner.Pets)
                .WithOne(pet => pet.Owner)
                .HasForeignKey(pet => pet.OwnerId);

            builder
                .Entity<Pet>()
                .HasMany(pet => pet.WhoYouLiked)
                .WithOne(like => like.LikedByPet)
                .HasForeignKey(like => like.LikedByPetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Pet>()
                .HasMany(pet => pet.WhoLikedYou)
                .WithOne(like => like.LikedPet)
                .HasForeignKey(like => like.LikedPetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Pet>()
                .HasMany(pet => pet.SentMessages)
                .WithOne(message => message.Sender)
                .HasForeignKey(message => message.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Pet>()
                .HasMany(pet => pet.ReceivedMessages)
                .WithOne(message => message.Recipient)
                .HasForeignKey(message => message.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Pet>()
                .HasOne(pet => pet.Location)
                .WithOne(location => location.Pet)
                .HasForeignKey<Location>(location => location.PetId);

            base.OnModelCreating(builder);
        }
    }
}
