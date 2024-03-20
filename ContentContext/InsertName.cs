namespace docrename.ContentContext;

public class InsertName
{
    public InsertName(string pathFile, string destPath, string destFilePath)
    {
        FilePath = pathFile;
        DestPath = destPath;
        DestFilePath = destFilePath;
        files = Directory.GetFiles(FilePath);
    }
    public string FilePath { get; set; }
    public string DestPath { get; set; }
    public string DestFilePath { get; set; }
    public string[] files;

    public void RenameFiles()
    {
        try
        {
            if (!Directory.Exists(DestPath))
                Directory.CreateDirectory(DestPath);

            using StreamReader sr = new(DestFilePath);
            int i = 0;
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file);
                var line = sr.ReadLine();
                do
                {
                    if (line == null)
                    {
                        line = Path.GetFileName(file);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O arquivo {0} foi ignorado.", line);
                        Console.ResetColor();
                    }
                    else
                    {
                        i++;
                        File.Move(file, $"{i.ToString("D3")}. {line}{extension}");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("O arquivo {0}.{1} foi renomeado.", line, extension);
                        Console.ResetColor();
                    }
                } while (i > files.Length);
            }
            Console.WriteLine();
            Console.WriteLine("Todos os arquivos foram renomeados com sucesso.");
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ops! Algo deu errado: {ex.Message}");
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}