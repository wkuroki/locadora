namespace Locadora.SPA.Controllers
{
    using Locadora.Entities;
    using Locadora.Service.Services;
    using Locadora.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        /// <summary>
        /// Repositório de dados
        /// </summary>
        private readonly ClienteService clienteService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="clienteService">Repositório de dados</param>
        public ClienteController(ClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        /// <summary>
        /// Salvar Cliente
        /// </summary>
        /// <remarks>
        /// Inclusão/Alteração do cliente
        /// </remarks>
        /// <param name="cliente">ClienteView</param>
        /// <returns>Retorna o identificador do cliente</returns>
        [HttpPost("FromBody")]
        [Route("[action]")]
        public ActionResult Salvar(ClienteView cliente)
        {
            Cliente model = cliente.ToCliente();

            if (model.Id > 0)
            {
                clienteService.Update(model);
            }
            else
            {
                clienteService.Insert(model);
            }

            return Ok(model.Id);
        }
        
        /// <summary>
        /// Excluir Cliente
        /// </summary>
        /// <remarks>
        /// Exclusão do cliente
        /// </remarks>
        /// <param name="id">identificador do Cliente</param>
        /// <returns>Retorna OK</returns>
        [HttpDelete()]
        [Route("[action]")]
        public ActionResult Excluir(long id)
        {
            clienteService.Delete(id);
            return Ok(id);
        }
        
        /// <summary>
        /// Obter Cliente
        /// </summary>
        /// <remarks>
        /// Obtêm os clientes de acordo com o limite de registros
        /// </remarks>
        /// <param name="limite">limte de registros</param>
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult ListarClientes(int limite)
        {
            var registros = clienteService.ListarPorPagina(string.Empty, null, limite);
            return Json(registros.Select(e => new ClienteView(e)).ToList());
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
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult ListarClientesPorPagina(string pesquisa, int? pagina, int? totaLinhas)
        {
            var registros = clienteService.ListarPorPagina(pesquisa, pagina, totaLinhas);

            var clientes = new
            {
                clientes = registros.Select(e => new ClienteView(e)).ToList(),
                totalLinhas = clienteService.RowsCount()
            };


            return Json(clientes);
        }
        
        /// <summary>
        /// Obter Cliente por ID
        /// </summary>
        /// <remarks>
        /// Obtêm os clientes de acordo com o Identificador
        /// </remarks>
        /// <param name="id">identificador da Empresa</param>
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult ListarClientePorId(long id)
        {
            Cliente model = clienteService.SelectById(id) ?? new Cliente();

            return Json(new ClienteView(model));
        }
        
    }
}
