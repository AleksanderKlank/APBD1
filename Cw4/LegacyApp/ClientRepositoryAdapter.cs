namespace LegacyApp;

public class ClientRepositoryAdapter : IClientRepository
{
    private readonly ClientRepository _clientRepository;

    public ClientRepositoryAdapter(ClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    
    public Client GetById(int clientId)
    {
        return _clientRepository.GetById(clientId);
    }
}