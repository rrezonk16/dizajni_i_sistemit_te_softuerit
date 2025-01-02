using dizajni_i_sistemit_softuerik.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace dizajni_i_sistemit_softuerik.Services.Interfaces
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
