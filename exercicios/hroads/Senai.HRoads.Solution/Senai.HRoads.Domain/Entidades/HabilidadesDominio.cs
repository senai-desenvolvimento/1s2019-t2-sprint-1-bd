namespace Senai.HRoads.Domain.Entidades
{
    public class HabilidadesDominio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual TiposHabilidadesDominio TiposHabilidades { get; set; }
        public int Id_Tipo_Habilidade { get; set; }
    }
}
