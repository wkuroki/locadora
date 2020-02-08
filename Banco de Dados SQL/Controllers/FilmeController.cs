namespace Locadora.Filmes.SPA.Controllers
{
    using Locadora.Entities;
    using Locadora.Service.Services;
    using Locadora.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : Controller
    {
        /// <summary>
        /// Repositório de dados
        /// </summary>
        private readonly FilmeService filmeService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repository">Repositório de dados</param>
        public FilmeController(FilmeService repository)
        {
            this.filmeService = repository;
        }

        /// <summary>
        /// Salvar Filme
        /// </summary>
        /// <remarks>
        /// Inclusão/Alteração do Filme
        /// </remarks>
        /// <param name="filme">FilmeView</param>
        /// <returns>Retorna o identificador do Filme</returns>
        [HttpPost("FromBody")]
        [Route("[action]")]
        public JsonResult Salvar(FilmeView filme)
        {
            Filme model = filme.ToFilme();

            if (model.Id > 0)
            {
                filmeService.Update(model);
            }
            else
            {
                filmeService.Insert(model);
            }

            return Json(model.Id);
        }

        /// <summary>
        /// Excluir Filme
        /// </summary>
        /// <remarks>
        /// Exclusão do Filme
        /// </remarks>
        /// <param name="id">identificador do Filme</param>
        /// <returns>Retorna OK</returns>
        [HttpDelete()]
        [Route("[action]")]
        public ActionResult Excluir(long id)
        {
            filmeService.Delete(id);
            return Ok(id);
        }

        /// <summary>
        /// Obter Filme
        /// </summary>
        /// <remarks>
        /// Obtêm os filmes com a configuração da pagina
        /// </remarks>
        /// <param name="pesquisa">termo da pesquisa</param>
        /// <param name="pagina">página inicial</param>
        /// <param name="totaLinhas">total de registros</param>
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult ListarFilmesPorPagina(string pesquisa, int? pagina, int? totaLinhas)
        {
            var registros = filmeService.ListarPorPagina(pesquisa, pagina, totaLinhas);

            var filmes = new
            {
                filmess = registros.Select(e => new FilmeView(e)).ToList(),
                totalLinhas = filmeService.RowsCount()
            };

            return Json(filmes);
        }

        /// <summary>
        /// Obter Filme
        /// </summary>
        /// <remarks>
        /// Obtêm os filmes de acordo com identificador
        /// </remarks>
        /// <param name="id">identificador do Filme</param>
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult ListarFilmePorId(long id)
        {
            Filme model = filmeService.SelectById(id) ?? new Filme();

            return Json(new FilmeView(model));
        }

    }
}