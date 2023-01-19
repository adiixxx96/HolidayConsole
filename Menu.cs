namespace Program {
    using Spectre.Console;
    using Classes;
    using Utils;

    class Menu {

        User currentUser = new User();
        Utils utils = new Utils();

        public void ShowMenu(){
            
            bool exit = false;

            while (!exit) {

                if (utils.IsLogged(currentUser)) {
                    AnsiConsole.Markup($"[bold palegreen3]¡Hola {currentUser.Name}, bienvenid@ a tu aplicación de vacaciones![/]");
                    Console.WriteLine($"{System.Environment.NewLine}");
                } else {
                    AnsiConsole.Markup("[bold palegreen3]¡Bienvenid@ a tu aplicación de vacaciones![/]");
                    Console.WriteLine($"{System.Environment.NewLine}");
                }
                    AnsiConsole.Markup("[bold mediumpurple2]***MENÚ DE NAVEGACIÓN***[/]");
                    Console.WriteLine();
                    Console.WriteLine("1. Iniciar sesión");
                    Console.WriteLine("2. Regístrate");
                    Console.WriteLine("3. Ver todos los viajes");
                    Console.WriteLine("4. Busca un viaje");

                if (utils.IsLogged(currentUser)) {
                    Console.WriteLine($"{System.Environment.NewLine}");
                    AnsiConsole.Markup("[mediumpurple2]Área de usuario[/]");
                    Console.WriteLine("5. Mis datos personales");
                    Console.WriteLine("6. Mis reservas de viaje");
                    Console.WriteLine("7. Reservar un viaje");
                    Console.WriteLine("8. Cerrar sesión");
                }
                    Console.WriteLine("0. Salir de la aplicación");

                string option = "";
                
                //Comprobamos que el usuario introduce un número
                while (!utils.IsNumber(option)) {
                    Console.WriteLine($"{System.Environment.NewLine}");
                    Console.WriteLine("Introduce el número del menú al que desees acceder");
                    option = Console.ReadLine();
                    if (!utils.IsNumber(option)) {
                        AnsiConsole.Markup("[red]Error. Tienes que introducir un número[/]");
                    } 
                }

                int value = Int32.Parse(option);
                switch(value) {
                    case 0: 
                        Console.WriteLine("[bold palegreen3]¡Adiós![/]");
                        exit = true;
                        break;
                    case 1:
                        LogIn();
                        break;
                    case 2:
                        RegisterUser();
                        break;
                    case 3:
                        ShowTrips();
                        break;
                    case 4:
                        SearchTrip();
                        break;
                    case 5:
                        ShowUserData();
                        break;
                    case 6:
                        ShowBookings();
                        break;
                    case 7:
                        BookTrip();
                        break;
                    case 8:
                        LogOut();
                        break;
                }
                exit = true;
            }
        }

        public void LogIn() {

        }

        public void RegisterUser() {

        }

        public void ShowTrips() {

        }

        public void SearchTrip() {

        }

        public void ShowUserData() {

        }

        public void ShowBookings() {

        }

        public void BookTrip() {

        }

        public void LogOut() {

        }

    }
}