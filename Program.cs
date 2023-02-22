using System;
using System.IO;

namespace DocRename
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = @"C:\Users\Cleberson\Desktop\teste";

            string[] files = Directory.GetFiles(rootPath);

            foreach(string file in files)
            {
                Console.WriteLine($"Qual o caractere do '{Path.GetFileNameWithoutExtension(file)}' que você deseja renomear ou remover?");
                try
                {
                    string respUser = Console.ReadLine();

                    if (String.IsNullOrEmpty(respUser))
                    {
                        Console.WriteLine("A resposta não pode ser vazia.");
                    }else
                    {
                        string charUser = respUser;
                        
                        if(file.Contains(charUser))
                        {
                            string renameFile = Path.GetFullPath(file.Replace(charUser, ""));
                            File.Move(file, renameFile);
                            Console.WriteLine($"O {Path.GetFileName(file)} foi renomeado para {Path.GetFileName(renameFile)}.");
                        }
                        else
                        {
                            Console.WriteLine("Nenhum resultado com esse caractere foi encontrado.");
                        }

                    }  
                }catch(Exception)
                {
                    Console.WriteLine("Entre com um caractere válido, por favor.");
                }           
            }
            Console.WriteLine("All done!");
            //Console.Read();
        }
    }
}