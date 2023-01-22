namespace Service {
    using Classes;
    using Spectre.Console;

    public class TripService {

        public void ShowTrips(List<Trip> allTrips) {
            Console.WriteLine($"{System.Environment.NewLine}");
            AnsiConsole.Markup("[bold aquamarine1]LISTADO DE VIAJES[/]");
            Console.WriteLine($"{System.Environment.NewLine}");

            var table = new Table();
            table.AddColumn("Identificador");
            table.AddColumn("Destino");
            table.AddColumn("Fecha salida");
            table.AddColumn("Fecha llegada");
            table.AddColumn("Precio");
            table.AddColumn("Plazas disponibles");

            foreach (Trip trip in allTrips) {
                table.AddRow($"{trip.TripId}", $"{trip.Destination}", $"{trip.StartDate.ToString("dd/MM/yyyy")}", $"{trip.EndDate.ToString("dd/MM/yyyy")}", $"{trip.Price}", $"{trip.AvailableSpots}");
            }
            AnsiConsole.Write(table);
            Console.WriteLine();
            Console.WriteLine("Pulsa cualquier tecla para continuar");
            Console.ReadKey();
        }

        public void ShowAvailableTrips(List<Trip> allTrips) {
            var table = new Table();
            table.AddColumn("Identificador");
            table.AddColumn("Destino");
            table.AddColumn("Fecha salida");
            table.AddColumn("Fecha llegada");
            table.AddColumn("Precio");
            table.AddColumn("Plazas disponibles");

            foreach (Trip trip in allTrips) {
                if (!trip.IsFull) {
                table.AddRow($"{trip.TripId}", $"{trip.Destination}", $"{trip.StartDate.ToString("dd/MM/yyyy")}", $"{trip.EndDate.ToString("dd/MM/yyyy")}", $"{trip.Price}", $"{trip.AvailableSpots}");
                }
            }
            AnsiConsole.Write(table);
        }

        public void SearchTrip(List<Trip> allTrips) {
            Console.WriteLine($"{System.Environment.NewLine}");
            AnsiConsole.Markup("[bold aquamarine1]BUSCAR VIAJES[/]");
            Console.WriteLine();
            AnsiConsole.Markup("[aquamarine1]Debes buscar el viaje por su destino[/]");
            Console.WriteLine($"{System.Environment.NewLine}");
            Console.WriteLine("Introduce el destino a buscar");
            string texto = Console.ReadLine();
            string destino = texto.ToLower();
            
            var table = new Table();
            table.AddColumn("Identificador");
            table.AddColumn("Destino");
            table.AddColumn("Fecha salida");
            table.AddColumn("Fecha llegada");
            table.AddColumn("Precio");
            table.AddColumn("Plazas disponibles");

            foreach (Trip trip in allTrips) {
                if (trip.Destination.ToLower().Contains(destino)) {
                    table.AddRow($"{trip.TripId}", $"{trip.Destination}", $"{trip.StartDate.ToString("dd/MM/yyyy")}", $"{trip.EndDate.ToString("dd/MM/yyyy")}", $"{trip.Price}", $"{trip.AvailableSpots}");             
                }
            }
            AnsiConsole.Write(table);
            Console.WriteLine("Pulsa cualquier tecla para continuar");
            Console.ReadKey();
        }
        public void CheckFull(Trip trip) {
            if (trip.AvailableSpots == 0) {
                trip.IsFull = true;
            }
        }
        public void Substract(Trip trip) {
            trip.AvailableSpots--;
        }
    }

}