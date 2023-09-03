using PracticeCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCoding
{
    internal class TestClass
    {



        //1 - Common between the 2 list using binary search
//        oldList.Sort((x, y) => x.productId.CompareTo(y.productId));
//            newList.Sort((x, y) => x.productId.CompareTo(y.productId));

//            List<Product> commonProducts = new List<Product>();

//            foreach (var product in oldList)
//            {
//                if (BinarySearch(newList, product.productId) != -1)
//                {
//                    commonProducts.Add(product);
//                }
//}

//        // Now, 'commonProducts' contains the common products between 'oldList' and 'newList'.

//        //2 - Substract newlist from oldlist
//        List<Product> subtractedList2 = new List<Product>();

//            foreach (var product in oldList)
//            {
//                if (!newList.Any(p => p.productId == product.productId))
//                {
//                    subtractedList2.Add(product);
//                }
//}

//// Now, 'subtractedList' contains the products that exist in 'oldList' but not in 'newList'.

////3 - Subtract oldlist from newlist
//List<Product> subtractedList3 = new List<Product>();

//foreach (var product in newList)
//{
//    if (!oldList.Any(p => p.productId == product.productId))
//    {
//        subtractedList3.Add(product);
//    }
//}

//            // Now, 'subtractedList' contains the products that exist in 'newList' but not in 'oldList'.


        //print values

//        Console.WriteLine("Question1 ========= ");
//            Console.WriteLine("Id\tName\tDesc");
//            foreach (var item in commonProducts)
//            {
//                Console.WriteLine(item.productId + "\t" + item.productName + "\t" + item.productDescription);
//            }

//    Console.WriteLine("Question2 ========= ");
//            Console.WriteLine("Id\tName\tDesc");
//            foreach (var item in subtractedList2)
//            {
//                Console.WriteLine(item.productId + "\t" + item.productName + "\t" + item.productDescription);
//            }

//Console.WriteLine("Question3 ========= ");
//Console.WriteLine("Id\tName\tDesc");
//foreach (var item in subtractedList3)
//{
//    Console.WriteLine(item.productId + "\t" + item.productName + "\t" + item.productDescription);
//}

//Console.WriteLine("Question Combo ======= ");
//Console.WriteLine("Id\tName\tDesc\tProductType");
//foreach (var item in result)
//{
//    Console.WriteLine(item.Product.productId + "\t" + item.Product.productName + "\t" + item.Product.productDescription + "\t" + item.ProductType);
//}
    }
}
