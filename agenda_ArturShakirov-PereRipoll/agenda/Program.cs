bool sortir = false;
char opcio;
string textOpcio, nom = "", cognom1 = "", cognom2, operador, DNI, correuElectronic, liniaIntroduir, opcioNoms, liniaFitxer;
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
            Console.Write("\nIntrodueix el nom: ");
            opcioNoms = "nom";
            nom = DemanarNoms(opcioNoms);
            Console.WriteLine(nom);
            opcioNoms = "primer cognom";
            Console.Write("Introdueix el primer cognom: ");
            cognom1 = DemanarNoms(opcioNoms);
            opcioNoms = "c2";
            Console.Write("Introdueix el segon cognom: ");
            cognom2 = DemanarNoms(opcioNoms);
            DNI = DemanarDNI();
            dataNaix = DataNaix();
            correuElectronic = DemanarCorreu();
            liniaIntroduir = nom + ',' + cognom1 + ',' + cognom2 + ',' + DNI + ',' + dataNaix + ',' + correuElectronic;
            MostrarElements(liniaIntroduir, textOpcio);
            EscripturaFitxer(liniaIntroduir);
            Contador();
            break;
        case '2':
            textOpcio = "Recuperar usuari.";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Console.Write("Introdueix un el nom de l'usuari que vols recuperar:");
            opcioNoms = "nom";
            nom=AutocompletarNoms(textOpcio);
            liniaFitxer = BuscarLiniaFitxer(nom, opcioNoms, textOpcio);
            if (liniaFitxer != "")
            {
                liniaIntroduir = liniaFitxer;
                MostrarElements(liniaIntroduir, textOpcio);
            }
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

    static string DemanarNoms(string opcioNoms)
    {
        string operador = "";
        char caracter = ' ';
        operador = Console.ReadLine();
        while (operador == "" && (opcioNoms == "nom" || opcioNoms == "primer cognom"))
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1); // Mueve el cursor a la línea anterior
            Console.Write("\r" + "Introdueix el " + opcioNoms + ": ");
            operador = Console.ReadLine();
        }
        if (operador != "")
        {
            operador = paraulaNeta(operador);
        }
        return operador;
    }

    static string paraulaNeta(string operador)
    {
        char caracter = ' ';
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
        string DNI = "";
        bool validat = false;
        Console.Write("Introdueix el DNI:");
        while (!validat)
        {
            DNI = Console.ReadLine();
            if (DNI != "")
            {
                DNI = DNI.ToUpper();
                validat = ComprovarDNI(DNI);
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1); // Mueve el cursor a la línea anterior
                Console.Write("\r" + "Introdueix el DNI: ");
            }
        }
        return DNI;
    }
    static bool ComprovarDNI(string DNI)
    {
        int numDNI;
        char lletraIntroduida, lletraCorrecte = 'Z';
        bool validat = false;
        lletraIntroduida = DNI[DNI.Length - 1];
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
        fitxerSW = new StreamWriter("agenda.txt", true);
        fitxerSW.WriteLine(liniaIntroduir);
        fitxerSW.Close();
    }
    static string BuscarLiniaFitxer(string nom, string opcioNoms, string textOpcio)
    {
        StreamReader fitxerSR;
        string liniaFitxer = "", auxiliar;
        bool trobat = false;
        char decisiu = 'n';
        while (!trobat)
        {
            fitxerSR = new StreamReader("agenda.txt");
            while (!trobat && !fitxerSR.EndOfStream)
            {
                liniaFitxer = fitxerSR.ReadLine();
                auxiliar = liniaFitxer.Substring(0, liniaFitxer.IndexOf(','));
                if (auxiliar == nom)
                    trobat = true;
            }
            fitxerSR.Close();
            if (!trobat)
            {
                Console.Clear();
                Console.WriteLine(Capcelera());
                Console.WriteLine(CapceleraOpcio(textOpcio));
                Console.Write("El nom introduit no esta a l'agenda vols introduir-ne un altre? Introdueix una 's', per introduir-ne un altre i una 'n' per no fer-ho.");
                decisiu = Console.ReadKey().KeyChar;
                Console.Clear();
                Console.WriteLine(Capcelera());
                Console.WriteLine(CapceleraOpcio(textOpcio));
                if (decisiu == 's' || decisiu == 'S')
                {
                    Console.WriteLine("Nom: ");
                    nom = AutocompletarNoms(textOpcio);
                }
                else
                {
                    trobat = true;
                    liniaFitxer = "";
                }
            }
        }
        return liniaFitxer;
    }
    static void MostrarElements(string liniaIntroduir, string textOpcio)
    {
        Console.Clear();
        Console.WriteLine(Capcelera());
        Console.WriteLine(CapceleraOpcio(textOpcio));
        Console.WriteLine("Nom= " + liniaIntroduir.Substring(0, liniaIntroduir.IndexOf(',')));
        liniaIntroduir = liniaIntroduir.Substring(liniaIntroduir.IndexOf(',') + 1);
        Console.WriteLine("Cognom 1= " + liniaIntroduir.Substring(0, liniaIntroduir.IndexOf(',')));
        liniaIntroduir = liniaIntroduir.Substring(liniaIntroduir.IndexOf(',') + 1);
        Console.WriteLine("Cognom 2= " + liniaIntroduir.Substring(0, liniaIntroduir.IndexOf(',')));
        liniaIntroduir = liniaIntroduir.Substring(liniaIntroduir.IndexOf(',') + 1);
        Console.WriteLine("DNI= " + liniaIntroduir.Substring(0, liniaIntroduir.IndexOf(',')));
        liniaIntroduir = liniaIntroduir.Substring(liniaIntroduir.IndexOf(',') + 1);
        Console.WriteLine("Data de naixement= " + liniaIntroduir.Substring(0, liniaIntroduir.IndexOf(',')));
        liniaIntroduir = liniaIntroduir.Substring(liniaIntroduir.IndexOf(',') + 1);
        Console.WriteLine("Correu electrònic= " + liniaIntroduir);
    }
    static string AutocompletarNoms(string textOpcio)
    {
        StreamReader fitxerSR;
        char caracterActual;
        string nom = "", nomsPossibles = "/", nomLinia;
        bool igual = true, sortida=false;
        int cont = 0;
        while (nom != nomsPossibles&&!sortida)
        {
            nomsPossibles = "";
            caracterActual = Console.ReadKey().KeyChar;
            nom = nom + caracterActual;
            if (nom.Length == 1)
                nom = nom.ToUpper();
            fitxerSR = new StreamReader("agenda.txt");
            while (!fitxerSR.EndOfStream)
            {
                igual = true;
                nomLinia = fitxerSR.ReadLine();
                nomLinia = nomLinia.Substring(0, nomLinia.IndexOf(','));
                for (int i = 0; i != nom.Length && igual; i++)
                {
                    if (nomLinia[i] != nom[i])
                        igual = false;
                }
                if (igual)
                {
                    nomsPossibles = nomsPossibles + nomLinia+'/';
                    cont++;
                }
            }
            fitxerSR.Close();
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Console.WriteLine("Nom: ");
            Console.WriteLine(nom);
            if (cont == 0)
            {
                Console.WriteLine("No coincideix cap nom amb el que s'ha introduit.");
                sortida = true;
            }
            else Console.WriteLine("Noms possibles: " + nomsPossibles);
            cont = 0;
            if (!sortida)
                nomsPossibles = nomsPossibles.Substring(0, nomsPossibles.IndexOf('/'));
        }
        return nom;
    }

} while (!sortir);