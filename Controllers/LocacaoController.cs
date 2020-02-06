 namespace Locadora.SPA.Controllers
{
    using Locadora.Entities;
    using Locadora.Service.Services;
    using Locadora.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : Controller
    {
        /// <summary>
        /// Repositório de dados
        /// </summary>
        private readonly Locacaoervice Locacaoervice;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="Locacaoervice">Repositório de dados</param>
        public LocacaoController(Locacaoervice Locacaoervice)
        {
            this.Locacaoervice = Locacaoervice;
        }

        /// <summary>
        /// Salvar Locacao
        /// </summary>
        /// <remarks>
        /// Inclusão/Alteração do Locacao
        /// </remarks>
        /// <param name="Locacao">LocacaoView</param>
        /// <returns>Retorna o identificador do Locacao</returns>
        [HttpPost("FromBody")]
        [Route("[action]")]
        public JsonResult Salvar(LocacaoView Locacao)
        {
            Locacao model = Locacao.ToLocacao();

            if (model.Id > 0)
            {
                Locacaoervice.Update(model);
            }
            else
            {
                Locacaoervice.Insert(model);
            }

            return Json(model.Id);
        }

        /// <summary>
        /// Excluir Locacao
        /// </summary>
        /// <remarks>
        /// Exclusão do Locacao
        /// </remarks>
        /// <param name="id">identificador do Locacao</param>
        /// <returns>Retorna OK</returns>
        [HttpDelete()]
        [Route("[action]")]
        public ActionResult Excluir(long id)
        {
            Locacaoervice.Delete(id);
            return Ok(id);
        }

        /// <summary>
        /// Obter Locacao
        /// </summary>
        /// <remarks>
        /// Obtêm os Locacao de acordo com o limite de registros
        /// </remarks>
        /// <param name="limite">limte de registros</param>
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult ListarLocacao(int limite)
        {
            var registros = Locacaoervice.ListarPorPagina(string.Empty, null, limite);
            return Json(registros.Select(e => new LocacaoView(e)).ToList());
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
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult ListarLocacaoPorPagina(string pesquisa, int? pagina, int? totaLinhas)
        {
            var registros = Locacaoervice.ListarPorPagina(pesquisa, pagina, totaLinhas);

            var Locacao = new
            {
                Locacao = registros.Select(e => new LocacaoView(e)).ToList(),
                totalLinhas = Locacaoervice.RowsCount()
            };

            return Json(Locacao);
        }

        /// <summary>
        /// Obter Locacao
        /// </summary>
        /// <remarks>
        /// Obtêm os Locacao de acordo com o Identificador
        /// </remarks>
        /// <param name="id">identificador do Locacao</param>
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult ListarLocacaoPorId(long id)
        {
            Locacao model = Locacaoervice.SelectById(id) ?? new Locacao();

            return Json(new LocacaoView(model));
        }

    }

}
