using System.Collections.Generic;
using System.Linq;
using EFCoreTest.Context;
using EFCoreTest.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTest.Repository
{
    public class ProductRepository
    {
        private readonly dbContext _database;
        public ProductRepository()
        {
            _database = new dbContext();
        }
        
        public bool Add(Product product)
        {
            _database.products.Add(product);
            
            return _database.SaveChanges() > 0;
        }

        public bool Remove(int id)
        {
            var product = _database.products.FirstOrDefault(x => x.Id == id);
            
            if (product != null)
            {
                _database.products.Remove(product);
                return _database.SaveChanges() > 0;
            }

            return false;
        }

        public ICollection<Product> GetAll()
        {
            return _database.products.ToList();
        }

        public Product GetById(int id)
        {
            return _database.products.Find(id);
        }

        public bool Update(Product product)
        {
            _database.Entry(product).State = EntityState.Modified;

            return _database.SaveChanges() > 0;
        }
    }
}
