using System;
using System.Reflection;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.IO;

namespace Attribute_Practice
{

    //Do this practice.
    //Create an attribute called author. Full name and version they wrote. Using reflection, print out any class that has that attribute applied to it in the assembly.

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
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
        public static void Main(string[] args)
        {

            
            //Next time, we will go over the non-hard coding method.
            //var assembly = Assembly.GetExecutingAssembly().GetReferencedAssemblies();

            ;


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
