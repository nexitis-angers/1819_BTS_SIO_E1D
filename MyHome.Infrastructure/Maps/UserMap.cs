using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHome.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Infrastructure.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Création de la table en BDD
            builder.ToTable(nameof(User));
            // Définition de la propriété Id comme clé primaire
            builder.HasKey(x => x.Id);
            // Mappage des propriétés
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(125);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(50);

            // Création d'un index, unique
            builder.HasIndex(x => new { x.Email }).IsUnique();

            // Insertion de données
            builder.HasData(new User() {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@me.com",
                Password = "000000" });
        }
    }
}
