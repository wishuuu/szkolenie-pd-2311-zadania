using System;

namespace example2_2
{
    public class A
    {
        public A()
        {
            Console.WriteLine(GetType());
        }
    }
    
    public class B
    {
        public B(A a)
        {
            Console.WriteLine(GetType());
        }
    }
    
    public class C
    {
        public C(A a, B b)
        {
            Console.WriteLine(GetType());
        }
    }

    public class D
    {
        public D(A a, C c)
        {
            Console.WriteLine(GetType());
        }
    }
    
    public class E
    {
        public E(A a, B b, C c, D d)
        {
            Console.WriteLine(GetType());
        }
    }
}