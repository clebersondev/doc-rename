using System;
using System.IO;

namespace DocRename
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = @"C:\Users\Cleberson\Desktop\teste";
            string destPath = @"C:\Users\Cleberson\Desktop\teste\renameFolder";

            string[] files = Directory.GetFiles(rootPath);

            for(int i = 0; i < files.Length; i++)
            {
                Console.WriteLine("Qual caractere deseja renomear ou editar?");
                var resp = Console.ReadLine();
                if(string.IsNullOrEmpty(resp))
                {
                    Console.WriteLine("A sua resposta não ser vazia.");
                }else
                {
                    if(files[i].Contains(resp))
                    {
                        if(Directory.Exists(destPath))
                        {
                            var file = Path.GetFullPath(files[i].Replace(resp, ""));
                            File.Move(files[i], file);
                            Directory.Move(file, destPath);
                            File.Move(destPath, destPath);
                            
                        }else
                        {
                            var file = Path.GetFullPath(files[i].Replace(resp, ""));
                            File.Move(files[i], file);
                            Directory.CreateDirectory(destPath);
                            Directory.Move(file, destPath);
                            File.Move(destPath, destPath);
                        }
                        
                    }else
                    {
                        Console.WriteLine("O caractere não foi encontrado no(s) arquivo(s).");
                    }
                }
            }

            /*foreach(string file in files)
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
            }*/
            Console.WriteLine("All done!");
        }
    }
}