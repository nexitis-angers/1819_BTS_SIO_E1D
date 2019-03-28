using Microsoft.EntityFrameworkCore;
using MyHome.Infrastructure.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Infrastructure
{
    public class MyHomeDbContext : DbContext
    {
        public MyHomeDbContext(DbContextOptions<MyHomeDbContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// On indique au contexte de bdd quelles classes devront être transformées en tables dans la bdd
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new HouseMap());
            modelBuilder.ApplyConfiguration(new RoomMap());
        }
    }
}
