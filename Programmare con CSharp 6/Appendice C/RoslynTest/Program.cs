using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.Scripting.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynTest
{
    class Program
    {
        static CSharpParseOptions options;
        static void Main(string[] args)
        {
            EvaluateExpr();
            DoAsync();
            Console.ReadLine();
        }

        public static async void EvaluateExpr()
        {
            var result = await CSharpScript.EvaluateAsync("1+2");
            Console.WriteLine(result);
        }

        private static async void DoAsync()
        {
            options = new CSharpParseOptions(LanguageVersion.CSharp6,
                            DocumentationMode.Parse,
                            SourceCodeKind.Script,
                            null);

            Script<object> script = CSharpScript.Create(string.Empty);

            while (true)
            {
                Console.Write("> ");
                var code = Console.ReadLine();

                var newScript = script.ContinueWith(code);

                ScriptState<object> result = null;
                try
                {
                    bool isComplete = IsCompleteSubmission(code);

                    if (code == ":quit")
                    {
                        break;
                    }
                    else if (!isComplete)
                    {
                        Console.WriteLine("Incomplete submission");
                    }
                    else
                    {
                        result = await newScript.RunAsync();
                        script = newScript;
                    }
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    WriteError(error);
                }

                if (result != null && result.ReturnValue != null)
                    Console.WriteLine(result.ReturnValue);
            }
        }

        private static void WriteError(string error)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(error);
            Console.ForegroundColor = color;
        }

        private static bool IsCompleteSubmission(string code)
        {
            var syntaxTree = SyntaxFactory.ParseSyntaxTree(code, options: options);
            return SyntaxFactory.IsCompleteSubmission(syntaxTree);
        }
    }
}
