using System;

namespace ConsoleApp
{

    //apply constraints
    public class Utilities<T> where T : IComparable,new ()
    {

        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public void DoSomething(T value){
            var obj = new T();
        }

        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }

    public class Product{
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class DiscountCalculator<TProduct> where TProduct : Product{
        public float calculateDiscount(TProduct product){
            return product.Price;
        }
    }
}