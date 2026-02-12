using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingMVC.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMVC.Datos
{
    public class ShoppingMvcDbContext : DbContext
    {
        //public ShoppingMvcDbContext()
        //{
        //}
        public ShoppingMvcDbContext(DbContextOptions<ShoppingMvcDbContext> options) : base(options)
        {

        }

        //le decimos como se van a llamar las entidades transformadas en las tablas de sql

        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Brand> Brands { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Shoe>(entity =>
            {
                //nobre de la tabla
                entity.ToTable("Shoes");

                // id
                entity.HasKey(s => s.ShoeId);

                //relacion
                entity.HasOne(s=> s.Brand).WithMany(b=> b.Shoes).HasForeignKey(s=>s.BrandId);

                //propiedades
                entity.Property(p => p.ShoeName).HasColumnType("nvarchar(MAX)");
                entity.Property(p => p.Price).HasPrecision(10, 2);  
            }
            );

            builder.Entity<Brand>(entity =>
            {
                //nombre de la tabla
                entity.ToTable("Brands");

                //id
                entity.HasKey(b=>b.BrandId);

                //prop name unica
                entity.HasIndex(b => b.BrandName).IsUnique();

                //prop name maximo de caracteres 50
                entity.Property(b => b.BrandName).HasMaxLength(50);

            });
         
            

        }




    }





}
