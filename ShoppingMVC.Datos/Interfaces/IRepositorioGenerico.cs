using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMVC.Datos.Interfaces
{
    public interface IRepositorioGenerico<T> where T : class
    {
        IEnumerable<T> GetAll(

            Expression<Func<T, bool>>? filter = null,               // var clientesActivos=repo.GetAll(c=>c.activo==true); | where activo =1

            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy= null,  //var clientesOrdenados= repo.GetAll(orderBy:q => q.OrderBy(c=> c.Nombre))

            string? propertiesname = null                       //para incluir prop de navegacion(relaciones) con LazyLoading = .Include()
                                                                //si un producto tiene una prop TipoPlanta, puedo edir q se incluya el nombre d la prop
                                                                
                                                                // var product= repo.GetAll(propertiesName:("TipoDePlanta, Proveedor");

                                                                //_dbContext.Product.Include(TipoDePlanta).Include("Proveedor");

            );


        T? Get(

             Expression<Func<T, bool>>? filter = null,
             string? propertiesname = null,
             bool traked = true


            );

        void Add(T entity);



        void Delete(T entity);



    }
}
