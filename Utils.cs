namespace Utils {
    using Classes;
    using System.Text.Json;

    public class Utils {

        //Método para comprobar si una variable es de tipo numérico
        public Boolean IsNumber(string option) {
            int i = 0;
            bool result = int.TryParse(option, out i);
            if (result) {
                return true;
            }
            return false;
        }

        //Métodos para enviar datos de las clases a los archivos Json
        public void SendUserData(List<User> allUsers, string userFile) {
            string userString = JsonSerializer.Serialize(allUsers);
            File.WriteAllText(userFile,userString);
        }

        public void SendBookingData(List<Booking> allBookings, string bookingFile){
            string bookingString = JsonSerializer.Serialize(allBookings);
            File.WriteAllText(bookingFile,bookingString);
        }

        public void SendTripData(List<Trip> allTrips, string tripFile){
            string tripString = JsonSerializer.Serialize(allTrips);
            File.WriteAllText(tripFile,tripString);
        }
    }

}