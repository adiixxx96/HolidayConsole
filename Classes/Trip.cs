namespace Classes {

    using Spectre.Console;

    public class Trip {

        public static int TripId = 1;

        public string Destination {get; set;}

        public DateTime StartDate {get; set;}

        public DateTime EndDate {get; set;}

        public decimal Price {get; set;}

        public int AvailableSpots {get; set;}

        public Boolean IsFull {get; set;}

        
        public Trip(string Destination, DateTime StartDate, DateTime EndDate, decimal Price, int AvailableSpots) {
            TripId++;
            this.Destination = Destination;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Price = Price;
            this.AvailableSpots = AvailableSpots;
            IsFull = false;
        }

        public void CheckFull() {
            if (AvailableSpots == 0) {
                IsFull = true;
            }
        }
    }

}