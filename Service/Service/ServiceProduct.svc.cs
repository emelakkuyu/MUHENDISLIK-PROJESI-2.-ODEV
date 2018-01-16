using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceProduct" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceProduct.svc or ServiceProduct.svc.cs at the Solution Explorer and start debugging.
    public class ServiceProduct : IServiceProduct
    {
        public bool create(Product product)
        {
            using (mydemoEntities mde = new mydemoEntities())
            {
                try
                {

                    ProductEntity pe = new ProductEntity();
                    pe.Name = product.Name;
                    pe.Price = product.Price;
                    pe.Quantity = product.Quantity;
                    mde.Product.Add(pe);
                    mde.SaveChanges();
                    return true;
                }
                catch
                {

                    return false;
                }
            };
        }

        public bool delete(Product product)
        {
            using (mydemoEntities mde = new mydemoEntities())
            {
                try
                {
                    int id = Convert.ToInt32(product.Id);
                    ProductEntity pe = mde.Product.Single(p => p.Id == id);
                    mde.Product.Remove(pe);
                    mde.SaveChanges();
                    return true;
                }
                catch
                {

                    return false;
                }
            };
        }
        public bool edit(Product product)
        {
            using (mydemoEntities mde = new mydemoEntities())
            {
                try
                {
                    int id = Convert.ToInt32(product.Id);
                    ProductEntity pe = mde.Product.Single(p => p.Id == id);
                    pe.Name = product.Name;
                    pe.Price = product.Price;
                    pe.Quantity = product.Quantity;
                    mde.SaveChanges();
                    return true;
                }
                catch
                {

                    return false;
                }
            };
        }

        public Product find(string id)
        {
            using (mydemoEntities mde = new mydemoEntities())
            {
                int nid = Convert.ToInt32(id);
                return mde.Product.Where(pe => pe.Id == nid).Select(pe => new Product
                {
                    Id = pe.Id,
                    Name = pe.Name,
                    Price = pe.Price.Value,
                    Quantity = pe.Quantity.Value
                }).First();
            };
        }

        public List<Product> findall()
        {
            using (mydemoEntities mde = new mydemoEntities())
            {
                return mde.Product.Select(pe => new Product
                {
                    Id = pe.Id,
                    Name = pe.Name,
                    Price = pe.Price.Value,
                    Quantity = pe.Quantity.Value
                }).ToList();
            };
        }
    }
}
