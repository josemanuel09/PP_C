using Microsoft.EntityFrameworkCore;
using PP_C.DAL;
using PP_C.Models;
using System.Linq.Expressions;

namespace PP_C.Services
{
    public class ProductoServices
    {
        private readonly Contexto _contexto;
        public ProductoServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Guardar(Productos producto)
        {
            if (!await Existe(producto.ProductoId))
                return await Insertar(producto);
            else
                return await Modificar(producto);
        }

        public async Task<bool> Insertar(Productos producto)
        {
            _contexto.Productos.Add(producto);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Modificar(Productos producto)
        {
            _contexto.Productos.Update(producto);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Existe(int id)
        {
            return await _contexto.Productos.AnyAsync(p => p.ProductoId == id);
        }
        public async Task<bool> Eliminar(int id)
        {
            var productos = await _contexto.Productos
                .Where(p=> p.ProductoId == id).ExecuteDeleteAsync();
            return productos > 0;
        }
        public async Task<Productos> Buscar(int id)
        {
            return await _contexto.Productos.
                AsNoTracking().
                FirstOrDefaultAsync(p => p.ProductoId == id);
        }
        public List<Productos> Listar(Expression<Func<Productos, bool>> criterio)
        {
            return _contexto.Productos.
                AsNoTracking().
                Where(criterio).ToList();
        }

    }
}
