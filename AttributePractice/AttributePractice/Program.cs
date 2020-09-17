using System;
using System.Collections.Generic;
using System.Reflection;


namespace AttributePractice
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    class AuthorAttribute : Attribute
    {
        public string Name { get; private set; }
        public Version Version { get; private set; }

        public AuthorAttribute(string name, int major = 1, int minor = 0)
        {
            Name = name;
            Version = new Version(major, minor);
        }
    }


    [Author("Karan Bhamra", 1, 1)]
    [Author("Edan Saedi", 1, 0)]
    class Person
    {
        public string Name { get; private set; }

        public int Age { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    class MathOpAttribute : Attribute
    {
      
    }


    class CompareByAttribute: Attribute
    {
        
    }


    class Calculator
    {
        [MathOp]
        public static int Add(int x, int y) => x + y;

        [MathOp]
        public static int Mult(int x, int y) => x * y;
    }


    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("John Smith");

            Type personType = person.GetType();

            var customAttributes = personType.GetCustomAttributes();

            foreach (var attribute in customAttributes)
            {
                if (attribute is AuthorAttribute)
                {
                    var author = attribute as AuthorAttribute;

                    Console.WriteLine($"{author.Name}, {author.Version}");
                }
            }


            var calcType = typeof(Calculator);

            var methods = calcType.GetMethods();

            var funcs = new List<MethodInfo>();

            foreach (var method in methods)
            {
                var methodAttributes = method.GetCustomAttributes();

                foreach (var attribute in methodAttributes)
                {
                    if (attribute is MathOpAttribute)
                    {
                        funcs.Add(method);
                    }
                }
            }

            Random gen = new Random();

            int num1 = gen.Next(100);
            int num2 = gen.Next(100);

            foreach (var func in funcs)
            {
                Console.WriteLine($"Invoking: {func.Name} with parameters: {num1}, {num2}, Result = {func.Invoke(null, new object[] { num1, num2})}");
            }

            var bst = new BST3<int>();
            var bst2 = new BST3<Person>();

        }


        class BST<T> where T: IComparable<T>
        {

        }


        class BST2<T>
        {
            IComparer<T> comparer;
            public BST2(IComparer<T> comparer)
            {

            }
        }


        class School
        {
            Person Admin;
        }

        class BST3<T>
        {
            //attribute based
        }



    }
}
