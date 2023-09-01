using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeCoding
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
                new Product { productId = 1, productName = "TVS", productDescription = "desc1 new" },
                new Product { productId = 2, productName = "TVS1", productDescription = "desc2 new" },
                new Product { productId = 3, productName = "TVS2", productDescription = "desc3 new" },
                new Product { productId = 4, productName = "TVS3", productDescription = "desc4 new" },
                new Product { productId = 5, productName = "TVS4", productDescription = "desc5 new" }
            };

            List<Product> newList = new List<Product>
            {
                new Product { productId = 1, productName = "TVS", productDescription = "desc1 modified" },
                new Product { productId = 2, productName = "TVS1", productDescription = "desc2 modified" },
                new Product { productId = 7, productName = "TVS26", productDescription = "desc26 new" },
                new Product { productId = 8, productName = "TVS33", productDescription = "TVS33 new" },
                new Product { productId = 9, productName = "TVS42", productDescription = "TVS42 new" }
            };

            oldList.Sort((x, y) => x.productId.CompareTo(y.productId));
            newList.Sort((x, y) => x.productId.CompareTo(y.productId));

            List<Product> commonProducts = new List<Product>();

            foreach (var product in oldList)
            {
                if (BinarySearch(newList, product.productId) != -1)
                {
                    commonProducts.Add(product);
                }
            }

            // Now, 'commonProducts' contains the common products between 'oldList' and 'newList'.
        }

        public static int BinarySearch(List<Product> list, int productId)
        {
            int left = 0;
            int right = list.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (list[mid].productId == productId)
                {
                    return mid; // Product found at index 'mid'.
                }
                else if (list[mid].productId < productId)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1; // Product not found.
        }
    }
}
