using Prueba.DataAccess.Class;
using Prueba.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Prueba.BusinessLogic.Class
{
    public class DeportistaModalidadBL : IDisposable
    {
        private UnitOfWork UnitOfWork = new UnitOfWork();

        private Repository<DeportistaModalidad> DeportistaModalidadRepository;
        private Repository<Deportista> DeportistaRepository;

        public DeportistaModalidadBL()
        {
            DeportistaModalidadRepository = UnitOfWork.Repository<DeportistaModalidad>();
            DeportistaRepository = UnitOfWork.Repository<Deportista>();
        }

        public DeportistaModalidad Create(DeportistaModalidad deportistaModalidad)
        {
            DeportistaModalidad deportistaModalidadCreate = new DeportistaModalidad();
            try
            {
                using (DbContextTransaction transaction = UnitOfWork.GetContext().Database.BeginTransaction())
                {
                    try
                    {
                        deportistaModalidadCreate = deportistaModalidad;
                        DeportistaModalidadRepository.Create(deportistaModalidadCreate);
                        UnitOfWork.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }

                }

                Find(deportistaModalidadCreate);
                return deportistaModalidadCreate;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Find(DeportistaModalidad deportistaModalidadCreate)
        {
            List<Deportista> ListDeportistas = new List<Deportista>();
            ListDeportistas = DeportistaRepository.Find(d => d.Name.Contains("a")).ToList();
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
