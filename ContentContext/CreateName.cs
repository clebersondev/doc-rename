namespace docrename.ContentContext;
public class CreateName
{
    public CreateName(string pathFile, string destPath, string destFilePath)
    {
        FilePath = pathFile;
        DestPath = destPath;
        DestFilePath = destFilePath;
        files = Directory.GetFiles(FilePath);
    }
    public string FilePath { get; set; }
    public string DestPath { get; set; }
    public string DestFilePath { get; set; }
    public List<string> NameFiles = new();

    public string[] files;

    public List<string> GetFileNames()
    {
        int i = 0;
        foreach (var file in files)
        {
            var extension = Path.GetExtension(file);

            do
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                i++;
                if (extension == ".mkv" || extension == ".mp4")
                {
                    NameFiles.Add(fileName);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"O {fileName} foi adicionado ao arquivo.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"O arquivo {fileName} foi ignorado");
                    Console.ResetColor();
                }
            }
            while (i > files.Length);
        }
        return NameFiles;
    }

    public void CreateAndWriteFile()
    {
        try
        {
            using StreamWriter writer = new StreamWriter(DestFilePath);
            foreach (var file in NameFiles)
                writer.WriteLine(file);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Ops! Algo deu errado: {ex.Message} Tipo: '{ex.GetType}'");
            Console.WriteLine("Aperte qualquer tecla para sair do programa...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        Console.WriteLine("Os títulos foram salvos com sucesso!");
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}