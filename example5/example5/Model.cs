using System;

namespace example5
{
    public interface MyInterface
    {
        void DoSomething();
    }
    
    public class A : MyInterface
    {
        public void DoSomething()
        {
            Console.WriteLine("A done something");
        }
    }
    
    public class B : MyInterface
    {
        public void DoSomething()
        {
            Console.WriteLine("B done something");
        }
    }
}