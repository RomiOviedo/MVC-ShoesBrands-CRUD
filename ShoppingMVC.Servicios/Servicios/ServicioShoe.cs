using ShoppingMVC.Datos;
using ShoppingMVC.Datos.Interfaces;
using ShoppingMVC.Entidades;
using ShoppingMVC.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMVC.Servicios.Servicios
{
    public class ServicioShoe : IServicioShoe
    {
        private readonly IRepositorioShoe _repo;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioShoe(IRepositorioShoe repo, IUnitOfWork unitOfWork )
        {
         _repo= repo?? throw new ArgumentNullException(nameof(repo));
         _unitOfWork=unitOfWork?? throw new ArgumentNullException(nameof(unitOfWork));
        }




        public void Delete(Shoe shoe)
        {
            _unitOfWork.BeginTransaction(); // inicia la transaccion
            _repo.Delete(shoe);
            _unitOfWork.Commit();           // confirma el cambio


        }

        public bool Existe(Shoe shoe)
        {
            return _repo.Existe(shoe);
        }

        public Shoe? Get(Expression<Func<Shoe, bool>>? filter = null, string? propertiesNames = null, bool tracked = true)
        {
            return _repo.Get(filter, propertiesNames, tracked);
        }

        public IEnumerable<Shoe>? GetAll(Expression<Func<Shoe, bool>>? filtro = null, Func<IQueryable<Shoe>, IOrderedQueryable<Shoe>>? orderBy = null, string? propertiesNames = null)
        {
           return _repo.GetAll(filtro, orderBy,propertiesNames);
        }

        public int GetCantidad(Expression<Func<Shoe, bool>>? filtro)
        {
            return _repo.GetCantidad(filtro);
        }


        public void Guardar(Shoe shoe)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                if (shoe.ShoeId == 0)
                {
                    _repo.Add(shoe);
                }
                else
                {
                    _repo.Editar(shoe);
                }
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
