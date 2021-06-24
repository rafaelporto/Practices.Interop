using clojure.lang;
using System;
using System.IO;
using static System.Console;

namespace Practices.Interop.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = GetClojureFilePath();
            IFn loadFile = clojure.clr.api.Clojure.var("clojure.core", "load-file");
            loadFile.invoke(filePath);

            var hello = clojure.clr.api.Clojure.var("calculator.core", "helloWorld");
            var sum = clojure.clr.api.Clojure.var("calculator.core", "sum");
            var multiply = clojure.clr.api.Clojure.var("calculator.core", "multiply");
            var sub = clojure.clr.api.Clojure.var("calculator.core", "sub");

            WriteLine(hello.invoke());
            Write("Primeiro Valor: ");
            var value1 = ReadLine();
            WriteLine();
            Write("Segundo Valor: ");
            var value2 = ReadLine();
            WriteLine();
            WriteLine($"Soma: {sum.invoke(value1, value2)}");
            WriteLine($"Multiplicacao: {multiply.invoke(value1, value2)}");
            WriteLine($"Subtracao: {sub.invoke(value1, value2)}");
            ReadKey();
        }

        static string GetClojureFilePath()
        {
            var workingDirectory = Directory.GetCurrentDirectory();
            var rootRepo = Directory.GetParent(workingDirectory).Parent.Parent.Parent;
            var filePath = "\\Practices.Interop.Clojure\\src\\calculator\\core.clj";
            var result = string.Concat(rootRepo.FullName, filePath);

            return result;
        }
    }
}
