using System.Collections.Generic;

namespace Model.Repository
{
    public interface IGenericRepository<T> where T : class, new()
    {
        /// <summary>
        /// Inserta una nueva entidad en el repositorio de datos
        /// </summary>
        /// <param name="entity">Entidad a insertar</param>
        /// <returns>Entidad insertada</returns>
        T Insert(T entity);

        /// <summary>
        /// Actualiza una entidad en el repositorio de datos
        /// </summary>
        /// <param name="entity">Entidad a actualizar</param>
        /// <returns>Entidad actualizada</returns>
        void Update(T entity);

        /// <summary>
        /// Elimina una entidad en el repositorio de datos
        /// </summary>
        /// <param name="entity">Entidad a eliminar</param>
        /// <returns>Entidad eliminada</returns>
        void Delete(int id);
        /// <summary>
        /// Obtiene uno por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);
        /// <summary>
        /// Obtiene todos los empleados del repositorio de datos
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> List();
    }
}
