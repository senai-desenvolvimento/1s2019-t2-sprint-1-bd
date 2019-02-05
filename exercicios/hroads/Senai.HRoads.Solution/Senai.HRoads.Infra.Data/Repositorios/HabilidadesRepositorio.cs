using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces;

namespace Senai.HRoads.Infra.Data.Repositorios
{
    public class HabilidadesRepositorio : IHabilidadesRepositorio
    {
        public void Atualizar(HabilidadesDominio dados)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.Query<ClassesDominio>("UPDATE HABILIDADES SET NOME = @NOME, ID_TIPO_HABILIDADE = @ID_TIPO_HABILIDADE WHERE ID = @ID", 
                                                    new { NOME = dados.Nome, ID_TIPO_HABILIDADE = dados.Id_Tipo_Habilidade, ID = dados.Id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public void Excluir(int Id)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.QueryFirstOrDefault<TiposHabilidadesDominio>("DELETE HABILIDADES WHERE ID = @ID", new { ID = Id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Inserir(HabilidadesDominio dados)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.Query<TiposHabilidadesDominio>("INSERT INTO HABILIDADES VALUES(@NOME, @ID_TIPO_HABILIDADE)", new { NOME = dados.Nome, ID_TIPO_HABILIDADE = dados.Id_Tipo_Habilidade });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<HabilidadesDominio> Listar()
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    return conexao.Query<HabilidadesDominio>("SELECT ID, NOME, ID_TIPO_HABILIDADE FROM HABILIDADES ORDER BY ID");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public HabilidadesDominio BuscarPorId(int Id)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    return conexao.QueryFirstOrDefault<HabilidadesDominio>("SELECT ID, NOME, ID_TIPO_HABILIDADE FROM HABILIDADES where ID = @ID", new { ID = Id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
