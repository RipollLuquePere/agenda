using System.Text.RegularExpressions;

double edat;
bool sortir = false;
char opcio, caracterDecisio;
string textOpcio, nom = "", cognom1 = "", cognom2, operador, DNI, telefon, correuElectronic, liniaIntroduir, opcioNoms, liniaFitxer, dadaModificar;
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
            liniaIntroduir = nom + ',' + cognom1 + ',' + cognom2 + ',' + DNI + ',' + telefon + ',' + dataNaix.ToString("d") + ',' + correuElectronic;
            MostrarElements(liniaIntroduir, textOpcio);
            Contador();
            EscripturaFitxer(liniaIntroduir);
            break;
        case '2':
            textOpcio = "Recuperar usuari.";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Console.Write("\nIntrodueix el nom de l'usuari que vols recuperar (no cal INTRO): ");
            opcioNoms = "nom";
            nom = AutocompletarNoms(textOpcio);
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
            Console.Write("\nIntrodueix el nom de l'usuari que vols modificar: ");
            opcioNoms = "nom";
            nom = AutocompletarNoms(textOpcio);
            liniaFitxer = BuscarLiniaFitxer(nom, opcioNoms, textOpcio);
            if (liniaFitxer != "")
            {
                liniaIntroduir = liniaFitxer;
                MostrarElements(liniaIntroduir, textOpcio);
                DadaModificar(liniaFitxer, opcioNoms);
            }
            Contador();
            break;
        case '4':
            textOpcio = "Eliminar usuari.";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Console.Write("\nIntrodueix el nom de l'usuari que vols eliminar:");
            opcioNoms = "nom";
            nom = AutocompletarNoms(textOpcio);
            liniaFitxer = BuscarLiniaFitxer(nom, opcioNoms, textOpcio);
            if (liniaFitxer != "")
            {
                liniaIntroduir = liniaFitxer;
                MostrarElements(liniaIntroduir, textOpcio);
                Console.Write("\nEstas segur d'eliminar l'usuari que es mostra en pantalla? (s/n): ");
                caracterDecisio = Console.ReadKey().KeyChar;
                if (caracterDecisio == 's' || caracterDecisio == 'S')
                    EliminarUsuari(liniaFitxer);
            }
            Contador();
            break;
        case '5':
            textOpcio = "Mostrar agenda.";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            MostrarAgenda();
            PremeuPerTornar();
            break;
        case '6':
            textOpcio = "Ordenar agenda.";
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            OrdenarAgenda();
            Contador();
            break;
    }

    static string Menu()
    {
        string menu;

        Console.WriteLine(Capcelera());
        menu = "\x1b[47m\x1b[30m╔════════════════════════════════╗\n" +
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

        capcelera = "\x1b[47m\x1b[30m╔════════════════════════════════╗\n" +
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
        int contador = 2;

        Console.WriteLine("\n");
        Console.Write("Temps per tornar al menú: " + (contador + 1) + "\r");
        while (contador >= 0)
        {
            Thread.Sleep(1000);
            Console.Write("Temps per tornar al menú: " + contador + "\r");
            contador--;
        }
    }

    static void PremeuPerTornar()
    {
        char opcio;

        Console.Write("\nPremeu qualsevol tecla per tornar al menú: ");

        opcio = Console.ReadKey().KeyChar;
    }

    static string DemanarNoms(string opcioNoms)
    {
        string operador = "";
        char caracter = ' ';

        operador = Console.ReadLine();
        while (operador == "" && (opcioNoms == "nom" || opcioNoms == "primer cognom"))
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write("\r" + "Introdueix el " + opcioNoms + ": ");
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
        Regex regex = new Regex(@"^\d{8}[a-zA-Z]$");

        Console.Write("Introdueix el DNI: ");
        while (!validat)
        {
            DNI = Console.ReadLine();
            if (DNI != "")
            {
                if (regex.IsMatch(DNI))
                {
                    DNI = DNI.ToUpper();
                    validat = ComprovarDNI(DNI);
                }

                if (!validat)
                {
                    Console.WriteLine("DNI incorrecte.");
                    Console.Write("Introdueix el DNI: ");
                }
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
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
        string comprovadors = "TRWAGMYFPDXBNJZSQVHLCKE";
        lletraIntroduida = DNI[DNI.Length - 1];
        numDNI = Convert.ToInt32(DNI.Substring(0, DNI.Length - 1));
        numDNI = numDNI % 23;
        
        if (comprovadors[numDNI] == lletraIntroduida)
        {
            validat = true;
        }
        return validat;
    }

    static string DemanarTlf()
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
                Console.SetCursorPosition(0, Console.CursorTop - 1);
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
        DateTime dataNaix = DateTime.Now;
        bool validat = false;
        int any, mes, dia;

        while (!validat)
        {
            any = DateTime.Now.Year + 1;
            mes = 0;
            dia = 0;

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
            Console.Write("Mes: ");
            while (mes > 12 || mes < 1)
            {
                mes = Convert.ToInt32(Console.ReadLine());
                if (mes > 12 || mes < 1)
                {
                    Console.WriteLine("Mes introduit incorrecte, introdueix-ne un de valid.");
                    Console.Write("Mes: ");
                }
            }
            Console.Write("Dia: ");
            while (dia > 31 || dia < 1)
            {
                dia = Convert.ToInt32(Console.ReadLine());
                if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                {
                    if (dia > 31 || dia < 1)
                    {
                        Console.WriteLine("Dia mal introduit hauras d'introduir-ne un altre.");
                        Console.Write("Dia: ");
                        dia = 0;
                    }
                }
                else if (mes == 2 && (dia < 1 || dia > 29))
                {
                    Console.WriteLine("Dia mal introduit hauras d'introduir-ne un altre.");
                    Console.Write("Dia: ");
                    dia = 0;
                }
                else
                {
                    if (dia < 1 || dia > 30)
                    {
                        Console.WriteLine("Dia mal introduit hauras d'introduir-ne un altre.");
                        Console.Write("Dia: ");
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
            if (mes == 2 && (dia < 1 || dia > 29))
                valid = false;
        }
        else
        {
            if (mes == 2 && (dia > 28 || dia < 1))
                valid = false;
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
            Console.WriteLine("Introdueix una adreça de correu electronic valida: ");
            correu = Console.ReadLine();
            original = correu;
            valid = ValidarCorreu(original);
        }
        return original;
    }

    static bool ValidarCorreu(string original)
    {
        Regex regex = new Regex(@"^[a-z0-9]{3,}@[a-z]{3,}\.(com|es)$");

        original = original.ToLower();

        return regex.IsMatch(original);
    }

    static void EscripturaFitxer(string liniaIntroduir)
    {
        StreamWriter fitxerSW;
        fitxerSW = new StreamWriter("agenda.txt", true);
        fitxerSW.WriteLine(liniaIntroduir);
        fitxerSW.Close();
    }

    static void MostrarAgenda()
    {
        int linies = 0;
        string linia, nom, cognom1, cognom2, telefon, resumDadesMesGran = "zzzzz", resumDadesMesGranAnterior = "aaaaa", resumDades = "", liniaAuxiliar = "";

        StreamReader fitxerSR = new StreamReader("agenda.txt");
        Console.WriteLine("");

        while (!fitxerSR.EndOfStream)
        {
            linies++;
            linia = fitxerSR.ReadLine();
        }
        fitxerSR.Close();

        while (linies > 0)
        {
            StreamReader fitxerSR2 = new StreamReader("agenda.txt");
            while (!fitxerSR2.EndOfStream)
            {
                linia = fitxerSR2.ReadLine();

                if (linia != "")
                {
                    nom = linia.Substring(0, linia.IndexOf(","));
                    linia = linia.Substring(linia.IndexOf(",") + 1);
                    cognom1 = linia.Substring(0, linia.IndexOf(","));
                    linia = linia.Substring(linia.IndexOf(",") + 1);
                    cognom2 = linia.Substring(0, linia.IndexOf(","));
                    linia = linia.Substring(linia.IndexOf(",") + 1);
                    linia = linia.Substring(linia.IndexOf(",") + 1);
                    telefon = linia.Substring(0, linia.IndexOf(","));

                    resumDades = cognom1 + "," + cognom2 + "," + nom + "," + telefon;

                    if (resumDadesMesGran == resumDades)
                    {
                        linies--;
                    }

                    if (resumDades.CompareTo(resumDadesMesGran) < 0 && resumDades.CompareTo(resumDadesMesGranAnterior) > 0)
                    {
                        resumDadesMesGran = resumDades;
                        liniaAuxiliar = resumDadesMesGran;
                    }
                }
            }
            fitxerSR2.Close();

            cognom1 = liniaAuxiliar.Substring(0, liniaAuxiliar.IndexOf(","));
            liniaAuxiliar = liniaAuxiliar.Substring(liniaAuxiliar.IndexOf(",") + 1);
            cognom2 = liniaAuxiliar.Substring(0, liniaAuxiliar.IndexOf(","));
            liniaAuxiliar = liniaAuxiliar.Substring(liniaAuxiliar.IndexOf(",") + 1);
            nom = liniaAuxiliar.Substring(0, liniaAuxiliar.IndexOf(","));
            liniaAuxiliar = liniaAuxiliar.Substring(liniaAuxiliar.IndexOf(",") + 1);
            telefon = liniaAuxiliar;

            if (cognom2 == "")
                cognom2 = "---";

            Console.WriteLine(cognom1 + " " + cognom2 + ", " + nom + " | " + telefon);

            resumDadesMesGranAnterior = resumDadesMesGran;
            resumDadesMesGran = "zzzzz";

            linies--;
        }
    }

    static string BuscarLiniaFitxer(string nom, string opcioNoms, string textOpcio)
    {
        StreamReader fitxerSR;
        string liniaFitxer = "", auxiliar;
        bool trobat = false;
        char decisiu;
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
                Console.Write("\nEl nom introduit no esta a l'agenda, vols introduir-ne un altre?\nIntrodueix una 'S', per introduir-ne un altre o una 'N' per no fer-ho: ");
                decisiu = Console.ReadKey().KeyChar;
                Console.Clear();
                Console.WriteLine(Capcelera());
                Console.WriteLine(CapceleraOpcio(textOpcio));
                if (decisiu == 's' || decisiu == 'S')
                {
                    Console.Write("\nNom: ");
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
        double edat;
        DateTime dataNaix;

        Console.Clear();
        Console.WriteLine(Capcelera());
        Console.WriteLine(CapceleraOpcio(textOpcio));
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
        dataNaix = Convert.ToDateTime(liniaIntroduir.Substring(0, liniaIntroduir.IndexOf(',')));
        edat = CalcularEdat(dataNaix);
        Console.WriteLine("Data de naixement: " + dataNaix.ToString("d") + ", " + edat + " anys");
        liniaIntroduir = liniaIntroduir.Substring(liniaIntroduir.IndexOf(',') + 1);
        Console.WriteLine("Correu electrònic: " + liniaIntroduir);
    }

    static string AutocompletarNoms(string textOpcio)
    {
        StreamReader fitxerSR;
        char caracterActual;
        string nom = "", nomsPossibles = "/", nomLinia;
        bool igual, sortida = false;
        int cont = 0;
        while (nom != nomsPossibles && !sortida)
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
                if (nomLinia != "")
                {
                    nomLinia = nomLinia.Substring(0, nomLinia.IndexOf(','));
                    for (int i = 0; i != nom.Length && igual; i++)
                    {
                        if (nomLinia[i] != nom[i])
                            igual = false;
                    }
                    if (igual)
                    {
                        nomsPossibles = nomsPossibles + nomLinia + '/';
                        cont++;
                    }
                }
            }
            fitxerSR.Close();
            Console.Clear();
            Console.WriteLine(Capcelera());
            Console.WriteLine(CapceleraOpcio(textOpcio));
            Console.Write("\nNom: ");
            Console.WriteLine(nom);
            if (cont == 0)
            {
                //Console.WriteLine("Cap nom coincideix amb el que s'ha introduit.");
                sortida = true;
            }
            else Console.Write("Possibles noms: " + nomsPossibles);
            cont = 0;
            if (!sortida)
                nomsPossibles = nomsPossibles.Substring(0, nomsPossibles.IndexOf('/'));
        }
        return nom;
    }

    static void DadaModificar(string liniaFitxer, string opcioNoms)
    {
        StreamReader fitxerSR;
        string modificacio = "", liniaAuxiliar, dadaModificar = "", liniaActual = "";
        int cont = 0, auxiliar = -1;
        DateTime dataNaix = DateTime.Today;
        bool trobat = false, sortida = false;
        liniaAuxiliar = liniaFitxer;
        fitxerSR = new StreamReader("agenda.txt");
        while (!fitxerSR.EndOfStream && !sortida)
        {
            liniaActual = fitxerSR.ReadLine();
            auxiliar++;
            if (liniaActual == liniaFitxer)
                sortida = true;
        }
        fitxerSR.Close();
        Console.Write("\nIntrodueix el nom de la dada que vols modificar, a escollir entre les mostrades a la part superior: ");
        while (!trobat)
        {
            dadaModificar = Console.ReadLine();
            dadaModificar = dadaModificar.ToLower();
            if (dadaModificar == "nom")
            {
                Console.Write("Introdueix el nou valor per a la dada 'Nom': ");
                opcioNoms = "nom";
                modificacio = DemanarNoms(opcioNoms);
                trobat = true;
                cont = 0;
            }
            else if (dadaModificar == "cognom1" || dadaModificar == "cognom 1" || dadaModificar == "primer cognom")
            {
                Console.Write("Introdueix el nou valor per a la dada 'Primer cognom': ");
                opcioNoms = "primer cognom";
                modificacio = DemanarNoms(opcioNoms);
                trobat = true;
                cont = 1;
            }
            else if (dadaModificar == "cognom2" || dadaModificar == "cognom 2" || dadaModificar == "segon cognom")
            {
                Console.Write("Introdueix el nou valor per a la dada 'Segon cognom': ");
                opcioNoms = "c2";
                modificacio = DemanarNoms(opcioNoms);
                trobat = true;
                cont = 2;
            }
            else if (dadaModificar == "dni")
            {
                modificacio = DemanarDNI();
                trobat = true;
                cont = 3;
            }
            else if (dadaModificar == "telefon")
            {
                modificacio = DemanarTlf();
                trobat = true;
                cont = 4;
            }
            else if (dadaModificar == "datanaixement" || dadaModificar == "data naixement" || dadaModificar == "data")
            {
                dataNaix = DataNaix();
                trobat = true;
                cont = 5;
            }
            else if (dadaModificar == "correuelectronic" || dadaModificar == "correu electronic" || dadaModificar == "correu")
            {
                modificacio = DemanarCorreu();
                trobat = true;
                cont = 6;
            }
            else Console.Write("La opcio introduida no correspon a cap dada, introdueix-ne una altre que sigui correcte: ");
        }
        liniaFitxer = "";
        for (int i = 0; liniaAuxiliar.Contains('@'); i++)
        {
            if (i != cont)
            {
                if (liniaAuxiliar.Contains(','))
                    liniaFitxer = liniaFitxer + liniaAuxiliar.Substring(0, liniaAuxiliar.IndexOf(',')) + ',';
                else
                {
                    if (dadaModificar != "correuelectronic" && dadaModificar != "correu electronic" && dadaModificar != "correu")
                        liniaFitxer = liniaFitxer + liniaAuxiliar;
                    else liniaFitxer = liniaFitxer.Substring(0, liniaFitxer.Length - 1);
                    liniaAuxiliar = "";
                }
            }
            else
            {
                if (dadaModificar == "datanaixement" || dadaModificar == "data naixement" || dadaModificar == "data")
                    liniaFitxer = liniaFitxer + dataNaix.ToString("d") + ',';
                else liniaFitxer = liniaFitxer + modificacio + ',';
            }
            liniaAuxiliar = liniaAuxiliar.Substring(liniaAuxiliar.IndexOf(',') + 1);
        }
        EntrarModificacions(auxiliar, liniaFitxer);
    }

    static void EntrarModificacions(int auxiliar, string liniaFitxer)
    {
        StreamReader fitxerSR;
        StreamWriter fitxerSW;
        bool trobat = false;
        int cont;
        string liniaEscriure = "", liniaTotal = "", ultimaIntroduida = "";
        fitxerSR = new StreamReader("agenda.txt");
        liniaEscriure = fitxerSR.ReadLine();
        for (int i = 0; !fitxerSR.EndOfStream || !trobat; i++)
        {
            if (auxiliar != i)
            {
                liniaTotal = liniaTotal + liniaEscriure;
                ultimaIntroduida = liniaEscriure;
            }
            else
            {
                liniaTotal = liniaTotal + liniaFitxer;
                trobat = true;
                ultimaIntroduida = liniaFitxer;
            }
            liniaEscriure = fitxerSR.ReadLine();
            if (liniaEscriure != "")
                liniaTotal = liniaTotal + '\n';
        }
        if (liniaEscriure != "")
            liniaTotal = liniaTotal + liniaEscriure;
        fitxerSR.Close();
        fitxerSW = new StreamWriter("agenda.txt");
        if (ultimaIntroduida == liniaFitxer)
            fitxerSW.Write(liniaTotal);
        else fitxerSW.WriteLine(liniaTotal);
        fitxerSW.Close();
    }

    static void OrdenarAgenda()
    {
        int linies = 0;
        string linia, nom, cognom1, cognom2, telefon, resumDadesMesGran = "zzzzz", resumDadesMesGranAnterior = "aaaaa", resumDades = "", liniaAuxiliar = "", fitxerOrdenat = "", liniaMesGran = "";

        StreamReader fitxerSR = new StreamReader("agenda.txt");
        Console.WriteLine("");

        while (!fitxerSR.EndOfStream)
        {
            linies++;
            linia = fitxerSR.ReadLine();
        }
        fitxerSR.Close();

        while (linies > 0)
        {
            StreamReader fitxerSR2 = new StreamReader("agendaOrdenada.txt");
            while (!fitxerSR2.EndOfStream)
            {
                linia = fitxerSR2.ReadLine();

                if (linia != "")
                {
                    liniaAuxiliar = linia;

                    nom = liniaAuxiliar.Substring(0, liniaAuxiliar.IndexOf(","));
                    liniaAuxiliar = liniaAuxiliar.Substring(liniaAuxiliar.IndexOf(",") + 1);
                    cognom1 = liniaAuxiliar.Substring(0, liniaAuxiliar.IndexOf(","));
                    liniaAuxiliar = liniaAuxiliar.Substring(liniaAuxiliar.IndexOf(",") + 1);
                    cognom2 = liniaAuxiliar.Substring(0, liniaAuxiliar.IndexOf(","));
                    liniaAuxiliar = liniaAuxiliar.Substring(liniaAuxiliar.IndexOf(",") + 1);
                    liniaAuxiliar = liniaAuxiliar.Substring(liniaAuxiliar.IndexOf(",") + 1);
                    telefon = liniaAuxiliar.Substring(0, liniaAuxiliar.IndexOf(","));

                    resumDades = cognom1 + "," + cognom2 + "," + nom + "," + telefon;

                    if (resumDadesMesGran == resumDades)
                    {
                        linies--;
                    }

                    if (resumDades.CompareTo(resumDadesMesGran) < 0 && resumDades.CompareTo(resumDadesMesGranAnterior) > 0)
                    {
                        resumDadesMesGran = resumDades;
                        liniaMesGran = linia;
                    }
                }
            }
            fitxerSR2.Close();

            fitxerOrdenat = fitxerOrdenat + liniaMesGran + "\n";

            resumDadesMesGranAnterior = resumDadesMesGran;
            resumDadesMesGran = "zzzzz";

            linies--;
        }

        StreamWriter fitxerSW = new StreamWriter("agenda.txt");
        fitxerSW.Write(fitxerOrdenat);
        fitxerSW.Close();
        Console.WriteLine("Fitxer ordenat correctament!");
    }

    static void EliminarUsuari(string liniaFitxer)
    {
        StreamReader fitxerSR;
        StreamWriter fitxerSW;
        string liniaEscriure, textFitxer = "", auxiliar;
        fitxerSR = new StreamReader("agenda.txt");
        liniaEscriure = fitxerSR.ReadLine();
        while (!fitxerSR.EndOfStream)
        {
            auxiliar = liniaEscriure;
            if (liniaFitxer != liniaEscriure)
                textFitxer = textFitxer + liniaEscriure;
            liniaEscriure = fitxerSR.ReadLine();
            if (liniaEscriure != "" && auxiliar != liniaFitxer)
                textFitxer = textFitxer + "\n";
        }
        if (liniaEscriure != "" && liniaEscriure != liniaFitxer)
            textFitxer = textFitxer + liniaEscriure + '\n';
        fitxerSR.Close();
        fitxerSW = new StreamWriter("agenda.txt");
        fitxerSW.Write(textFitxer);
        fitxerSW.Close();
    }

} while (!sortir);