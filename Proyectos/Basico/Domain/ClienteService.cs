using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ClienteService
    {
        public void Add(Cliente entity)
        {
            using var context = new ClienteContext();
            context.Clientes.Add(entity);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            using var context = new ClienteContext();
            Cliente? entityToDelete = context.Clientes.Find(id);
            if (entityToDelete != null)
            {
                context.Clientes.Remove(entityToDelete);
                context.SaveChanges();
            }
        }
        public Cliente? Get(int id)
        {
            using var context = new ClienteContext();
            return context.Clientes.Find(id);
        }
        public IEnumerable<Cliente> GetAll()
        {
            using var context = new ClienteContext();
            return context.Clientes.ToList();
        }
        public void Update(Cliente entity)
        {
            using var context = new ClienteContext();
            Cliente? entityToUpdate = context.Clientes.Find(entity.Id);
            if (entityToUpdate != null)
            {
                entityToUpdate.Nombre = entity.Nombre;
                context.SaveChanges();
            }
        }
    }
}
