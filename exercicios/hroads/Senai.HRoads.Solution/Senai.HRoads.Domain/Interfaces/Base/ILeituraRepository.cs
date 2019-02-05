using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Senai.HRoads.Domain.Interfaces.Base
{
    public interface ILeituraRepository<TDomainModel> where TDomainModel : class
    {
        TDomainModel BuscarPorId(int Id);
        IEnumerable<TDomainModel> Listar();
    }
}
