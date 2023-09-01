using System;
using System.Collections.Generic;
using System.Linq;


//Need to findout

//1. Common between the 2 list.
//2. OldList-NewList
//3. NewList-OldList


//Here you need to return List<ProductResult>
//which has data for all the products in both lists  i.e. ProductA and ProdcutB .
//If prodcut is available in both list then ProductType is Modified
//If product is not available in ProdcutB list means ProdcutType is Removed
//If product was not there in ProdcutA but it is there in ProdcutB then ProcutType is New


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
                new Product { productId = 8, productName = "TVS33", productDescription = "TVS33" },
                new Product { productId = 9, productName = "TVS42", productDescription = "TVS42" }
            };

            //1 - Common between the 2 list using binary search
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

            //2 - Substract newlist from oldlist
            List<Product> subtractedList2 = new List<Product>();

            foreach (var product in oldList)
            {
                if (!newList.Any(p => p.productId == product.productId))
                {
                    subtractedList2.Add(product);
                }
            }

            // Now, 'subtractedList' contains the products that exist in 'oldList' but not in 'newList'.

            //3 - Subtract oldlist from newlist
            List<Product> subtractedList3 = new List<Product>();

            foreach (var product in newList)
            {
                if (!oldList.Any(p => p.productId == product.productId))
                {
                    subtractedList3.Add(product);
                }
            }

            // Now, 'subtractedList' contains the products that exist in 'newList' but not in 'oldList'.


            // Prepare a new resultset with following condition
            //Here you need to return List<ProductResult>
            //which has data for all the products in both lists  i.e. ProductA and ProdcutB .
            //If prodcut is available in both list then ProductType is Modified
            //If product is not available in ProdcutB list means ProdcutType is Removed
            //If product was not there in ProdcutA but it is there in ProdcutB then ProcutType is New

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
            //end result


            //print values

            Console.WriteLine("Question1 ========= ");
            foreach (var item in commonProducts)
            {
                Console.WriteLine("--Id--" + item.productId + "--Name--" + item.productName + "--Desc--" + item.productDescription);
            }

            Console.WriteLine("Question2 ========= ");
            foreach (var item in subtractedList2)
            {
                Console.WriteLine("--Id--" + item.productId + "--Name--" + item.productName + "--Desc--" + item.productDescription);
            }

            Console.WriteLine("Question3 ========= ");
            foreach (var item in subtractedList3)
            {
                Console.WriteLine("--Id--" + item.productId + "--Name--" + item.productName + "--Desc--" + item.productDescription);
            }

            Console.WriteLine("Question Combo ======= ");
            foreach (var item in result)
            {
                Console.Write("--Id--" + item.Product.productId );
                Console.Write("--Name--" + item.Product.productName);
                Console.Write("--Desc--" + item.Product.productDescription);
                Console.Write("--ProductType--" + item.ProductType);
                Console.WriteLine();
            }
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
