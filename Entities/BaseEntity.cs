namespace Locadora.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class BaseEntity
    {

        public virtual long Id { get; set; }

        [NotMapped]
        public virtual bool Excluido { get; set; }
    }
}
