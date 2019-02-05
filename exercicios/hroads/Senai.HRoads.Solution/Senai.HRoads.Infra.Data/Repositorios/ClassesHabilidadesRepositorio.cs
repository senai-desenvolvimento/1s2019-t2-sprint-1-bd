using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces;

namespace Senai.HRoads.Infra.Data.Repositorios
{
    public class ClassesHabilidadesRepositorio : IClassesHabilidadesRepositorio
    {
        public void Atualizar(ClassesHabilidadesDominio dados)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.Query<ClassesHabilidadesDominio>("UPDATE CLASSES_HABILIDADES SET ID_CLASSE = @ID_CLASSE, ID_HABILIDADE = @ID_HABILIDADE WHERE ID_CLASSE = @ID_CLASSE AND ID_HABILIDADE = @ID_HABILIDADE", new { ID_CLASSE = dados.Id_Classe, ID_HABILIDADE = dados.Id_Habilidade });
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
                    conexao.QueryFirstOrDefault<ClassesHabilidadesDominio>("DELETE CLASSES_HABILIDADES WHERE ID_CLASSE = @ID_CLASSE AND ID_HABILIDADE = @ID_HABILIDADE", new { ID = Id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Inserir(ClassesHabilidadesDominio dados)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.Query<ClassesHabilidadesDominio>("INSERT INTO CLASSES_HABILIDADES VALUES(@ID_CLASSE, @ID_HABILIDADE)", new { ID_CLASSE = dados.Id_Classe, ID_HABILIDADE= dados.Id_Habilidade });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public void Excluir(int Id_Classe, int Id_Habilidade)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.QueryFirstOrDefault<ClassesHabilidadesDominio>("DELETE CLASSES_HABILIDADES WHERE ID_CLASSE = @ID_CLASSE AND ID_HABILIDADE = @ID_HABILIDADE", 
                                                                            new { ID_CLASSE = Id_Classe, ID_HABILIDADE = Id_Habilidade });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ClassesHabilidadesDominio> Listar()
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    return conexao.Query<ClassesHabilidadesDominio>("SELECT ID_CLASSE, ID_HABILIDADE FROM CLASSES_HABILIDADES");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public ClassesHabilidadesDominio BuscarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public ClassesHabilidadesDominio BuscarPorId(int Id_Classe, int Id_Habilidade)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                   return conexao.QueryFirstOrDefault<ClassesHabilidadesDominio>("SELECT ID_CLASSE, ID_HABILIDADE FROM CLASSES_HABILIDADES WHERE ID_CLASSE = @ID_CLASSE AND  ID_HABILIDADE = @ID_HABILIDADE", new { ID_CLASSE = Id_Classe, ID_HABILIDADE = Id_Habilidade });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
