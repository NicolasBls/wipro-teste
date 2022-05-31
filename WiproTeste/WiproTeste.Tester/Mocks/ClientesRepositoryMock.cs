using WiproTeste.Data.Entities;
using WiproTeste.Data.Entities.Enuns;
using WiproTeste.Data.Repositories;

public class ClientesRepositoryMock : IClientesRepository
{
    public Clientes? GetByIdResult;
    public Clientes? createResult;

    public Clientes? Create(Clientes cliente)
    {
        return createResult;
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    // use tuplas
    public string Devolver(int id, int filmeId)
    {
        throw new NotImplementedException();
    }

    public List<Clientes> GetAll()
    {
        throw new NotImplementedException();
    }

    public Clientes GetById(int id)
    {
        return GetByIdResult;
    }

    public Clientes Locar(int id, int filmeId)
    {
        throw new NotImplementedException();
    }

    public Clientes Update(Clientes cliente)
    {
        throw new NotImplementedException();
    }
}
