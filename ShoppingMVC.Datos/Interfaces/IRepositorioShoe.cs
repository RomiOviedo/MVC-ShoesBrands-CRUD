using ShoppingMVC.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMVC.Datos.Interfaces
{
    public interface IRepositorioShoe:IRepositorioGenerico<Shoe>
    {
        void Editar(Shoe shoe);
        int GetCantidad(Expression<Func<Shoe, bool>>? filtro);
        bool Existe(Shoe? shoe); 

    }
}
