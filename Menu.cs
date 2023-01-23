namespace Program {
    using Spectre.Console;
    using Classes;
    using Utils;
    using Service;
    using System.Text.Json;

    public class Menu {

        User currentUser = new User();
        User emptyUser = new User();
        Utils utils = new Utils();
        UserService userService = new UserService();
        TripService tripService = new TripService();
        BookingService bookingService = new BookingService();
        public List<User> allUsers = new List<User>();
        public List<Trip> allTrips = new List<Trip>();
        public List<Booking> allBookings = new List<Booking>();
        string userFile = "Json/DataUser.json";
        string tripFile = "Json/DataTrip.json";
        string bookingFile = "Json/DataBooking.json";

        public void ShowMenu(){
        
            bool exit = false;

            // El menú se mostrará hasta que el usuario salga de la aplicación
            while (!exit) {
                
                Console.WriteLine($"{System.Environment.NewLine}");

                //Controlamos las opciones de menú que se muestran al usuario según si el usuario está logueado y tiene un usuario asignado
                if (currentUser.Username != "") {
                    AnsiConsole.Markup($"[bold palegreen3]¡Hola {currentUser.Name}!, bienvenid@ a tu aplicación de vacaciones![/]");
                    Console.WriteLine($"{System.Environment.NewLine}");
                } else {
                    AnsiConsole.Markup("[bold palegreen3]¡Bienvenid@ a tu aplicación de vacaciones![/]");
                    Console.WriteLine($"{System.Environment.NewLine}");
                }
                    AnsiConsole.Markup("[bold mediumpurple2]***MENÚ DE NAVEGACIÓN***[/]");
                    Console.WriteLine();
                if (currentUser.Username == "") {
                    Console.WriteLine("1. Iniciar sesión");
                    Console.WriteLine("2. Regístrate");
                }
                    Console.WriteLine("3. Ver todos los viajes");
                    Console.WriteLine("4. Busca un viaje");

                if (currentUser.Username != "") { 
                    Console.WriteLine();
                    AnsiConsole.Markup("[bold mediumpurple2]Tu área privada[/]");
                    Console.WriteLine();
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

                //Ejecutamos métodos según la opción del menú. Controlamos que solo pueda acceder a las opciones que le corresponden.
                int value = Int32.Parse(option);
                switch(value) {
                    case 0:
                        Console.WriteLine($"{System.Environment.NewLine}");
                        AnsiConsole.Markup("[bold palegreen3]¡Adiós![/]");
                        Console.WriteLine($"{System.Environment.NewLine}");
                        exit = true;
                        break;
                    case 1:
                        if (currentUser.Username == "") {
                            LogIn();
                        } else {
                            AnsiConsole.Markup($"[bold red]La opción pedida no está disponible[/]");
                            Console.WriteLine();
                            Console.WriteLine("Pulsa cualquier tecla para continuar");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        if (currentUser.Username == "") {
                            userService.RegisterUser(allUsers, userFile);
                        } else {
                            AnsiConsole.Markup($"[bold red]La opción pedida no está disponible[/]");
                            Console.WriteLine();
                            Console.WriteLine("Pulsa cualquier tecla para continuar");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        tripService.ShowTrips(allTrips);
                        break;
                    case 4:
                        tripService.SearchTrip(allTrips);
                        break;
                    case 5:
                        if (currentUser.Username != "") {
                            userService.ShowUserData(currentUser);
                        } else {
                            AnsiConsole.Markup($"[bold red]La opción pedida no está disponible[/]");
                            Console.WriteLine();
                            Console.WriteLine("Pulsa cualquier tecla para continuar");
                            Console.ReadKey();
                        }   
                        break;
                    case 6:
                        if (currentUser.Username != "") {
                            bookingService.ShowBookings(allBookings, currentUser);
                        } else {
                            AnsiConsole.Markup($"[bold red]La opción pedida no está disponible[/]");
                            Console.WriteLine();
                            Console.WriteLine("Pulsa cualquier tecla para continuar");
                            Console.ReadKey();
                        }
                        break;
                    case 7:
                        if (currentUser.Username != "") {
                            bookingService.BookTrip(allTrips, currentUser, allBookings, bookingFile, tripFile);
                        } else {
                            AnsiConsole.Markup($"[bold red]La opción pedida no está disponible[/]");
                            Console.WriteLine();
                            Console.WriteLine("Pulsa cualquier tecla para continuar");
                            Console.ReadKey();
                        }
                        break;
                    case 8:
                        if (currentUser.Username != "") {
                            userService.LogOut(currentUser, emptyUser);
                        } else {
                            AnsiConsole.Markup($"[bold red]La opción pedida no está disponible[/]");
                            Console.WriteLine();
                            Console.WriteLine("Pulsa cualquier tecla para continuar");
                            Console.ReadKey();
                        }
                        break;
                    default: 
                    AnsiConsole.Markup($"[red]No se ha encontrado la opcion pedida [/]");
                    Console.WriteLine();
                    Console.WriteLine("Pulsa cualquier tecla para continuar");
                    Console.ReadKey();
                    break;
                }
            }
        }

        //Método para precargar los datos de nuestras clases desde archivos json
        public void LoadData() {
            string userString = File.ReadAllText(userFile);
            allUsers = JsonSerializer.Deserialize<List<User>>(userString);
            string tripString = File.ReadAllText(tripFile);
            allTrips = JsonSerializer.Deserialize<List<Trip>>(tripString);
            string bookingString = File.ReadAllText(bookingFile);
            allBookings = JsonSerializer.Deserialize<List<Booking>>(bookingString);
        }

        //Método que loguea al usuario y lo asigna a la variable currentUser
        public void LogIn() {
            Console.WriteLine($"{System.Environment.NewLine}");
            AnsiConsole.Markup("[bold aquamarine1]INICIAR SESIÓN[/]");
            Console.WriteLine($"{System.Environment.NewLine}");
            Console.WriteLine("Usuario:");
            string username = Console.ReadLine();
            Console.WriteLine("Contraseña:");
            string password = Console.ReadLine();

            foreach (User user in allUsers) {
                if (user.Username == username && user.Password == password) {
                    currentUser = user;
                    AnsiConsole.Markup($"[bold aquamarine1]Has iniciado sesión correctamente.[/]");
                    Console.WriteLine($"{System.Environment.NewLine}");
                }
            }
            if (currentUser.Username=="") {
                    AnsiConsole.Markup($"[bold red]El usuario o contraseña son incorrectos.[/]");
                    Console.WriteLine($"{System.Environment.NewLine}");
                }
        }

    }
}