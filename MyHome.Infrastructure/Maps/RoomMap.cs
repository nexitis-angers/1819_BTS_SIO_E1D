using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHome.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Infrastructure.Maps
{
    /// <summary>
    /// Décrit le mappage de notre class "Room" en base de données
    /// </summary>
    public class RoomMap : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable(nameof(Room)); // Nom de la table
            builder.HasKey(x => x.Id); // Définition de la PK
            builder.Property(x => x.Name)
                .IsRequired() // "NOT NULL"
                .HasMaxLength(50); // "VARCHAR(50)"

            // Index unique qui repose sur la propriété name
            builder.HasIndex(x => new { x.Name })
                .IsUnique();

            // Insertion de 2 pièces dans la maison 1
            builder.HasData(new Room()
            {
                Id = 1,
                Name = "Séjour",
                HouseId = 1
            }, new Room()
            {
                Id = 2,
                Name = "Chambre 1",
                HouseId = 1
            });


        }
    }
}
