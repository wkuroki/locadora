namespace Locadora.Service.Services
{
    using Locadora.Entities;
    using Locadora.Infra.Data.Context;
    using Locadora.Infra.Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Locacao Service (Interno)
    /// </summary>
    public class LocacaoService : BaseService<Locacao>
    {
        /// <summary>
        /// Repositório
        /// </summary>
        private readonly BaseRepository<Locacao> repository;

        /// <summary>
        /// Context
        /// </summary>
        private readonly LocadoraContext context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repository">BaseRepository<Locacao></param>
        public LocacaoService(BaseRepository<Locacao> repository) : base(repository)
        {
            this.repository = repository;
            this.context = this.repository.context;
        }

        /// <summary>
        /// Atualizar Locacao
        /// </summary>
        /// <param name="Locacao">Locacao</param>
        /// <returns>Retorna um objeto do tipo Locacao</returns>
        public override Locacao Update(Locacao Locacao)
        {
            this.context.Entry(Locacao).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            //Itens do Locacao
            foreach (var item in Locacao.LocacaoItems)
            {
                if (item.Excluido)
                {
                    this.context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                }
                else
                {
                    if (item.Id > 0)
                    {
                        this.context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                    else
                    {
                        this.context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                }

            }
    
   
            this.context.SaveChanges();
            return Locacao;
        }

        /// <summary>
        /// Selecionar Locacao por identificador
        /// </summary>
        /// <param name="id">identificador do Locacao</param>
        /// <returns>Retorna um objeto do tipo Locacao</returns>
        public override Locacao SelectById(long id)
        {
            return this.context
                  .Locacao
                  .Include(e => e.Clientes)
                  .Include(a => a.LocacaoItems)
                  .Where(e => e.Id == id)
                  .ToList()
                  .SingleOrDefault();
        }

        /// <summary>
        /// Obter Locacao
        /// </summary>
        /// <remarks>
        /// Obtêm os Locacao de acordo com a configuração da pagina
        /// </remarks>
        /// <param name="pesquisa">termo da pesquisa</param>
        /// <param name="pagina">página inicial</param>
        /// <param name="totaLinhas">total de registros</param>
        /// <returns>Retorna uma lista de Locaçoes</returns>
        public List<Locacao> ListarPorPagina(string pesquisa, int? pagina, int? totaLinhas)
        {
            totaLinhas = totaLinhas ?? 10;

            int linhasParaPular = (pagina - 1 ?? 0) * (totaLinhas ?? 10);

            IQueryable<Locacao> query = context.Locacao
                .Include(a => a.Clientes)
                .Include(x => x.LocacaoItems)
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(pesquisa))
            {


                    query = query
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