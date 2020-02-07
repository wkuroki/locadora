using Locadora.Entities;

namespace Locadora.Models
{
    public class ClienteView
    {

        public ClienteView()
        {
        }

        public ClienteView(Cliente cliente)
        {
            if (cliente != null)
            {
                IdCliente = cliente.Id;
                Nome = cliente.Nome;
            }
        }

        public long IdCliente { get; set; }
        public string Nome { get; set; }
        public Cliente ToCliente()
        {
            return new Cliente()
            {
                Id = IdCliente,
                Nome = Nome,
            };
        }
    }
}