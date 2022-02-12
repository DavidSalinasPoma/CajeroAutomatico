// Sistema de cajero automatico
class Cajero
{
    int nip;
    double inicial;
    int cont = 0;
    List<string> listaMovimientos = new List<string>();
    string[] movimientos = null!;
    public Cajero(int nip)
    {
        this.nip = nip;
        this.validarNip();
    }

    public void validarNip()
    {
        while (this.cont != 2)
        {
            if (this.nip == 3867)
            {
                this.saldoInicial();
                this.menu();
            }
            else
            {
                Console.WriteLine("Ingrese un NIP correcto:");
                this.nip = Convert.ToInt32(Console.ReadLine());
                if (this.nip == 3867)
                {
                    this.saldoInicial();
                    this.menu();
                }
            }
            this.cont++;
        }
        // Salir del sistema
        return;
    }

    public void saldoInicial()
    {
        Console.WriteLine("Ingrese un saldo inicial:");
        this.inicial = Convert.ToDouble(Console.ReadLine());
    }

    public void menu()
    {
        Console.WriteLine("**Menu**");
        Console.WriteLine("1: Consultar saldo");
        Console.WriteLine("2: Retirar efectivo");
        Console.WriteLine("3: Consultar movimiento");
        Console.WriteLine("4: Salir ");
        // Ingreso de opción

        Console.WriteLine("Ingrese opcion: ");
        int opcion = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(opcion);

        while (opcion < 1 || opcion > 4)
        {
            Console.WriteLine("Ingrese una opción valida: ");
            opcion = Convert.ToInt32(Console.ReadLine());
        }

        this.consultas(opcion);

    }

    public void salirMenu()
    {
        Console.WriteLine("1: Volver a menu ");
        Console.WriteLine("2: Salir del Sistema");
        Console.WriteLine("Ingrese opcion: ");

        int opcion = Convert.ToInt32(Console.ReadLine());
        // Console.WriteLine(opcion);

        while (opcion < 1 || opcion > 2)
        {
            Console.WriteLine("Ingrese una opción valida: ");
            opcion = Convert.ToInt32(Console.ReadLine());
        }

        // Console.WriteLine(opcion);
        this.consultaSalirMenu(opcion);
    }

    public void consultaSalirMenu(int option)
    {
        switch (option)
        {
            case 1:
                this.menu();
                break;
            case 2:
                Environment.Exit(0);
                break;
        }
    }

    public void consultas(int opcion)
    {
        switch (opcion)
        {
            case 1:
                Console.WriteLine("----------------");
                Console.WriteLine($"Su saldo actual es de: {this.inicial} Boliviano(s)");
                Console.WriteLine("----------------");
                this.salirMenu();
                break;

            case 2:
                if (this.inicial == 0)
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine("Usted no tiene credito en su cuenta!!");
                    Console.WriteLine("----------------");
                    this.salirMenu();
                }
                else
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine($"Saldo: {this.inicial} Boliviano(s)");
                    Console.WriteLine("Ingrese cantidad de retiro: ");
                    double retiro = Convert.ToDouble(Console.ReadLine());
                    while (retiro < 1 || retiro > this.inicial)
                    {
                        Console.WriteLine("Ingrese cantidad de retiro valido: ");
                        retiro = Convert.ToDouble(Console.ReadLine());
                    }

                    Console.WriteLine($"Se retiro el monto de: {retiro} Boliviano(s)");
                    this.inicial = this.inicial - retiro;
                    Console.WriteLine($"Su saldo actual es de: {this.inicial} Bolivianos(0)");

                    // Logica agregar lista de movimientos
                    string datetime = DateTime.Now.ToString("hh:mm:ss tt");
                    string fecha = DateTime.Now.ToLongDateString();
                    this.listaMovimientos.Add($"En fecha: {fecha}, hora: {datetime}, se hizo un retiro de: {retiro} Boliviano(s)");
                    this.movimientos = listaMovimientos.ToArray();
                    Console.WriteLine("----------------");
                    this.salirMenu();
                }
                break;
            case 3:

                if (this.movimientos == null!)
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine("Usted no realizo ningun movimiento aun!!");
                    Console.WriteLine("----------------");
                    this.salirMenu();
                }
                else
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine("Consulta de movimientos");
                    foreach (var item in this.movimientos)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("----------------");
                    this.salirMenu();
                }
                break;

            case 4:
                Environment.Exit(0);
                break;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese NIP:");
        int nip = Convert.ToInt32(Console.ReadLine());
        Cajero cajero = new Cajero(nip);
    }

}
