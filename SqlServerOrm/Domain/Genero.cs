namespace SqlServerOrm.Domain
{
    public class Genero
    {
        public int Codigo { get; set; }

        public string Tipo { get; set; }

        public List<Musica> Musicas { get; set; } = new List<Musica>();
    }
}
