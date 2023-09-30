namespace MiApi.Models
{
    public partial class Elecciones
    {
        public int Id { get; set; }
        public string Candidato { get; set; }
        public int votos { get; set; }

        public double porcentaje { get; set; }
}
}
