using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces.Base;
using System;

namespace Senai.HRoads.Domain.Interfaces
{
    public interface ITiposHabilidadesRepositorio : ILeituraRepository<TiposHabilidadesDominio>, IGravacaoRepository<TiposHabilidadesDominio>
    {
    }
}
