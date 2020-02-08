
namespace Locadora.Models
{
    using Locadora.Entities;

    public interface IEntityView<T> where T : BaseEntity
    {
        void SetEntity(T entity);


        /// <summary>
        /// Converte para Entity do EF 
        /// </summary>
        /// <returns>Entidade do EF</returns>
        T ToEntity();
    }
}
