using System.Collections.Generic;

namespace CapaModelo_protipoumg26.Contratos
{
    public interface IRepositorioGenerico<Entity> where Entity : class
    {
        int Agregar(Entity entidad);
        int Editar(Entity entidad);
        int Remover(Entity entidad);
        IEnumerable<Entity> GetAll();
    }
}
