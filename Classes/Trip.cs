namespace Classes {

    using Spectre.Console;

    public class Trip {

        public int TripId {get; set;}

        public string Destination {get; set;}

        public DateTime StartDate {get; set;}

        public DateTime EndDate {get; set;}

        public decimal Price {get; set;}

        public int AvailableSpots {get; set;}

        public Boolean IsFull {get; set;}
        
        public Trip(string Destination, DateTime StartDate, DateTime EndDate, decimal Price, int AvailableSpots) {
            TripId = GenerateId(2);
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

        public int GenerateId(int codeLength) {
            int id = 0;
            string result = ""; 
            string pattern = "0123456789";
    
            Random myRndGenerator = new Random((int)DateTime.Now.Ticks);

            for(int i=0; i < codeLength; i++) {
                int mIndex = myRndGenerator.Next(pattern.Length);
                result += pattern[mIndex];
            }

            id = Int32.Parse(result);
            return id;
        }

    }

}