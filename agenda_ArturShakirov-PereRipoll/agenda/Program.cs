int num1, num2;
bool sortir = false;
char opcio;
string textOpcio;



do
{
    Console.Clear();
    Console.WriteLine(Menu());
    Console.WriteLine("────────────────────");
    Console.Write("Introdueix una opció: ");
    opcio = Console.ReadKey().KeyChar;

    switch (opcio)
    {
        case '0' or 'q' or 'Q':
            sortir = true;
            break;
        case '1':
            textOpcio = "Donar d'alta usuari";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Contador();
            break;
        case '2':
            textOpcio = "Recuperar usuari";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Contador();
            break;
        case '3':
            textOpcio = "Modificar usuari";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Contador();
            break;
        case '4':
            textOpcio = "Eliminar usuari";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Contador();
            break;
        case '5':
            textOpcio = "Mostrar agenda";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Contador();
            break;
        case '6':
            textOpcio = "Ordenar agenda";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Contador();
            break;
    }

    static string Menu()
    {
        string menu;

        Console.WriteLine(Capcelera());
        menu = "\x1b[43m\x1b[30m╔════════════════════════════════╗\n" +
               "║                                ║\n" +
               "║     1. Donar d'alta usuari     ║\n" +
               "║     ----------------------     ║\n" +
               "║     2. Recuperar usuari        ║\n" +
               "║     ----------------------     ║\n" +
               "║     3. Modificar usuari        ║\n" +
               "║     ----------------------     ║\n" +
               "║     4. Eliminar usuari         ║\n" +
               "║     ----------------------     ║\n" +
               "║     5. Mostrar agenda          ║\n" +
               "║     ----------------------     ║\n" +
               "║     6. Ordenar agenda          ║\n" +
               "║                                ║\n" +
               "║     ----------------------     ║\n" +
               "║     \x1b[31mQ. SORTIR\x1b[30m                  ║\n" +
               "║                                ║\n" +
               "╚════════════════════════════════╝\n\x1b[0m";


        return menu;
    }

    static string Capcelera()
    {
        string capcelera;

        capcelera = "\x1b[43m\x1b[30m╔════════════════════════════════╗\n" +
                    "║             \x1b[31mAGENDA\x1b[30m             ║\n" +
                    "╚════════════════════════════════╝\x1b[0m";

        return capcelera;
    }

    static string CapceleraOpcio(string textOpcio)
    {
        string capceleraOpcio, linies = "";
        int contador;

        for (contador = 0; contador < textOpcio.Length; contador++)
        {
            linies = linies + "═";
        }

        capceleraOpcio = "╔══" + linies + "══╗\n" +
                         "║  " + textOpcio + "  ║\n" +
                         "╚══" + linies + "══╝";

        return capceleraOpcio;
    }

    static void Contador()
    {
        int contador = 4;

        Console.WriteLine("\n");
        Console.Write("Temps per tornar al menú: 5\r");
        while (contador >= 0)
        {
            Thread.Sleep(1000);
            Console.Write("Temps per tornar al menú: " + contador + "\r");
            contador--;
        }
    }

} while (!sortir);