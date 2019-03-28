using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHome.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Infrastructure.Maps
{
    /// <summary>
    /// Définition de la manière dont la classe House sera "mappée" en base de données
    /// </summary>
    public class HouseMap : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.ToTable(nameof(House)); // Nom de la table
            builder.HasKey(x => x.Id); // Définition de la PK
            builder.Property(x => x.Name) // Champ nom 
                .IsRequired() // La valeur est obligatoire "NOT NULL"
                .HasMaxLength(50); // Longueur max "VARCHAR(50)"

            builder.HasMany(x => x.Rooms) // 1 maison = n pièces
                .WithOne(x => x.House) // 1 pièce = 1 maison
                .HasForeignKey(x => x.HouseId) // Contrainte de FK
                .OnDelete(DeleteBehavior.Cascade); // Suppression des pièces en cascade en cas de suppression de la maison

            // Création d'un index unique
            // Rappel : interdiction d'avoir 2 maisons qui portent le même nom
            builder.HasIndex(x => new { x.Name })
                .IsUnique(); // Cet index est unique

            // Insertion d'une première maison
            builder.HasData(new House()
            {
                Id = 1,
                Name = "Résidence principale"
            });
        }
    }
}
