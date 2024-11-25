using Microsoft.AspNetCore.Mvc;
using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Repositories;
using System.Collections.Generic;

namespace dizajni_i_sistemit_softuerik.Services
{
    public class ClientService : IClientService
    {
        
       private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        { 
        
            _clientRepository = clientRepository;
        }

        public IEnumerable<Client> GetAll() => _clientRepository.GetAll();

        public Client GetById(int id) => _clientRepository.GetById(id);

        public void Create (Client client) => _clientRepository.Add(client);

        public void Update (Client client) => _clientRepository.Update(client);

        public void Delete (int id) => _clientRepository.Delete(id);
    }
}
