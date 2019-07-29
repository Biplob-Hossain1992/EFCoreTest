using System;
using System.Collections.Generic;
using EFCoreTest.Model;
using EFCoreTest.Repository;

namespace EFCoreTest
{
    internal class Program
    {
        private const string Title = "ID\tName\tPrice\n";

        private static readonly ProductRepository ProductRepository = new ProductRepository();
        private static void Main(string[] args)
        {  
            //GetAProduct(7);
            //RemoveProduct(1);
            //UpdateThroughId(1,"new",1);
            //AddProduct(name,0);
            //RemoveProduct(1);

        }

        private static void ShowAllProducts()
        {
            ICollection<Product> products = ProductRepository.GetAll();
            
            Console.WriteLine(Title);

            foreach (var product in products)
            {
                Console.WriteLine(product.Id + "\t" + product.Name + "\t" + product.Price);
            }
        }

        private static void AddProduct(string newName,int newPrice)
        {
            if (ProductRepository.Add(new Product() { Name = newName, Price = newPrice}))
            {
                Console.WriteLine(@"Successfully Added");
                ShowAllProducts();
            }
            else
            {
                Console.WriteLine(@"Failed");
            }

        }

        private static void RemoveProduct(int selectedId)
        {
            Console.WriteLine(ProductRepository.Remove(selectedId)
                ? @"Successfully Deleted"
                : @"Failed...Intended Item Not Found");

            ShowAllProducts();
        }

        private static void GetAProduct(int selectedId)
        {
            var singleProduct = ProductRepository.GetById(selectedId);

            if (singleProduct != null)
            {
                Console.WriteLine(Title);
                Console.WriteLine(singleProduct.Id + "\t" + singleProduct.Name + "\t" + singleProduct.Price);
            }
            else
            {
                Console.WriteLine(@"Failed...Intended Item Not Found");
            }
            
            

        }

        private static void UpdateThroughId(int selectedId,string newName, int newPrice)
        {
            var retrievedProduct = ProductRepository.GetById(selectedId);
            if (retrievedProduct != null)
            {
                retrievedProduct.Name = newName;
                retrievedProduct.Price = newPrice;

                if (ProductRepository.Update(retrievedProduct))
                {
                 Console.WriteLine(@"Successfully Updated The Product which contains the ID = "+selectedId);
                 ShowAllProducts();
                 
                }
                else
                {
                    Console.WriteLine(@"Failed...");
                }
            }
            else
            {
                Console.WriteLine(@"Failed...Intended Item Not Found");
                ShowAllProducts();
            }
        }
    }
}
