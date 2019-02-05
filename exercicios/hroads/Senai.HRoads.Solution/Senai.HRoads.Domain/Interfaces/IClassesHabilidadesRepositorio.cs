using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces.Base;
using System;

namespace Senai.HRoads.Domain.Interfaces
{
    public interface IClassesHabilidadesRepositorio : ILeituraRepository<ClassesHabilidadesDominio>, IGravacaoRepository<ClassesHabilidadesDominio>
    {
        void Excluir(int Id_Classe, int Id_Habilidade);

        ClassesHabilidadesDominio BuscarPorId(int Id_Classe, int Id_Habilidade);
    }
}
