using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces.Base;
using System;

namespace Senai.HRoads.Domain.Interfaces
{
    public interface IHabilidadesRepositorio : ILeituraRepository<HabilidadesDominio>, IGravacaoRepository<HabilidadesDominio>
    {
    }
}
