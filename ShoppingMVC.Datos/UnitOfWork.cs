using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMVC.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingMvcDbContext _context; // variable DbContext

        private  IDbContextTransaction _transaction;  //variable  transaccion


        public UnitOfWork(ShoppingMvcDbContext context)
        {
            _context = context; // lleno la variable DbContext 
        }

        public void BeginTransaction() // inicia transaccion
        {
            _transaction = _context.Database.BeginTransaction(); // lleno la variable transaccion, con el estado de inicio (confirma o revierte)
        }

        public void Commit() // confirmar
        {
            try                 // intenta
            {
                SaveChange();   // guardar los cambios
                                // si funciona bien
               
                _transaction?.Commit(); //_transaction, confirma
            }
            catch (Exception)        // si hay una excepcion
            {
                Rollback();         // volve para atras

                throw;              //lanza una excepcion
            }
        }

        public void Rollback()
        {
            _transaction.Rollback(); // vuelve para atras
        }

        public int SaveChange()
        {
            return _context.SaveChanges();
        }
    }
}
