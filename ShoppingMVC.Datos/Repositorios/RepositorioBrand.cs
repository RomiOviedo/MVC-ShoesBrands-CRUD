using ShoppingMVC.Datos.Interfaces;
using ShoppingMVC.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMVC.Datos.Repositorios
{
    public class RepositorioBrand : RepositorioGenerico<Brand>, IRepositorioBrand
    {

        private ShoppingMvcDbContext _db;
        public RepositorioBrand(ShoppingMvcDbContext db) : base(db)
        {
            _db = db;
        }

        public bool EstaRelacionado(int id)
        {
            return _db.Shoes.Any(s => s.BrandId == id);
        }

        public bool Existe(Brand brand)
        {
            if (brand.BrandId == 0)
            {
                return _db.Brands.Any(b => b.BrandName == brand.BrandName);
            }
            return _db.Brands.Any(b => b.BrandName == brand.BrandName && b.BrandId !=brand.BrandId);
        }

        public void Update(Brand brand)
        {
            var brandInDb = _db.Brands.FirstOrDefault(b => b.BrandId == brand.BrandId);


            if(brandInDb==null)return; // no existe

            if (Existe(brand)) return; // ya existe una brand con ese name . NO DUPLICO NAMES
            if (EstaRelacionado(brand.BrandId)) return; //SI QUIERO MODIFICAR UNA BRAND RELACIONADA, NO LO PERMITO

            brandInDb.BrandName = brand.BrandName;

            _db.SaveChanges();
        }
    }
}
