using System.Collections.Generic;
using emptProj.Data.Entities;

namespace emptProj.Data
{
    public interface IEmptProjRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        bool SaveAll();
    }
}