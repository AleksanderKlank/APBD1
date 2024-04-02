using System;

namespace LegacyApp;

public class FakeClientRepository : IClientRepository
{
    public Client GetById(int clientId)
    {
        return new Client();
    }
}