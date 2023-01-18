namespace Classes {

    using Spectre.Console;

    public class User {

        public static int UserId = 1;

        public string Name {get; set;}
        
        public string Username {get; set;}

        public string Password {get; set;}

        public DateTime CreationDate {get; set;}

        public Boolean active {get; set;}

        public User() {
            Name="";
            Username="";
            Password="";
        }

        public User(String Name, String Username, String Password) {
            UserId++;
            this.Name=Name;
            this.Username=Username;
            this.Password=Password;
            CreationDate=DateTime.Now;
            active=true;
        }

    }
}