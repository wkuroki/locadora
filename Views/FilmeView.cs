using Locadora.Entities;

namespace Locadora.Models
{
    public class FilmeView
    {
        public FilmeView()
        {

        }

        public FilmeView(Filme filme)
        {
            if (filme != null)
            {
                IdFilme = filme.Id;
                Descricao = filme.Descricao;
                Excluido = filme.Excluido;
            }
        }
        public long IdFilme { get; set; }
        public string Descricao { get; set; }
        public bool Excluido { get; set; }

        public Filme ToFilme()
        {
            return new Filme()
            {
                Id = IdFilme,
                Descricao = Descricao,
                Excluido = Excluido,
            };
        }
    }
}
