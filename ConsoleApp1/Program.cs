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

            List<ProductResult> productResultList = GetProductResult(oldList, newList);
            Console.WriteLine("Id\tName\tDesc\tProductType");
            foreach (var item in productResultList)
            {
                Console.WriteLine(item.Product.productId + "\t" + item.Product.productName + "\t" + item.Product.productDescription + "\t" + item.ProductType);
            }

        }

        public static List<ProductResult> GetProductResult(List<Product> oldList, List<Product> newList)
        {
            List<ProductResult> result = new List<ProductResult>();

            foreach (var product in oldList)
            {
                var matchingProduct = newList.FirstOrDefault(p => p.productId == product.productId);

                if (matchingProduct != null)
                {
                    result.Add(new ProductResult
                    {
                        Product = product,
                        ProductType = ProductType.Modified
                    });
                }
                else
                {
                    result.Add(new ProductResult
                    {
                        Product = product,
                        ProductType = ProductType.Removed
                    });
                }
            }

            foreach (var product in newList)
            {
                var matchingProduct = oldList.FirstOrDefault(p => p.productId == product.productId);

                if (matchingProduct == null)
                {
                    result.Add(new ProductResult
                    {
                        Product = product,
                        ProductType = ProductType.New
                    });
                }
            }
            return result;
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
