namespace TheMovie.Service.ViewModels
{
    public class FilmeViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string Genero { get; set; }
        public int Ano { get; set; }
        public int Nota { get; set; }
        public string Poster { get; set; }
        public bool Favorito { get; set; }
    }
}
