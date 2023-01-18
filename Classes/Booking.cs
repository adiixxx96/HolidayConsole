namespace Classes {

    using Spectre.Console;

    public class Booking {

        public String Code {get; set;}

        public User User {get; set;}

        public Trip Trip {get; set;}

        public DateTime BookingDate {get; set;}

        public decimal FinalPrice {get; set;}

        public Boolean Paid {get; set;}

        public Booking(User User, Trip Trip, decimal FinalPrice) {
            Code = GenerateCode(8);
            this.User = User;
            this.Trip = Trip;
            BookingDate = DateTime.Now;
            this.FinalPrice = FinalPrice;
            Paid = false;
        }

        public string GenerateCode(int codeLength) {
            string result = ""; 
            string pattern = "+-_#!?0123456789abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
    
            Random myRndGenerator = new Random((int)DateTime.Now.Ticks);

            for(int i=0; i < codeLength; i++) {
                int mIndex = myRndGenerator.Next(pattern.Length);
                result += pattern[mIndex];
            }
            return result;
        }
    
    }
}
