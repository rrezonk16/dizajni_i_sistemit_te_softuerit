using Microsoft.EntityFrameworkCore;
using dizajni_i_sistemit_softuerik.Database;
using dizajni_i_sistemit_softuerik.Domain.Entities;
using dizajni_i_sistemit_softuerik.Repositories.Interfaces;


namespace dizajni_i_sistemit_softuerik.Repositories.Implementations
{
    public class ClientRepository : IClientRepository
    {

        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        { 
        
            _context = context;
        }

        public IEnumerable<Client> GetAll() => _context.Clients.ToList();

        public Client GetById(int id) => _context.Clients.Find(id);

        public void Add (Client client)
        {

            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void Update(Client client)
        {

            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {

            var client = _context.Clients.Find(id);
            if (client != null)
            { 
            
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }
    }
}
