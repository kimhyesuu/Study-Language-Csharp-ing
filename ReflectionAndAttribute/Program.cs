using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//리플렉션 

   // 런타임에서 형식 정보를 다룰 수 있게 하는 리플렉션
   // GetType 메소드는 Type 형식의 결과를 반환


namespace ReflectionAndAttribute
{
   class Program
   {
      static void PrintInterfaces(Type type)
      {
         Console.WriteLine("------Interfaces------");

         Type[] interfaces = type.GetInterfaces();

         foreach(var i in interfaces)
         {
            Console.Write("Name : {0} ",i.Name);
         }

         Console.WriteLine();
      }

      static void PrintFields(Type type)
      {
         Console.WriteLine("------Fields------");

         FieldInfo[] fields = type.GetFields
            (
               BindingFlags.NonPublic |
               BindingFlags.Public |
               BindingFlags.Static |
               BindingFlags.Instance
            );

         // is는 여부를 물어보는 것으로 bool로 판단하는 것이 맞음
         foreach(var field in fields)
         {
            string accessLevel = "protected";
            if (field.IsPublic) accessLevel = "public";
            else if (field.IsPrivate) accessLevel = "private";

            Console.Write("Access : {0}, Type : {1}, Name : {2}", accessLevel, field.FieldType.Name, field.Name);
         }

         Console.WriteLine();
      }

      static void PrintMethods(Type type)
      {
         Console.WriteLine("------Methods------");

         MethodInfo[] methods = type.GetMethods();

         foreach(var method in methods)
         {
            Console.Write("type : {0}, Name : {1}, Parameter", method.ReturnType.Name,method.Name);

            ParameterInfo[] args = method.GetParameters();
            for(int i = 0; i < args.Length; i++)
            {
               Console.Write("{0}", args[i].ParameterType.Name);
               if (i < args.Length - 1)
                  Console.Write(", ");
            }
            Console.WriteLine();
         }
         Console.WriteLine();
      }


      static void printProperties(Type type)
      {
         Console.WriteLine("------Properties------");

         PropertyInfo[] properties = type.GetProperties();

         foreach(var property in properties)
         {
            Console.WriteLine("Type:{0}, Name:{1}",property.PropertyType.Name, property.Name);
         }

         Console.WriteLine();
      }


      static void Main(string[] args)
      {
         int a = 0;
         Type type = a.GetType();

         PrintInterfaces(type);
         PrintFields(type);
         printProperties(type);
         PrintMethods(type);

         Console.ReadKey();
      }
   }
}
