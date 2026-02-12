using ShoppingMVC.Datos.Repositorios;
using ShoppingMVC.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMVC.Datos.Interfaces
{
    public interface IRepositorioBrand:IRepositorioGenerico<Brand>
    {
        void Update(Brand brand);
        bool Existe(Brand brand);
        bool EstaRelacionado(int id);

    }
}
