using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeCoding3
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
    }

    public enum ProductType
    {
        New,
        Modified,
        Removed,
    }

    public class ProductResult
    {
        public Product Product { get; set; }
        public ProductType ProductType { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Product> oldList = new List<Product>
            {
                new Product { productId = 1, productName = "TVS", productDescription = "desc1" },
                new Product { productId = 2, productName = "TVS1", productDescription = "desc2" },
                new Product { productId = 3, productName = "TVS2", productDescription = "desc3" },
                new Product { productId = 4, productName = "TVS3", productDescription = "desc4" },
                new Product { productId = 5, productName = "TVS4", productDescription = "desc5" }
            };

            List<Product> newList = new List<Product>
            {
                new Product { productId = 1, productName = "TVS", productDescription = "desc1" },
                new Product { productId = 2, productName = "TVS1", productDescription = "desc2" },
                new Product { productId = 7, productName = "TVS26", productDescription = "desc26" },
                new Product { productId = 8, productName = "TVS33", productDescription = "desc33" },
                new Product { productId = 9, productName = "TVS42", productDescription = "desc42" }
            };

            // Sort the lists for binary search
            oldList.Sort((x, y) => x.productId.CompareTo(y.productId));
            newList.Sort((x, y) => x.productId.CompareTo(y.productId));

            // Find common products and mark them as Modified
            List<ProductResult> commonProducts = oldList
                .Where(product => newList.BinarySearch(product, new ProductComparer()) >= 0)
                .Select(product => new ProductResult { Product = product, ProductType = ProductType.Modified })
                .ToList();

            // Find products that are in oldList but not in newList, mark them as Removed
            List<ProductResult> removedProducts = oldList
                .Where(product => newList.BinarySearch(product, new ProductComparer()) < 0)
                .Select(product => new ProductResult { Product = product, ProductType = ProductType.Removed })
                .ToList();

            // Find products that are in newList but not in oldList, mark them as New
            List<ProductResult> newProducts = newList
                .Where(product => oldList.BinarySearch(product, new ProductComparer()) < 0)
                .Select(product => new ProductResult { Product = product, ProductType = ProductType.New })
                .ToList();

            // Combine all results into one list
            List<ProductResult> result = commonProducts.Concat(removedProducts).Concat(newProducts).ToList();

            // Print the result
            Console.WriteLine("Id\tName\tDesc\tProductType");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Product.productId}\t{item.Product.productName}\t{item.Product.productDescription}\t{item.ProductType}");
            }
        }
    }

    // Custom comparer to enable BinarySearch on Product objects
    public class ProductComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.productId.CompareTo(y.productId);
        }
    }
}
