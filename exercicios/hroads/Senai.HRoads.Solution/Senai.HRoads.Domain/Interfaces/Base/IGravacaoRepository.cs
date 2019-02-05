namespace Senai.HRoads.Domain.Interfaces.Base
{
    public interface IGravacaoRepository<TDomainModel> where TDomainModel : class
    {
        void Inserir(TDomainModel dados);
        void Atualizar(TDomainModel dados);
        void Excluir(int Id);
    }
}
