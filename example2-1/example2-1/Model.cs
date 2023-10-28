using System;

namespace example2_1
{
    public class A
    {
        private static int Instances = 1;
        public A()
        {
            Console.WriteLine($"A: {Instances++}");
        }
    }
    
    public class B
    {
        private static int Instances = 1;
        public B()
        {
            Console.WriteLine($"B: {Instances++}");
        }
    }
    
    public class C
    {
        private static int Instances = 1;
        public C()
        {
            Console.WriteLine($"C: {Instances++}");
        }
    }
}