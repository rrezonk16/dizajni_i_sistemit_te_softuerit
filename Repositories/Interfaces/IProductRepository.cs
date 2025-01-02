﻿using dizajni_i_sistemit_softuerik.Domain.Entities;

namespace dizajni_i_sistemit_softuerik.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}