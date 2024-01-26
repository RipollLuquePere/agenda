<<<<<<< HEAD
﻿using System.Linq.Expressions;
using System.Text.RegularExpressions;

double edat;
bool sortir = false;
char opcio;
string textOpcio, nom, cognom1, cognom2, operador, DNI, telefon, correuElectronic, liniaIntroduir, liniaFitxer, opcioNoms;
=======
using System.Linq.Expressions;
using System.Text.RegularExpressions;

bool sortir = false;
char opcio;
string textOpcio, nom = "", cognom1 = "", cognom2, operador, DNI, telefon, correuElectronic, liniaIntroduir, opcioNoms, liniaFitxer;
>>>>>>> develop
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
            opcioNoms = "nom";
            Console.Write("\nIntrodueix el nom: ");
<<<<<<< HEAD
=======
            opcioNoms = "nom";
>>>>>>> develop
            nom = DemanarNoms(opcioNoms);
            opcioNoms = "primer cognom";
            Console.Write("Introdueix el primer cognom: ");
            cognom1 = DemanarNoms(opcioNoms);
            opcioNoms = "c2";
            Console.Write("Introdueix el segon cognom: ");
            cognom2 = DemanarNoms(opcioNoms);
            DNI = DemanarDNI();
            telefon = DemanarTlf();
            dataNaix = DataNaix();
            correuElectronic = DemanarCorreu();
<<<<<<< HEAD
            Console.WriteLine("Nom: " + nom);
            Console.WriteLine("Primer cognom: " + cognom1);
            Console.WriteLine("Segon cognom: " + cognom2);
            Console.WriteLine("DNI: " + DNI);
            Console.WriteLine("Telefon: " + telefon);
            Console.WriteLine("Data de naixement: " + dataNaix);//FALTA MOSTRAR EDAT ACTUAL AL COSTAT DE DATANAIX.
            Console.WriteLine("Correu electronic: " + correuElectronic);
            liniaIntroduir = nom + ',' + cognom1 + ',' + cognom2 + ',' + DNI + ',' + dataNaix + ',' + correuElectronic;
            edat = CalcularEdat(dataNaix);
            MostrarElements(liniaIntroduir, textOpcio, edat);
=======
            liniaIntroduir = nom + ',' + cognom1 + ',' + cognom2 + ',' + DNI + ',' + telefon + ',' + dataNaix.ToString("d") + ',' + correuElectronic;
            MostrarElements(liniaIntroduir, textOpcio);
>>>>>>> develop
            EscripturaFitxer(liniaIntroduir);
            Contador();
            break;
        case '2':
            textOpcio = "Recuperar usuari.";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
<<<<<<< HEAD
            Console.Write("Introdueix un el nom de l'usuari que vols recuperar:");
            opcioNoms = "nom";
            nom = AutocompletarNoms(textOpcio);
=======
            Console.Write("\nIntrodueix un el nom de l'usuari que vols recuperar:");
            opcioNoms = "nom";
            nom=AutocompletarNoms(textOpcio);
>>>>>>> develop
            liniaFitxer = BuscarLiniaFitxer(nom, opcioNoms, textOpcio);
            if (liniaFitxer != "")
            {
                liniaIntroduir = liniaFitxer;
                MostrarElements(liniaIntroduir, textOpcio);
            }
<<<<<<< HEAD
            Contador();
=======
>>>>>>> develop
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
            MostrarContingut();
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
        int contador = 2;

        Console.WriteLine("\n");
        Console.Write("Temps per tornar al menú: 3\r");
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
<<<<<<< HEAD
            Console.Write("\r"+"Introdueix el " + opcioNoms + ": ");
=======
            Console.Write("\r" + "Introdueix el " + opcioNoms + ": ");
>>>>>>> develop
            operador = Console.ReadLine();
        }
        if (operador != "")
        {
            operador = operador.ToLower();
            for (int cont = 0; cont < operador.Length; cont++)
            {
                caracter = operador[cont];
                if (caracter < 'a' || caracter > 'z')
                {
                    operador = operador.Remove(operador.IndexOf(caracter), 1);
                    cont--;
                }
            }
            operador = operador.Substring(0, 1).ToUpper() + operador.Substring(1, operador.Length - 1);
        }
        return operador;
    }

    static string DemanarDNI()
    {
        string DNI = "";
        bool validat = false;
<<<<<<< HEAD
=======
        Regex regex = new Regex(@"^\d{8}[a-z]$");

>>>>>>> develop
        Console.Write("Introdueix el DNI: ");
        while (!validat)
        {
            DNI = Console.ReadLine();
            if (DNI != "")
            {
<<<<<<< HEAD
                DNI = DNI.ToUpper();
                validat = ComprovarDNI(DNI);
=======
                if (regex.IsMatch(DNI))
                {
                    DNI = DNI.ToUpper();
                    validat = ComprovarDNI(DNI);
                }
>>>>>>> develop

                if (!validat)
                {
                    Console.WriteLine("DNI incorrecte.");
                    Console.Write("Introdueix el DNI: ");
                }
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
        return validat;
    }

    static string DemanarTlf()
<<<<<<< HEAD
=======
    {
        string telefon = "";
        bool validat = false;

        Console.Write("Introdueix el telefon: ");
        while (!validat)
        {
            telefon = Console.ReadLine();

            if (telefon != "")
            {
                validat = ValidarTlf(telefon);

                if (!validat)
                {
                    Console.WriteLine("Telefon incorrecte.");
                    Console.Write("Introdueix el telefon: ");
                }
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1); // Mueve el cursor a la línea anterior
                Console.Write("\r" + "Introdueix el telefon: ");
            }
        }
        return telefon;
    }

    static bool ValidarTlf(string telefon)
    {
        // Utilizem una expressió Regex per verificar si el telefon es valid
        // ^ indica el començament de la cadena, \d indica un dígit, {9} especifica la quantitat de dígits, en aquest cas 9, $ indica el final de la cadena
        Regex regex = new Regex(@"^\d{9}$");

        return regex.IsMatch(telefon);
    }

    static DateTime DataNaix()
>>>>>>> develop
    {
        string telefon = "";
        bool validat = false;
<<<<<<< HEAD

        Console.Write("Introdueix el telefon: ");
        while (!validat)
        {
            telefon = Console.ReadLine();

            if (telefon != "")
            {
                validat = ValidarTlf(telefon);

                if (!validat)
                {
                    Console.WriteLine("Telefon incorrecte.");
                    Console.Write("Introdueix el telefon: ");
                }
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1); // Mueve el cursor a la línea anterior
                Console.Write("\r" + "Introdueix el telefon: ");
            }
        }
        return telefon;
    }

    static bool ValidarTlf(string telefon)
    {
        // Utilizem una expressió Regex per verificar si el telefon es valid
        // ^ indica el començament de la cadena, \d indica un dígit, {9} especifica la quantitat de dígits, en aquest cas 9, $ indica el final de la cadena
        Regex regex = new Regex(@"^\d{9}$");

        return regex.IsMatch(telefon);
    }

    static DateTime DataNaix()
    {
        double edat;
        DateTime dataNaix = DateTime.Now;
        bool validat = false;
        int any = DateTime.Now.Year + 1, mes = 0, dia = 0;

        while (!validat)
        {
=======
        int any, mes, dia;

        while (!validat)
        {
            any = DateTime.Now.Year + 1;
            mes = 0;
            dia = 0;

>>>>>>> develop
            Console.WriteLine("Introdueix la teva data de naixement.");
            Console.Write("Any: ");
            while (any > DateTime.Now.Year)
            {
                any = Convert.ToInt32(Console.ReadLine());

                if (any > DateTime.Now.Year)
                {
                    Console.WriteLine("Any introduït incorrecte, introdueix-ne un de vàlid.");
                    Console.Write("Any: ");
                }
            }
<<<<<<< HEAD
            Console.Write("Mes:");
=======
            Console.Write("Mes: ");
>>>>>>> develop
            while (mes > 12 || mes < 1)
            {
                mes = Convert.ToInt32(Console.ReadLine());
                if (mes > 12 || mes < 1)
                {
                    Console.WriteLine("Mes introduit incorrecte, introdueix-ne un de valid.");
                    Console.Write("Mes: ");
                }
            }
<<<<<<< HEAD
            Console.Write("Dia:");
=======
            Console.Write("Dia: ");
>>>>>>> develop
            while (dia > 31 || dia < 1)
            {
                dia = Convert.ToInt32(Console.ReadLine());
                if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                {
                    if (dia > 31 || dia < 1)
                    {
                        Console.WriteLine("Dia mal introduit hauras d'introduir-ne un altre.");
<<<<<<< HEAD
                        Console.Write("Dia:");
=======
                        Console.Write("Dia: ");
>>>>>>> develop
                        dia = 0;
                    }
                }
                else if (mes == 2 && (dia < 1 || dia > 29))
                {
                    Console.WriteLine("Dia mal introduit hauras d'introduir-ne un altre.");
<<<<<<< HEAD
                    Console.Write("Dia:");
=======
                    Console.Write("Dia: ");
>>>>>>> develop
                    dia = 0;
                }
                else
                {
                    if (dia < 1 || dia > 30)
                    {
                        Console.WriteLine("Dia mal introduit hauras d'introduir-ne un altre.");
<<<<<<< HEAD
                        Console.Write("Dia:");
=======
                        Console.Write("Dia: ");
>>>>>>> develop
                        dia = 0;
                    }
                }
            }
            dataNaix = new DateTime(any, mes, dia);
            validat = ComprovacioDataNaix(dataNaix);
        }
        return dataNaix;
    }

    static double CalcularEdat(DateTime dataNaix)
    {
        double edat;

        edat = Math.Truncate(Math.Round((DateTime.Now.Date - dataNaix.Date).Days / 365.25, 2));
        return edat;
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
        string correu, operador, original = "";
        bool valid = false;
        while (!valid)
        {
            valid = false;
            Console.WriteLine("Introdueix una adreça de correu electronic valida:");
            correu = Console.ReadLine();
            original = correu;
            valid = ValidarCorreu(original);
        }
        return original;
    }

    static bool ValidarCorreu(string original)
    {
<<<<<<< HEAD
        string patron = @"^[a-z0-9]{3,}@[a-z]{3,}\.(com|es)$";
        Regex regex = new Regex(patron);
=======
        Regex regex = new Regex(@"^[a-z0-9]{3,}@[a-z]{3,}\.(com|es)$");
>>>>>>> develop

        original = original.ToLower();

        return regex.IsMatch(original);
    }

    static void EscripturaFitxer(string liniaIntroduir)
    {
        StreamWriter fitxerSW = new StreamWriter("agenda.txt", true);
        fitxerSW.WriteLine(liniaIntroduir);
        fitxerSW.Close();
    }

    static void MostrarContingut()
    {
        string linia;

        StreamReader fitxerSW = new StreamReader("agenda.txt");
        Console.WriteLine("");
        while (!fitxerSW.EndOfStream)
        {
            linia = fitxerSW.ReadLine();
            Console.WriteLine(linia);
        }
        fitxerSW.Close();
    }

    static string BuscarLiniaFitxer(string nom, string opcioNoms, string textOpcio)
    {
        StreamReader fitxerSR;
        string liniaFitxer = "", auxiliar;
        bool trobat = false;
<<<<<<< HEAD
        char decisiu = 'n';
=======
        char decisiu;
>>>>>>> develop
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
<<<<<<< HEAD
                Console.Write("El nom introduit no esta a l'agenda vols introduir-ne un altre? Introdueix una 's', per introduir-ne un altre i una 'n' per no fer-ho.");
=======
                Console.WriteLine("\nEl nom introduit no esta a l'agenda, vols introduir-ne un altre? Introdueix una 'S', per introduir-ne un altre o una 'N' per no fer-ho.");
>>>>>>> develop
                decisiu = Console.ReadKey().KeyChar;
                Console.Clear();
                Console.WriteLine(Capcelera());
                Console.WriteLine(CapceleraOpcio(textOpcio));
                if (decisiu == 's' || decisiu == 'S')
                {
<<<<<<< HEAD
                    Console.WriteLine("Nom: ");
=======
                    Console.WriteLine("\nNom: ");
>>>>>>> develop
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
<<<<<<< HEAD

=======
>>>>>>> develop
    static void MostrarElements(string liniaIntroduir, string textOpcio)
    {
        Console.Clear();
        Console.WriteLine(Capcelera());
        Console.WriteLine(CapceleraOpcio(textOpcio));
<<<<<<< HEAD
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

=======
        Console.WriteLine("\nNom: " + liniaIntroduir.Substring(0, liniaIntroduir.IndexOf(',')));
        liniaIntroduir = liniaIntroduir.Substring(liniaIntroduir.IndexOf(',') + 1);
        Console.WriteLine("Primer cognom: " + liniaIntroduir.Substring(0, liniaIntroduir.IndexOf(',')));
        liniaIntroduir = liniaIntroduir.Substring(liniaIntroduir.IndexOf(',') + 1);
        Console.WriteLine("Segon cognom: " + liniaIntroduir.Substring(0, liniaIntroduir.IndexOf(',')));
        liniaIntroduir = liniaIntroduir.Substring(liniaIntroduir.IndexOf(',') + 1);
        Console.WriteLine("DNI: " + liniaIntroduir.Substring(0, liniaIntroduir.IndexOf(',')));
        liniaIntroduir = liniaIntroduir.Substring(liniaIntroduir.IndexOf(',') + 1);
        Console.WriteLine("Telefon: " + liniaIntroduir.Substring(0, liniaIntroduir.IndexOf(',')));
        liniaIntroduir = liniaIntroduir.Substring(liniaIntroduir.IndexOf(',') + 1);
        Console.WriteLine("Data de naixement: " + liniaIntroduir.Substring(0, liniaIntroduir.IndexOf(',')));
        liniaIntroduir = liniaIntroduir.Substring(liniaIntroduir.IndexOf(',') + 1);
        Console.WriteLine("Correu electrònic: " + liniaIntroduir);
    }
>>>>>>> develop
    static string AutocompletarNoms(string textOpcio)
    {
        StreamReader fitxerSR;
        char caracterActual;
        string nom = "", nomsPossibles = "/", nomLinia;
<<<<<<< HEAD
        bool igual = true, sortida = false;
        int cont = 0;
        while (nom != nomsPossibles && !sortida)
=======
        bool igual, sortida=false;
        int cont = 0;
        while (nom != nomsPossibles&&!sortida)
>>>>>>> develop
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
<<<<<<< HEAD
                    nomsPossibles = nomsPossibles + nomLinia + '/';
=======
                    nomsPossibles = nomsPossibles + nomLinia+'/';
>>>>>>> develop
                    cont++;
                }
            }
            fitxerSR.Close();
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
<<<<<<< HEAD
            Console.WriteLine("Nom: ");
=======
            Console.Write("\nNom: ");
>>>>>>> develop
            Console.WriteLine(nom);
            if (cont == 0)
            {
                Console.WriteLine("No coincideix cap nom amb el que s'ha introduit.");
                sortida = true;
<<<<<<< HEAD
            }
            else Console.WriteLine("Noms possibles: " + nomsPossibles);
=======
                Contador();
            }
            else Console.Write("Possibles noms: " + nomsPossibles);
>>>>>>> develop
            cont = 0;
            if (!sortida)
                nomsPossibles = nomsPossibles.Substring(0, nomsPossibles.IndexOf('/'));
        }
        return nom;
    }

} while (!sortir);