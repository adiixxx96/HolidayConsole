namespace Utils {
    using Classes;

    class Utils {

        public Boolean IsLogged(User user) {
            if (user.Username!="") {
                return true;
            }

            return false;
        }

        public Boolean IsNumber(string option) {
            int i = 0;
            bool result = int.TryParse(option, out i);
            if (result) {
                return true;
            }
            return false;
        }

    }

}