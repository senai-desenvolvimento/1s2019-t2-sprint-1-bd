using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces;

namespace Senai.HRoads.Web.Api.Controllers
{
    [Route("api/tiposhabilidades")]
    [ApiController]
    public class TiposHabilidadesController : ControllerBase
    {
        private ITiposHabilidadesRepositorio _TiposHabilidadesRepositorio;

        public TiposHabilidadesController(ITiposHabilidadesRepositorio TiposHabilidadesRepositorio_)
        {
            _TiposHabilidadesRepositorio = TiposHabilidadesRepositorio_;
        }

        // GET: api/TiposHabilidades
        /// <summary>
        /// Retorna todos os Tipos de Habilidades Cadastradas
        /// </summary>
        /// <returns>Objeto contedo valores dos Tipos de Habilidades cadastradas</returns>
        /// <response code="200">Retorna os Tipos de Habilidades se Ok</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_TiposHabilidadesRepositorio.Listar().ToList());
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // GET: api/TiposHabilidades/5
        /// <summary>
        /// Busca um tipo de habilidade pelo seu Id
        /// </summary>
        /// <param name="id">Valor do tipo de habilidade que deseja obter os Dados</param>
        /// <returns>Retorna um objeto com a classe buscada</returns>
        /// <response code="200">Retorna o Tipo de Habilidade se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                TiposHabilidadesDominio TiposHabilidades = _TiposHabilidadesRepositorio.BuscarPorId(id);

                if (TiposHabilidades == null)
                    return NotFound("Id inválido");

                return Ok(TiposHabilidades);
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // POST: api/TiposHabilidades
        /// <summary>
        /// Insere um novo tipo de habilidade
        /// </summary>
        /// <param name="dados">Dados do Tipo de Habilidade</param>
        /// <returns>Retorna Ok caso o tipo de habilidade tenha sido criado</returns>
        /// <response code="200">Retorna o texto se Ok</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpPost]
        public ActionResult Post([FromBody] TiposHabilidadesDominio dados)
        {
            try
            {
                _TiposHabilidadesRepositorio.Inserir(dados);

                return Ok("Tipo de Habilidade criada");
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // PUT: api/TiposHabilidades/5
        /// <summary>
        /// Atualiza um tipo de habilidade
        /// </summary>
        /// <param name="id">Id do tipo de habilidade</param>
        /// <param name="dados">Dados do tipo de habilidade que será alterada</param>
        /// <returns>Retorna mensagem informando que o tipo de habilidade foi atualizada</returns>
        /// <response code="200">Retorna mensagem se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TiposHabilidadesDominio dados)
        {
            try
            {
                TiposHabilidadesDominio TiposHabilidades = _TiposHabilidadesRepositorio.BuscarPorId(id);

                if (TiposHabilidades == null)
                    return NotFound("Id inválido");

                _TiposHabilidadesRepositorio.Atualizar(dados);

                return Ok("Tipo de Habilidade atualizada");
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // DELETE: api/TiposHabilidades/5
        /// <summary>
        /// Exclui um Tipo de habilidade
        /// </summary>
        /// <param name="id">Id do tipo de habilidade</param>
        /// <returns>Retorna mensagem informando que o tipo de habilidade foi excluída</returns>
        /// <response code="200">Retorna mensagem se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                TiposHabilidadesDominio TiposHabilidades = _TiposHabilidadesRepositorio.BuscarPorId(id);

                if (TiposHabilidades == null)
                    return NotFound("Id inválido");

                _TiposHabilidadesRepositorio.Excluir(id);

                return Ok("Tipo de Habilidade excluída");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}