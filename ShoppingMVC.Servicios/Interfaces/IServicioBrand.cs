using ShoppingMVC.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMVC.Servicios.Interfaces
{
    public interface IServicioBrand
    {
        IEnumerable<Brand> GetAll(

                            Expression<Func<Brand, bool>>? filter = null,               
                            Func<IQueryable<Brand>, IOrderedQueryable<Brand>>? orderBy = null,  
                            string? propertiesname = null                       
                            );


        Brand? Get(

                     Expression<Func<Brand, bool>>? filter = null,
                     string? propertiesname = null,
                     bool traked = true
                    );

        void Save(Brand entity);



        void Delete(Brand entity);

        bool Existe(Brand brand);
        bool EstaRelacionado(int id);



    }
}
