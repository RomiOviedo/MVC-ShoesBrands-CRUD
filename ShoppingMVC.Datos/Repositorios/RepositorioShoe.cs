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
    public class RepositorioShoe : RepositorioGenerico<Shoe> , IRepositorioShoe
    {

        private readonly ShoppingMvcDbContext _db;
        public RepositorioShoe(ShoppingMvcDbContext db) : base(db)
        {
            _db = db;
        }

        public void Editar(Shoe? shoe)  // ? puede ser null
        {
            //verificar q la Brand asociada ya existe en la bd 

            var brandExistente = _db.Brands.FirstOrDefault(b => b.BrandId == shoe!.BrandId);  //shoe! te aseguro q no es null

            // si la brand ya existe agregarla al contexto en lugar de agregarla

            if (brandExistente != null)
            {
                _db.Attach(brandExistente);  // rastrea la brand existente
                shoe!.Brand = brandExistente;  // shoe q no es null. brand => la brand del  shoe que no es null es igual a la brandExistente
            }

            _db.Shoes.Update(shoe!);


        }

        public bool Existe(Shoe? shoe)
        {
            if (shoe?.ShoeId == 0)
            {
                return _db.Shoes.Any(s => s.ShoeName == shoe.ShoeName && s.BrandId == shoe.BrandId);
            }
            return _db.Shoes.Any(s => s.ShoeName == shoe.ShoeName && s.BrandId == shoe.BrandId && s.ShoeId != shoe.ShoeId);
        }

        public int GetCantidad(Expression<Func<Shoe, bool>>? filtro)  // EXPRESION LAMBDA
        {
            if (filtro != null)
            {
                return _db.Shoes.AsQueryable().Where(filtro).Count(); // asquery= como queryable
            }
            return _db.Shoes.Count();
        }
    }
}
