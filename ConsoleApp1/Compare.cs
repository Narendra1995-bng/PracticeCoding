using System;
using System.Collections.Generic;

namespace PracticeCoding2
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
        public static void Main2(string[] args)
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


            //List<ProductResult> productResultList = BinarySearchCompare(oldList, newList);
            //// Print the result
            //Console.WriteLine("Id\tName\tDesc\tProductType");
            //foreach (var item in productResultList)
            //{
            //    Console.WriteLine($"{item.Product.productId}\t{item.Product.productName}\t{item.Product.productDescription}\t{item.ProductType}");
            //}
            BinarySearchArray();
        }

        public static List<ProductResult> BinarySearchCompare(List<Product> oldList, List<Product> newList)
        {
            // Sort both lists for binary search
            oldList.Sort((x, y) => x.productId.CompareTo(y.productId));
            newList.Sort((x, y) => x.productId.CompareTo(y.productId));

            List<ProductResult> result = new List<ProductResult>();

            // Initialize indices
            int oldListIndex = 0;
            int newListIndex = 0;

            while (oldListIndex < oldList.Count && newListIndex < newList.Count)
            {
                int comparison = oldList[oldListIndex].productId.CompareTo(newList[newListIndex].productId);

                if (comparison == 0)
                {
                    // Product is in both lists, so it's modified status
                    result.Add(new ProductResult
                    {
                        Product = oldList[oldListIndex],
                        ProductType = ProductType.Modified
                    });

                    oldListIndex++;
                    newListIndex++;
                }
                else if (comparison < 0)
                {
                    // Product is in oldList but not in newList, so it's removed status
                    result.Add(new ProductResult
                    {
                        Product = oldList[oldListIndex],
                        ProductType = ProductType.Removed
                    });

                    oldListIndex++;
                }
                else
                {
                    // Product is in newList but not in oldList, so it's new status
                    result.Add(new ProductResult
                    {
                        Product = newList[newListIndex],
                        ProductType = ProductType.New
                    });

                    newListIndex++;
                }
            }

            // Check if there are remaining products in either list
            while (oldListIndex < oldList.Count)
            {
                result.Add(new ProductResult
                {
                    Product = oldList[oldListIndex],
                    ProductType = ProductType.Removed
                });
                oldListIndex++;
            }

            while (newListIndex < newList.Count)
            {
                result.Add(new ProductResult
                {
                    Product = newList[newListIndex],
                    ProductType = ProductType.New
                });
                newListIndex++;
            }

            return result;
        }

        public static void BinarySearchArray()
        {
            List<Product> oldList = new List<Product>
            {
                new Product { productId = 1, productName = "TVS", productDescription = "desc1" },
                new Product { productId = 2, productName = "TVS1", productDescription = "desc2" },
                new Product { productId = 3, productName = "TVS2", productDescription = "desc3" },
                new Product { productId = 4, productName = "TVS3", productDescription = "desc4" },
                new Product { productId = 5, productName = "TVS4", productDescription = "desc5" }
            };

            //find product 4 using binary search

            // Sort the list by productId
            oldList.Sort((x, y) => x.productId.CompareTo(y.productId));

            // Perform binary search to find product with productId = 4
            int targetProductId = 4;
            //now target is each element of NewList
            int left = 0;
            int right = oldList.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (oldList[mid].productId == targetProductId)
                {
                    // Product with productId 4 found
                    Console.WriteLine("Product found:");
                    Console.WriteLine($"ID: {oldList[mid].productId}");
                    Console.WriteLine($"Name: {oldList[mid].productName}");
                    Console.WriteLine($"Description: {oldList[mid].productDescription}");
                    break;
                }
                else if (oldList[mid].productId < targetProductId)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }
    }
}
