using System;
using System.Reflection;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;

namespace Attribute_Practice
{

    //Do this practice.
    //Create an attribute called author. Full name and version they wrote. Using reflection, print out any class that has that attribute applied to it in the assembly.

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    class AuthorAttribute : Attribute
    {
        public string Name { get; private set; }
        public Version Version { get; private set; }

        public AuthorAttribute(string name, int major = 1, int minor = 1)
        {
            Name = name;
            Version = new Version(major, minor);
        }
    }

    [Author("Ronel Saedi", 1, 0)]
    class Animal
    {
        public string Species { get; private set; }

        public int Age { get; set; }

        public Animal(string name)
        {
            Species = name;
        }

        public override string ToString()
        {
            return Species;
        }
    }

    [Author("Ronel Saedi", 1, 0)]
    [Author("Karan", 1, 1)]
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

    [Author("Ronel Saedi", 1, 0)]
    [Author("Karan", 1, 1)]
    [Author("Grandpa Joe", 2, 2)]
    class Plant
    {
        public string Species { get; private set; }

        public int Age { get; set; }

        public Plant(string name)
        {
            Species = name;
        }

        public override string ToString()
        {
            return Species;
        }
    }



    public class Program
    {
        [Author("Edan Saedi", 1, 0)]
        public static int HexToDec(string hex)
        {
            string hexAlphabet = "0123456789ABCDEF";
            int finalresult = 0;

            for (int i = 0; i < hex.Length; i++)
            {
                int hexValue = hexAlphabet.IndexOf(hex[i]);
                int columnValue = (int)Math.Pow(16, i);
                int conversion = hexValue * columnValue;
                finalresult += conversion;

            }
            return finalresult;
        }

        public static void Main(string[] args)
        {
            // write a hex to decimal converter and invoke it using reflection
            // FF = 255
            // 2D = 45
            // A = 10

            var programType = typeof(Program);//.Assembly;

            var allMethods = programType.GetMethods(BindingFlags.Static | BindingFlags.Public);

            //Find the correct method.
            ;


            //string hexInput = Console.ReadLine();
            //Console.WriteLine(HexToDec(hexInput));

            //var currentAssembly = typeof(Program).Assembly;

            //foreach (var assembly in currentAssembly.DefinedTypes)
            //{
            //    foreach (var attribute in assembly.GetCustomAttributes())
            //    {
            //        if(attribute is AuthorAttribute)
            //        {
            //            var author = attribute as AuthorAttribute;

            //            Console.WriteLine($"{assembly.Name}: {author.Name}, {author.Version}");
            //        }

            //    }
            //}

            //Next time, we will go over the non-hard coding method.
            //var assembly = Assembly.GetExecutingAssembly().GetReferencedAssemblies();

            //var person = new Person("John Brown");
            //var animal = new Animal("Cheetah");
            //var plant = new Plant("sunflower");

            //Type personType = person.GetType();
            //Type animalType = animal.GetType();
            //Type plantType = plant.GetType();

            //var personCustomAttributes = personType.GetCustomAttributes();
            //var animalCustomAttributes = animalType.GetCustomAttributes();
            //var plantCustomAttributes = plantType.GetCustomAttributes();

            //Console.WriteLine("Person");
            //foreach (var attribute in personCustomAttributes)
            //{
            //    if (attribute is AuthorAttribute)
            //    {
            //        var author = attribute as AuthorAttribute;

            //        Console.WriteLine($"{author.Name}, {author.Version}");
            //    }
            //}

            //Console.WriteLine("Animal");
            //foreach (var attribute in animalCustomAttributes)
            //{
            //    if (attribute is AuthorAttribute)
            //    {
            //        var author = attribute as AuthorAttribute;

            //        Console.WriteLine($"{author.Name}, {author.Version}");
            //    }
            //}

            //Console.WriteLine("Plant");
            //foreach (var attribute in plantCustomAttributes)
            //{
            //    if (attribute is AuthorAttribute)
            //    {
            //        var author = attribute as AuthorAttribute;

            //        Console.WriteLine($"{author.Name}, {author.Version}");
            //    }
            //}
        }
    }
}
