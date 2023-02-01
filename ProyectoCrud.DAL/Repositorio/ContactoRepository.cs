using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositorio
{
    public class ContactoRepository : IGenericRepository<Contacto>
    {
        private readonly CrudContext _crudContext;
        public ContactoRepository(CrudContext context) {

            _crudContext = context;

        } 
        public async Task<bool> Actualizar(Contacto modelo)
        {
            _crudContext.Contactos.Update(modelo);
            await _crudContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
           Contacto modelo  = _crudContext.Contactos.First(c => c.IdContacto== id);
            _crudContext.Contactos.Remove(modelo);
            await _crudContext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Insertar(Contacto modelo)
        {
            _crudContext.Contactos.Add(modelo);
            await _crudContext.SaveChangesAsync();
                return true;
        }

        public async Task<Contacto> Obtener(int id)
        {
            return await _crudContext.Contactos.FindAsync(id);
        }

        public async Task<IQueryable<Contacto>> ObtenerTodos()
        {
            IQueryable<Contacto> queryContactoSQL = _crudContext.Contactos;
            return queryContactoSQL;
        }
    }
}
