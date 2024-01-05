using docrename.ContentContext;

Screen();

void Screen()
{
    Console.Clear();
    Console.WriteLine("# FERRAMENTA PARA RENOMEAR ARQUIVOS #");
    Console.WriteLine("-------------------------------------");
    Console.WriteLine("1. Extrair o nome dos arquivos.");
    Console.WriteLine("2. Inserir o nome nos arquivos.");
    Console.WriteLine("3. SAIR.");
    Console.WriteLine("-------------------------------------");
    Console.WriteLine("ESCOLHA UMA DAS OPÇÕES ACIMA...");

    try
    {
        var option = Console.ReadLine();
        if (!String.IsNullOrEmpty(option))
        {
            var resp = int.Parse(option);

            if (resp == 0 || resp >= 4)
            {
                Console.Clear();
                Console.WriteLine("Opção não correspende a nenhuma da lista. Tente de novo, por favor.");
                Console.WriteLine("Aperte qualquer tecla para voltar...");
                Console.ReadKey();
                Screen();
            }

            switch (resp)
            {
                case 1:
                    {
                        Console.Clear();
                        var createName = new CreateName();
                        createName.GetName();
                        createName.CreateAndWriteFile();
                        Console.ReadKey();
                        Screen();
                    };
                    break;
                case 2:
                    {
                        Console.Clear();
                        var insert = new InsertName();
                        insert.Rename();
                        Console.ReadKey();
                        Screen();
                    }
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Sua reposta não pode ser vazia ou incorreta.");
            Console.ReadKey();
            Screen();
        }
    }
    catch (Exception ex)
    {
        Console.Clear();
        Console.WriteLine($"Algo deu errado: {ex.Message}");
        Console.WriteLine("Aperte qualquer tecla para voltar ao Menu...");
        Console.ReadKey();
        Screen();
    }
}