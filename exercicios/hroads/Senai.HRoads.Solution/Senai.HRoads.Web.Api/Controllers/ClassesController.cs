using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces;

namespace Senai.HRoads.Web.Api.Controllers
{
    [Route("api/classes")]
    [ApiController]
    public class ClassesController : ControllerBase
    {

        private IClassesRepositorio _classesRepositorio;

        public ClassesController(IClassesRepositorio classesRepositorio_)
        {
            _classesRepositorio = classesRepositorio_;
        }

        // GET: api/Classes
        /// <summary>
        /// Retorna todas as classes cadastradas
        /// </summary>
        /// <returns>Objeto contedo valores das classes cadastradas</returns>
        /// <response code="200">Retorna as Classes se Ok</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_classesRepositorio.Listar().ToList());
            }
            catch (System.Exception ex)
            {

                return BadRequest( new { mensagem = ex.Message });
            }
        }

        // GET: api/Classes/5
        /// <summary>
        /// Busca uma classe pelo seu Id
        /// </summary>
        /// <param name="id">Valor da classe que deseja obter os Dados</param>
        /// <returns>Retorna um objeto com a classe buscada</returns>
        /// <response code="200">Retorna a Classe se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                ClassesDominio classes = _classesRepositorio.BuscarPorId(id);

                if(classes == null)
                    return NotFound("Id inválido");

                return Ok(classes);
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // POST: api/Classes
        /// <summary>
        /// Insere uma nova classe
        /// </summary>
        /// <param name="dados">Dados da Classe</param>
        /// <returns>Retorna Ok caso a classe tenha sido criada</returns>
        /// <response code="200">Retorna o texto se Ok</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpPost]
        public ActionResult Post([FromBody] ClassesDominio dados)
        {
            try
            {
                _classesRepositorio.Inserir(dados);

                return Ok("Classe criada");
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // PUT: api/Classes/5
        /// <summary>
        /// Atualiza uma classe
        /// </summary>
        /// <param name="id">Id da classe</param>
        /// <param name="dados">Dados da classe que será alterada</param>
        /// <returns>Retorna mensagem informando que a classe foi atualizada</returns>
        /// <response code="200">Retorna mensagem se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ClassesDominio dados)
        {
            try
            {
                ClassesDominio classes = _classesRepositorio.BuscarPorId(id);

                if (classes == null)
                    return NotFound("Id inválido");

                _classesRepositorio.Atualizar(dados);

                return Ok("Classe atualizada");
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // DELETE: api/Classes/5
        /// <summary>
        /// Exclui uma classe
        /// </summary>
        /// <param name="id">Id da classe</param>
        /// <returns>Retorna mensagem informando que a classe foi excluída</returns>
        /// <response code="200">Retorna mensagem se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                ClassesDominio classes = _classesRepositorio.BuscarPorId(id);

                if (classes == null)
                    return NotFound("Id inválido");

                _classesRepositorio.Excluir(id);

                return Ok("Classe excluída");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
