namespace Locadora.Service.Services
{
    using Locadora.Entities;
    using Locadora.Infra.Data.Context;
    using Locadora.Infra.Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Filme Service (Interno)
    /// </summary>
    public class FilmeService : BaseService<Filme>
    {
        /// <summary>
        /// Repositório
        /// </summary>
        private readonly BaseRepository<Filme> repository;

        /// <summary>
        /// Context
        /// </summary>
        private readonly LocadoraContext context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repository">BaseRepository<Filme></param>
        public FilmeService(BaseRepository<Filme> repository) : base(repository)
        {
            this.repository = repository;
            this.context = this.repository.context;
        }

        /// <summary>
        /// Atualizar Filme
        /// </summary>
        /// <param name="Locacao">objeto do tipo Filme</param>
        /// <returns>Retorna o objeto do tipo Filme</returns>
        public override Filme SelectById(long id)
        {
            return this.context
                .Filmes
                .Where(e => e.Id == id)
                .SingleOrDefault();
        }

        /// <summary>
        /// Obter Filme
        /// </summary>
        /// <remarks>
        /// Obtêm os filmes de acordo com a configuração da pagina
        /// </remarks>
        /// <param name="pesquisa">termo da pesquisa</param>
        /// <param name="pagina">página inicial</param>
        /// <param name="totaLinhas">total de registros</param>
        /// <returns>Retorna uma lista de filmes</returns>
        public List<Filme> ListarPorPagina(string pesquisa, int? pagina, int? totaLinhas)
        {
            totaLinhas = totaLinhas ?? 10;

            int linhasParaPular = (pagina - 1 ?? 0) * (totaLinhas ?? 10);

            IQueryable<Filme> query = context.Filmes;

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                query = query
                  .Where(x => x.Descricao.ToLower().Contains(pesquisa))
                  .Skip(linhasParaPular);
            }
            else
            {
                query = query
                   .Skip(linhasParaPular);
            }

            if (totaLinhas != 0)
            {
                query = query.Take(totaLinhas ?? 10);
            }
            return query.AsNoTracking().ToList();
        }
    }
}
