using ShoppingMVC.Datos;
using ShoppingMVC.Datos.Interfaces;
using ShoppingMVC.Datos.Repositorios;
using ShoppingMVC.Entidades;
using ShoppingMVC.Servicios.Interfaces;
using System.Linq.Expressions;

namespace ShoppingMVC.Servicios.Servicios
{

    public class ServicioBrand : IServicioBrand
    {

        private readonly IRepositorioBrand _repo;
        private readonly IUnitOfWork _unitOfWork;


        public ServicioBrand(IRepositorioBrand repo, IUnitOfWork unitOfWork)
        {

            //?? si llega a ser nulo, lanza una excepcion, no continues. proporciona un valor por defecto en el caso q la variable sea null
            _repo = repo?? throw new ArgumentNullException(nameof(repo));// dependencias no encontradas
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork)); 

        }
        public void Delete(Brand entity)
        {
            try
            {
                _unitOfWork.BeginTransaction(); // inicia la transaccion
                _repo.Delete(entity);           // si esta todo ok, borra
                _unitOfWork.Commit();           // confirma el cambio
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();         // si algo no funciono , volve para atras
                throw;                          // lanza la excepcion q lo origino
            }
            
        }

        public bool EstaRelacionado(int id)
        {
            return _repo.EstaRelacionado(id);
        }

        public bool Existe(Brand brand)
        {
            return _repo.Existe(brand);
        }

        public Brand? Get(Expression<Func<Brand, bool>>? filter = null, string? propertiesname = null, bool traked = true)
        {
            return _repo.Get(filter, propertiesname, traked);
        }

        public IEnumerable<Brand> GetAll(Expression<Func<Brand, bool>>? filter = null, Func<IQueryable<Brand>, IOrderedQueryable<Brand>>? orderBy = null, string? propertiesname = null)
        {
            return _repo.GetAll(filter, orderBy, propertiesname);
        }

        public void Save(Brand entity)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (entity.BrandId == 0)
                {
                    _repo.Add(entity);
                }
                _repo.Update(entity);

                _unitOfWork.Commit();  // guarda los cambios y confirma la transaccion 

            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;                  // lanza la exepcion ocurrida en tiempo de ejecucion 
            }            
        }
    }
}
