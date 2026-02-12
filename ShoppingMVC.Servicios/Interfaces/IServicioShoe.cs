using ShoppingMVC.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMVC.Servicios.Interfaces
{
    public interface IServicioShoe
    {
        void Delete(Shoe shoe);
        void Guardar(Shoe shoe);
        bool Existe(Shoe shoe);
        int GetCantidad(Expression<Func<Shoe, bool>>? filtro);

        Shoe? Get(Expression<Func<Shoe, bool>>? filter = null,
                     string? propertiesNames = null, 
                     bool tracked = true);

        IEnumerable<Shoe>? GetAll(Expression<Func<Shoe, bool>>? filtro = null,
                            Func<IQueryable<Shoe>, IOrderedQueryable<Shoe>>? orderBy = null,
                            string? propertiesNames= null);







    }
}
