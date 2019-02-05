using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces;

namespace Senai.HRoads.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadesRepositorio _HabilidadesRepositorio;

        public HabilidadesController(IHabilidadesRepositorio HabilidadesRepositorio_)
        {
            _HabilidadesRepositorio = HabilidadesRepositorio_;
        }

        // GET: api/habilidades
        /// <summary>
        /// Retorna todos as Habilidades Cadastradas
        /// </summary>
        /// <returns>Objeto contedo valores das Habilidades cadastradas</returns>
        /// <response code="200">Retorna as Habilidades se Ok</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_HabilidadesRepositorio.Listar().ToList());
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // GET: api/habilidades/5
        /// <summary>
        /// Busca uma habilidade pelo seu Id
        /// </summary>
        /// <param name="id">Valor da Habilidade que deseja obter os Dados</param>
        /// <returns>Retorna um objeto com a classe buscada</returns>
        /// <response code="200">Retorna a Habilidade se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                HabilidadesDominio Habilidades = _HabilidadesRepositorio.BuscarPorId(id);

                if (Habilidades == null)
                    return NotFound("Id inválido");

                return Ok(Habilidades);
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // POST: api/habilidades
        /// <summary>
        /// Insere um nova Habilidade
        /// </summary>
        /// <param name="dados">Dados da Habilidade</param>
        /// <returns>Retorna Ok caso a Habilidade tenha sido criado</returns>
        /// <response code="200">Retorna o texto se Ok</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpPost]
        public ActionResult Post([FromBody] HabilidadesDominio dados)
        {
            try
            {
                _HabilidadesRepositorio.Inserir(dados);

                return Ok("Habilidade criada");
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // PUT: api/habilidades/5
        /// <summary>
        /// Atualiza uma habilidade
        /// </summary>
        /// <param name="id">Id da Habilidade</param>
        /// <param name="dados">Dados da Habilidade que será alterada</param>
        /// <returns>Retorna mensagem informando que a Habilidade foi atualizada</returns>
        /// <response code="200">Retorna mensagem se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] HabilidadesDominio dados)
        {
            try
            {
                HabilidadesDominio Habilidades = _HabilidadesRepositorio.BuscarPorId(id);

                if (Habilidades == null)
                    return NotFound("Id inválido");

                _HabilidadesRepositorio.Atualizar(dados);

                return Ok("Habilidade atualizada");
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // DELETE: api/habilidades/5
        /// <summary>
        /// Exclui um habilidade
        /// </summary>
        /// <param name="id">Id da Habilidade</param>
        /// <returns>Retorna mensagem informando que a Habilidade foi excluída</returns>
        /// <response code="200">Retorna mensagem se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                HabilidadesDominio Habilidades = _HabilidadesRepositorio.BuscarPorId(id);

                if (Habilidades == null)
                    return NotFound("Id inválido");

                _HabilidadesRepositorio.Excluir(id);

                return Ok("Habilidade excluída");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}