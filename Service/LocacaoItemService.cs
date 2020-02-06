namespace Locadora.Service.Services
{
    using Locadora.Entities;
    using Locadora.Infra.Data.Repository;


    /// <summary>
    /// Item do Locacao (Interno)
    /// </summary>
    public class LocacaoItemService
    {
        /// <summary>
        /// Repositório
        /// </summary>
        public readonly BaseRepository<LocacaoItem> repository = null;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repository">BaseRepository<LocacaoItem></param>
        public LocacaoItemService(BaseRepository<LocacaoItem> repository)
        {
            this.repository = repository;
        }
    }
}