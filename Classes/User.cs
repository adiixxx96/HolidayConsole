namespace Classes {

    using Spectre.Console;

    public class User {

        public int UserId {get; set;}

        public string Name {get; set;}
        
        public string Username {get; set;}

        public string Password {get; set;}

        public DateTime CreationDate {get; set;}

        public Boolean Active {get; set;}

        public User() {
            Name="";
            Username="";
            Password="";
        }

        public User(String Name, String Username, String Password) {
            UserId = GenerateId(3);
            this.Name=Name;
            this.Username=Username;
            this.Password=Password;
            CreationDate=DateTime.Now;
            Active=true;
        }

        //Generador de identificador aleatorio
        public int GenerateId(int codeLength) {
            int id = 000;
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