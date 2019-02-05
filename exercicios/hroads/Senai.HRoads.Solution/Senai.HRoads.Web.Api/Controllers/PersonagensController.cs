using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces;

namespace Senai.HRoads.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private IPersonagensRepositorio _PersonagensRepositorio;

        public PersonagensController(IPersonagensRepositorio PersonagensRepositorio_)
        {
            _PersonagensRepositorio = PersonagensRepositorio_;
        }

        // GET: api/personagens
        /// <summary>
        /// Retorna todos os Personagens cadastradas
        /// </summary>
        /// <returns>Objeto contedo valores dos Personagens cadastrados</returns>
        /// <response code="200">Retorna os Personagens se Ok</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_PersonagensRepositorio.Listar().ToList());
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // GET: api/personagens/5
        /// <summary>
        /// Busca um personagem pelo seu Id
        /// </summary>
        /// <param name="id">Valor do personagem que deseja obter os Dados</param>
        /// <returns>Retorna um objeto com o personagem buscada</returns>
        /// <response code="200">Retorna o personagem se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                PersonagensDominio Personagens = _PersonagensRepositorio.BuscarPorId(id);

                if (Personagens == null)
                    return NotFound("Id inválido");

                return Ok(Personagens);
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // POST: api/personagens
        /// <summary>
        /// Insere uma novo personagem
        /// </summary>
        /// <param name="dados">Dados do personagem</param>
        /// <returns>Retorna Ok caso o personagem tenha sido criada</returns>
        /// <response code="200">Retorna o texto se Ok</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpPost]
        public ActionResult Post([FromBody] PersonagensDominio dados)
        {
            try
            {
                _PersonagensRepositorio.Inserir(dados);

                return Ok("personagem criada");
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // PUT: api/personagens/5
        /// <summary>
        /// Atualiza umo personagem
        /// </summary>
        /// <param name="id">Id do personagem</param>
        /// <param name="dados">Dados do personagem que será alterada</param>
        /// <returns>Retorna mensagem informando que o personagem foi atualizado</returns>
        /// <response code="200">Retorna mensagem se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PersonagensDominio dados)
        {
            try
            {
                PersonagensDominio Personagens = _PersonagensRepositorio.BuscarPorId(id);

                if (Personagens == null)
                    return NotFound("Id inválido");

                _PersonagensRepositorio.Atualizar(dados);

                return Ok("personagem atualizada");
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // DELETE: api/personagens/5
        /// <summary>
        /// Exclui um personagem
        /// </summary>
        /// <param name="id">Id do personagem</param>
        /// <returns>Retorna mensagem informando que o personagem foi excluída</returns>
        /// <response code="200">Retorna mensagem se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                PersonagensDominio Personagens = _PersonagensRepositorio.BuscarPorId(id);

                if (Personagens == null)
                    return NotFound("Id inválido");

                _PersonagensRepositorio.Excluir(id);

                return Ok("personagem excluída");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}