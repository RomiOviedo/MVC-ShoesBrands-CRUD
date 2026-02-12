namespace ShoppingMVC.Datos
{
    public interface IUnitOfWork
    {
        void BeginTransaction(); // inicio de transaccion
        void Commit(); //Confirmar
        void Rollback();
        int SaveChange();
    }
}
