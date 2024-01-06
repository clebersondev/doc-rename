namespace docrename.ContentContext;

public class CreateName
{
    const string rootPath = @"C:\Users\Cleberson\Videos\Curso do Balta\Back-end\Carreira 02 - .NET Data Access\02. Acesso à dados com .NET, C#, Dapper e SQL Server";
    const string destPath = $@"{rootPath}\namefile\" + "names.txt";

    readonly string[] files = Directory.GetFiles(rootPath);
    public List<string> NameFiles { get; set; } = new();

    public List<string> GetName()
    {
        foreach (var file in files)
        {
            var name = Path.GetFileName(file);
            NameFiles.Add(name);
        }
        return NameFiles;
    }

    public void CreateAndWriteFile()
    {
        try
        {
            if (!File.Exists(destPath))
                File.Create(destPath);

            using StreamWriter writer = new StreamWriter(destPath);
            foreach (var file in NameFiles)
                writer.WriteLine(file);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Ops! Algo deu errado: {ex.Message}");
            Console.WriteLine("Aperte qualquer tecla para sair do programa...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        Console.WriteLine("Os títulos foram salvos com sucesso!");
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}