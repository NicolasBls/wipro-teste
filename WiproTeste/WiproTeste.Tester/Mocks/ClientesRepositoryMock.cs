using WiproTeste.Data.Entities;
using WiproTeste.Data.Entities.Enuns;
using WiproTeste.Data.Repositories;

public class ClientesRepositoryMock : IClientesRepository
{
    public ClientesModel? GetByIdResult;
    public ClientesModel? CreateResult;
    public bool DeleteResult;
    public string DevolverResult;
    public ClientesModel? UpdateResult;
    public ClientesModel? LocarResult;

    public ClientesModel? Create(ClientesModel cliente)
    {
        return CreateResult;
    }

    public bool Delete(int id)
    {
        return DeleteResult;
    }

    public string Devolver(int id, int filmeId)
    {
        return DevolverResult;
    }

    public List<ClientesModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public ClientesModel GetById(int id)
    {
        return GetByIdResult;
    }

    public ClientesModel? Locar(int id, int filmeId)
    {
        return LocarResult;
    }

    public ClientesModel? Update(ClientesModel cliente)
    {
        return UpdateResult;
    }
}
