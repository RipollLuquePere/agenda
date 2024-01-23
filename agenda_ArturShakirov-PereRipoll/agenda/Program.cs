using System.Runtime.ExceptionServices;

int num1, num2;
bool sortir = false;
char opcio;
string textOpcio, nom, cognom1, cognom2, operador, DNI, correuElectronic, liniaIntroduir;
DateTime dataNaix;



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
            textOpcio = "Donar d'alta usuari.";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Console.Write("Introdueix el nom:");
            nom = DemanarNoms();
            Console.Write("Introdueix el primer cognom:");
            cognom1 = DemanarNoms();
            Console.Write("Introdueix el segon cognom:");
            cognom2 = DemanarNoms();
            DNI = DemanarDNI();
            dataNaix = DataNaix();
            correuElectronic = DemanarCorreu();
            Console.WriteLine("Nom: " + nom);
            Console.WriteLine("Cognom 1: " + cognom1);
            Console.WriteLine("Cognom 2: " + cognom2);
            Console.WriteLine("DNI: " + DNI);
            Console.WriteLine("Data de naixement: " + dataNaix);//FALTA MOSTRAR EDAT ACTUAL AL COSTAT DE DATANAIX.
            Console.WriteLine("Correu electronic: " + correuElectronic);
            liniaIntroduir = nom + ',' + cognom1 + ',' + cognom2 + ',' + DNI + ',' + dataNaix + ',' + correuElectronic;
            EscripturaFitxer(liniaIntroduir);
            Contador();
            break;
        case '2':
            textOpcio = "Recuperar usuari.";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Contador();
            break;
        case '3':
            textOpcio = "Modificar usuari.";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Contador();
            break;
        case '4':
            textOpcio = "Eliminar usuari.";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Contador();
            break;
        case '5':
            textOpcio = "Mostrar agenda.";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Contador();
            break;
        case '6':
            textOpcio = "Ordenar agenda.";
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
                    "║         \x1b[31mAGENDA\x1b[30m                 ║\n" +
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

    static string DemanarNoms()
    {
        string operador;
        char caracter = 'p';
        operador = Console.ReadLine();
        operador = operador.ToLower();
        for (int cont = 0; cont < operador.Length - 1; cont++)
        {
            caracter = operador[cont];
            if (caracter < 'a' || caracter > 'z')
            {
                operador = operador.Remove(operador.IndexOf(caracter), 1);
                cont--;
            }
        }
        operador = operador.Substring(0, 1).ToUpper() + operador.Substring(1, operador.Length - 1);
        return operador;
    }
    static string DemanarDNI()
    {
        string DNI = "nn";
        bool validat = false;
        while (!validat)
        {
            Console.WriteLine("Introdueix el DNI:");
            DNI = Console.ReadLine();
            DNI = DNI.ToUpper();
            validat = ComprovarDNI(DNI);
        }
        return DNI;
    }
    static bool ComprovarDNI(string DNI)
    {
        int numDNI;
        char lletraIntroduida, lletraCorrecte = 'Z';
        bool validat = false;
        lletraIntroduida = DNI[DNI.Length - 1];
        Console.WriteLine(lletraIntroduida);
        numDNI = Convert.ToInt32(DNI.Substring(0, DNI.Length - 1));
        numDNI = numDNI % 23;
        switch (numDNI)
        {
            case 0:
                lletraCorrecte = 'T';
                break;
            case 1:
                lletraCorrecte = 'R';
                break;
            case 2:
                lletraCorrecte = 'W';
                break;
            case 3:
                lletraCorrecte = 'A';
                break;
            case 4:
                lletraCorrecte = 'G';
                break;
            case 5:
                lletraCorrecte = 'M';
                break;
            case 6:
                lletraCorrecte = 'Y';
                break;
            case 7:
                lletraCorrecte = 'F';
                break;
            case 8:
                lletraCorrecte = 'P';
                break;
            case 9:
                lletraCorrecte = 'D';
                break;
            case 10:
                lletraCorrecte = 'X';
                break;
            case 11:
                lletraCorrecte = 'B';
                break;
            case 12:
                lletraCorrecte = 'N';
                break;
            case 13:
                lletraCorrecte = 'J';
                break;
            case 14:
                lletraCorrecte = 'Z';
                break;
            case 15:
                lletraCorrecte = 'S';
                break;
            case 16:
                lletraCorrecte = 'Q';
                break;
            case 17:
                lletraCorrecte = 'V';
                break;
            case 18:
                lletraCorrecte = 'H';
                break;
            case 19:
                lletraCorrecte = 'L';
                break;
            case 20:
                lletraCorrecte = 'C';
                break;
            case 21:
                lletraCorrecte = 'K';
                break;
            case 22:
                lletraCorrecte = 'E';
                break;
        }
        if (lletraCorrecte == lletraIntroduida)
        {
            validat = true;
            Console.WriteLine("DNI correcte.");
        }
        else Console.WriteLine("DNI incorrecte, s'haura de tornar a introduir.");
        return validat;
    }
    static DateTime DataNaix()
    {
        DateTime dataNaix = DateTime.Now;
        bool validat = false;
        int any, mes = 0, dia;
        while (!validat)
        {
            mes = 0;
            dia = 0;
            Console.WriteLine("Introdueix la teva data de naixement. Any:");
            any = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Mes:");
            while (mes > 12 || mes < 1)
            {
                mes = Convert.ToInt32(Console.ReadLine());
                if (mes > 12 || mes < 1)
                    Console.WriteLine("Mes introduit incorrecte, introdueix-ne un de valid.");
            }
            Console.WriteLine("Dia:");
            while (dia > 31 || dia < 1)
            {
                dia = Convert.ToInt32(Console.ReadLine());
                if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                {
                    if (dia > 31 || dia < 1)
                    {
                        Console.WriteLine("Dia mal introduit hauras d'introduir-ne un altre.");
                        dia = 0;
                    }
                }
                else if (mes == 2 && (dia < 1 || dia > 29))
                {
                    Console.WriteLine("Dia mal introduit hauras d'introduir-ne un altre.");
                    dia = 0;
                }
                else
                {
                    if (dia < 1 || dia > 30)
                    {
                        Console.WriteLine("Dia mal introduit hauras d'introduir-ne un altre.");
                        dia = 0;
                    }
                }
            }
            dataNaix = new DateTime(any, mes, dia);
            validat = ComprovacioDataNaix(dataNaix);
        }
        return dataNaix;
    }
    static bool ComprovacioDataNaix(DateTime dataNaix)
    {
        int any, mes, dia;
        bool valid = true; ;
        any = dataNaix.Year;
        mes = dataNaix.Month;
        dia = dataNaix.Day;
        if (DateTime.IsLeapYear(any) == true)
        {
            if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
            {
                if (dia > 31 || dia < 1)
                    valid = false;
            }
            else if (mes == 2 && (dia < 1 || dia > 29))
                valid = false;
            else
            {
                if (dia < 1 || dia > 30)
                    valid = false;
            }
        }
        else
        {
            if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
            {
                if (dia > 31 || dia < 1)
                    valid = false;
            }
            else if (mes == 2 && (dia > 28 || dia < 1))
                valid = false;
            else
            {
                if (dia < 1 || dia > 30)
                    valid = false;
            }
        }
        if (dataNaix > DateTime.Now)
        {
            valid = false;
            Console.WriteLine("Data introduida incorrecte, torna-la a introduir.");
        }
        return valid;
    }
    static string DemanarCorreu()
    {
        string correu = "", operador, original = "";
        char caracter = ' ';
        bool valid = false;
        int contCaracters = 0;
        while (!valid)
        {//VALIDAR S'HAURIA DE FER AMB REGEX, ARA FUNCIONA PERO NO ESTA FET AMB REGEX.
            valid = false;
            Console.WriteLine("Introdueix una adreça de correu electronic valida:");
            correu = Console.ReadLine();
            original = correu;
            operador = correu.Substring(0, correu.IndexOf('@')).ToLower();
            for (int cont = 0; cont < operador.Length && contCaracters < 3; cont++)
            {
                caracter = operador[cont];
                contCaracters++;
            }
            if (contCaracters >= 3)
                valid = true;
            correu = correu.Substring(correu.IndexOf('@') + 1);
            contCaracters = 0;
            operador = correu.Substring(0, correu.IndexOf('.')).ToLower();
            for (int cont = 0; cont < operador.Length && contCaracters < 3 && valid; cont++)
            {
                caracter = operador[cont];
                if (caracter >= 'a' && caracter <= 'z')
                    contCaracters++;
                else valid = false;
            }
            if (contCaracters < 3 && valid)
                valid = false;
            correu = correu.Substring(correu.IndexOf('.') + 1);
            if (correu != "com" && correu != "es" && correu != "cat" && valid)
                valid = false;
        }
        return original;
    }
    static void EscripturaFitxer(string liniaIntroduir)
    {
        StreamWriter fitxerSW;
        StreamReader fitxerSR;
        string contingutFitxerOriginal = "", linia;
        fitxerSR = new StreamReader("agenda.txt");
        while (!fitxerSR.EndOfStream)
        {
            linia = fitxerSR.ReadLine();
            contingutFitxerOriginal = contingutFitxerOriginal + '\r' + linia;
        }
        fitxerSR.Close();
        contingutFitxerOriginal = contingutFitxerOriginal + '\r' + liniaIntroduir;
        fitxerSW = new StreamWriter("agenda.txt");
        fitxerSW.WriteLine(contingutFitxerOriginal);
        fitxerSW.Close();
    }

} while (!sortir);