namespace Service {
    using Classes;
    using Spectre.Console;
    using Utils;

    public class BookingService {
        TripService tripService = new TripService();
        Utils utils = new Utils();

        public void ShowBookings(List<Booking> allBookings, User currentUser) {
            Console.WriteLine($"{System.Environment.NewLine}");
            AnsiConsole.Markup("[bold aquamarine1]MIS RESERVAS[/]");
            Console.WriteLine($"{System.Environment.NewLine}");
            var table = new Table();
            table.AddColumn("Código de reserva");
            table.AddColumn("Fecha de la reserva");
            table.AddColumn("Cliente");
            table.AddColumn("Destino");
            table.AddColumn("Fecha salida");
            table.AddColumn("Fecha llegada");
            table.AddColumn("Precio final");

            foreach (Booking booking in allBookings) {
                if (booking.User.Username == currentUser.Username ) {
                    table.AddRow($"{booking.Code}", $"{booking.BookingDate.ToString("dd/MM/yyyy")}", $"{booking.User.Name}", $"{booking.Trip.Destination}", $"{booking.Trip.StartDate.ToString("dd/MM/yyyy")}", $"{booking.Trip.EndDate.ToString("dd/MM/yyyy")}", $"{booking.FinalPrice}");
                }
            }
            AnsiConsole.Write(table);
            Console.WriteLine();
            Console.WriteLine("Pulsa cualquier tecla para continuar");
            Console.ReadKey();
        }

        public void BookTrip(List<Trip> allTrips, User currentuser, List<Booking> allBookings, string bookingFile, string tripFile) {
            Console.WriteLine($"{System.Environment.NewLine}");
            AnsiConsole.Markup("[bold aquamarine1]RESERVAR UN VIAJE[/]");
            Console.WriteLine($"{System.Environment.NewLine}");
            tripService.ShowAvailableTrips(allTrips);

            string option = "";
            int value = 0;
            Boolean booked = false;
            //Comprobamos que el usuario introduce un número
                while (!utils.IsNumber(option) || !booked) {
                    Console.WriteLine($"{System.Environment.NewLine}");
                    Console.WriteLine("Introduce el identificador del viaje que deseas reservar");
                    option = Console.ReadLine();
                    if (!utils.IsNumber(option)) {
                        AnsiConsole.Markup("[red]Error. Tienes que introducir un número[/]");
                    
                    } else {
                        value = Int32.Parse(option);
                        foreach (Trip trip in allTrips) {
                            if (trip.TripId == value) {
                                decimal finalPrice = trip.Price;
                                Booking newBooking = new Booking(currentuser, trip, finalPrice);
                                allBookings.Add(newBooking);
                                utils.SendBookingData(allBookings, bookingFile);
                                booked = true;
                                tripService.Substract(trip);
                                tripService.CheckFull(trip);
                                utils.SendTripData(allTrips, tripFile);
                                break;
                            }
                        }
                        if (booked) {
                            AnsiConsole.Markup("[bold palegreen3]La reserva se ha realizado correctamente[/]");
                            Console.WriteLine();
                            Console.WriteLine("Pulsa cualquier tecla para continuar");
                            Console.ReadKey();
                        } else {
                            AnsiConsole.Markup("[bold red]El identificador introducido no corresponde a ningún viaje");
                        }
                    } 
                }  
        }
    }
}