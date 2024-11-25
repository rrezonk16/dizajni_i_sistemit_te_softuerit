using dizajni_i_sistemit_softuerik.Entities;
using Microsoft.AspNetCore.Mvc;

namespace dizajni_i_sistemit_softuerik.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetAll();
        Client GetById(int id);
        void Create(Client client);
        void Update(Client client);
        void Delete(int id);
    }
}
