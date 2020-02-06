namespace Locadora.Service.Services
{
    using Locadora.Infra.Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using Locadora.Entities;
    using Locadora.Infra.Data.Context;

    /// <summary>
    /// Cliente Service (Interno)
    /// </summary>
    public class ClienteService : BaseService<Cliente>
    {
        /// <summary>
        /// Repositório
        /// </summary>
        public readonly BaseRepository<Cliente> repository;

        /// <summary>
        /// Context
        /// </summary>
        private readonly LocadoraContext context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repository">BaseRepository<Cliente></param>
        public ClienteService(BaseRepository<Cliente> repository) : base(repository)
        {
            this.repository = repository;
            this.context = this.repository.context;
        }

        /// <summary>
        /// Atualizar Cliente
        /// </summary>
        /// <param name="usuario">objeto do tipo Cliente</param>
        /// <returns>Retorna o objeto do tipo Cliente</returns>
        public override Cliente Update(Cliente cliente)
        {
            this.context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            this.context.SaveChanges();
            return cliente;
        }

        /// <summary>
        /// Selecionar Cliente por identificador
        /// </summary>
        /// <param name="id">identificador do cliente</param>
        /// <returns>Retorna um objeto do tipo Cliente</returns>
        public override Cliente SelectById(long id)
        {
            var cliente = repository.SelectById(id);

            if (cliente != null && cliente.Id > 0)
            {
                return cliente;
            }
            else
            {
                return new Cliente();
            }
        }

        /// <summary>
        /// Obter Cliente
        /// </summary>
        /// <remarks>
        /// Obtêm as clientes de acordo com a configuração da pagina
        /// </remarks>
        /// <param name="pesquisa">termo da pesquisa</param>
        /// <param name="pagina">página inicial</param>
        /// <param name="totaLinhas">total de registros</param>
        /// <returns>Retorna uma lista de clientes</returns>
        public List<Cliente> ListarPorPagina(string pesquisa, int? pagina, int? totaLinhas)
        {
            totaLinhas = totaLinhas ?? 10;

            int linhasParaPular = (pagina - 1 ?? 0) * (totaLinhas ?? 10);

            IQueryable<Cliente> query = context.Clientes;

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                query = query
                  .Where(x => x.Nome.ToLower().Contains(pesquisa)) 
                  .OrderBy(x => x.Nome)
                  .Skip(linhasParaPular);
            }
            else
            {
                query = query
                   .OrderBy(x => x.Nome)
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