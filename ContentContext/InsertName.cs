namespace docrename.ContentContext;

public class InsertName
{
    const string rootPath = @"C:\Users\Cleberson\Videos\Curso do Balta\Back-end\Carreira 02 - .NET Data Access\02. Acesso à dados com .NET, C#, Dapper e SQL Server";
    const string destPath = $@"{rootPath}\namefile\" + "names.txt";

    readonly string[] files = Directory.GetFiles(rootPath);

    public void Rename()
    {
        try
        {
            if (!File.Exists(destPath))
            {
                File.Create(destPath);
            }
            else
            {
                using StreamReader sr = new(destPath);
                foreach (var file in files)
                {
                    var line = sr.ReadLine();

                    File.Move(file, line);
                    Console.WriteLine("O arquivo {0} foi renomeado.", line);
                }
                Console.WriteLine("Arquivo(s) renomado(s) com sucesso.");
                Console.ReadKey();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Algo deu errado: {ex.Message}");
            Console.ReadKey();
        }
    }
}