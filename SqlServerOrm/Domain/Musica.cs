namespace SqlServerOrm.Domain
{
    public class Musica
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string? NomeCantor { get; set; }

        public int GeneroCodigo { get; set; }

        public Genero Genero{ get; set; } = null;
    }
}
