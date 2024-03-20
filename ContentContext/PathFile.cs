namespace docrename.ContentContext;

public class PathFile
{
    public string GetPathFiles()
    {
        Console.WriteLine("Qual é o destino dos arquivos?");
        var pathFile = Console.ReadLine();
        try
        {
            if (pathFile == null)
            {
                Console.WriteLine("O caminho não pode ser vazio ou invalido.");
                Console.Clear();
            }

            Console.WriteLine("Uri dos arquivos é: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(pathFile);
            Console.WriteLine("");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Ops! Algo deu errado: {ex.Message} Tipo: '{ex.GetType}'");
            Console.WriteLine("Aperte qualquer tecla para sair do programa...");
            Console.ReadKey();
            Environment.Exit(0);
        }
        return pathFile!;
    }
}