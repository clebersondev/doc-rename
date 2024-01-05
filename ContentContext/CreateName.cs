namespace docrename.ContentContext;

public class CreateName
{
    const string rootPath = @"C:\Users\Cleberson\Videos\Curso do Balta\Back-end\Carreira 02 - .NET Data Access\02. Acesso à dados com .NET, C#, Dapper e SQL Server";
    //static String rootPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\02. Acesso à dados com .NET, C#, Dapper e SQL Server";
    const string destPath = $@"{rootPath}\namefile\" + "names.txt";
    //String destPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @".txt";

    string[] files = Directory.GetFiles(rootPath);
    public List<string> nameFiles { get; set; } = new();

    public List<string> GetName()
    {
        foreach (var file in files)
        {
            var name = Path.GetFileName(file);
            nameFiles.Add(name);
        };
        return nameFiles;
    }

    public void CreateAndWriteFile()
    {
        try
        {
            //var filePath = Directory.CreateDirectory(destPath);
            //filePath.Create();

            //var filecreate = File.Create(destPath);

            using (StreamWriter writer = new StreamWriter(destPath))
            {
                foreach (var file in nameFiles)
                    writer.WriteLine(file);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Algo deu errado: {ex.Message}");
            Console.WriteLine("Aperte qualquer tecla para sair do programa...");
            Console.ReadKey();
            Console.Clear();
        }

        Console.WriteLine("Os títulos foram salvos com sucesso!");
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu...");
    }
}