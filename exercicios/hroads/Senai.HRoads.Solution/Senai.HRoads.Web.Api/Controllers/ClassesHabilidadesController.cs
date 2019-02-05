using Microsoft.AspNetCore.Mvc;
using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces;
using System.Linq;

namespace Senai.HRoads.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesHabilidadesController : ControllerBase
    {
        private IClassesHabilidadesRepositorio _ClassesHabilidadesRepositorio;

        public ClassesHabilidadesController(IClassesHabilidadesRepositorio ClassesHabilidadesRepositorio_)
        {
            _ClassesHabilidadesRepositorio = ClassesHabilidadesRepositorio_;
        }

        // GET: api/personagens
        /// <summary>
        /// Retorna todas as Classes Habilidades cadastradas
        /// </summary>
        /// <returns>Objeto contedo valores das Classes Habilidades cadastrados</returns>
        /// <response code="200">Retorna as Classes Habilidades se Ok</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_ClassesHabilidadesRepositorio.Listar().ToList());
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // GET: api/personagens/5
        /// <summary>
        /// Busca uma Classe Habilidade pelo seu Id
        /// </summary>
        /// <param name="id_classe">Id da classe</param>
        /// /// <param name="id_habilidade">Id da habilidade</param>
        /// <returns>Retorna um objeto com o personagem buscada</returns>
        /// <response code="200">Retorna o personagem se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpGet("{id_classe}/{id_habilidade}")]
        public ActionResult Get(int id_classe, int id_habilidade)
        {
            try
            {
                ClassesHabilidadesDominio ClassesHabilidades =  _ClassesHabilidadesRepositorio.BuscarPorId(id_classe, id_habilidade);

                if (ClassesHabilidades == null)
                    return NotFound("Id inválido");

                return Ok(ClassesHabilidades);
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
        /// <param name="dados">Dados da Classe Habilidade</param>
        /// <returns>Retorna Ok caso o personagem tenha sido criada</returns>
        /// <response code="200">Retorna o texto se Ok</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpPost]
        public ActionResult Post([FromBody] ClassesHabilidadesDominio dados)
        {
            try
            {
                _ClassesHabilidadesRepositorio.Inserir(dados);

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
        /// <param name="id">Id da Classe Habilidade</param>
        /// <param name="dados">Dados da Classe Habilidade que será alterada</param>
        /// <returns>Retorna mensagem informando que o personagem foi atualizado</returns>
        /// <response code="200">Retorna mensagem se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ClassesHabilidadesDominio dados)
        {
            try
            {
                ClassesHabilidadesDominio ClassesHabilidades =  _ClassesHabilidadesRepositorio.BuscarPorId(id);

                if (ClassesHabilidades == null)
                    return NotFound("Id inválido");

                _ClassesHabilidadesRepositorio.Atualizar(dados);

                return Ok("personagem atualizada");
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // DELETE: api/personagens/5
        /// <summary>
        /// Exclui uma Classe Habilidade
        /// </summary>
        /// <param name="id_classe">Id da classe</param>
        /// <param name="id_habilidade">Id da habilidade</param>
        /// <returns>Retorna mensagem informando que o personagem foi excluída</returns>
        /// <response code="200">Retorna mensagem se Ok</response>
        /// <response code="400">Retorna Not Found caso o id seja inválido</response>
        /// <response code="404">Retorna Erro caso algo de errado</response>
        [HttpDelete("{id_classe}/{id_habilidade}")]
        public ActionResult Delete(int id_classe, int id_habilidade)
        {
            try
            {
                ClassesHabilidadesDominio ClassesHabilidades =  _ClassesHabilidadesRepositorio.BuscarPorId(id_classe, id_habilidade);

                if (ClassesHabilidades == null)
                    return NotFound("Id inválido");

                _ClassesHabilidadesRepositorio.Excluir(id_classe, id_habilidade);

                return Ok("personagem excluída");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}