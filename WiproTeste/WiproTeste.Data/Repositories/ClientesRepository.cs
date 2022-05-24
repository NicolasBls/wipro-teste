using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiproTeste.Data.Entities;

namespace WiproTeste.Data.Repositories
{
    public interface IClientesRepository
    {
        public Clientes Create(Clientes clientes);
    }
    public class ClientesRepository : IClientesRepository
    {
        public Clientes Create( Clientes clientes)
        {
            return clientes;
        }
    }
}
