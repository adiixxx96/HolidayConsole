namespace Service {
    using Classes;
    using Spectre.Console;
    using Utils;

    public class UserService {

        Utils utils = new Utils();

        public void RegisterUser(List<User> allUsers, string userFile) {
            Console.WriteLine($"{System.Environment.NewLine}");
            AnsiConsole.Markup("[bold aquamarine1]REGISTRAR USUARIO[/]");
            Console.WriteLine($"{System.Environment.NewLine}");
            Console.WriteLine("Nombre:");
            string name = Console.ReadLine();
            string username = "";
            Boolean repeat = true;
            Boolean duplicated = false;
            while (repeat) {
                duplicated = false;
                Console.WriteLine("Usuario:");
                username = Console.ReadLine();
                foreach (User user in allUsers) {
                    if (user.Username == username) {
                        AnsiConsole.Markup("[bold red]Ya existe un usuario con ese nombre de usuario. Prueba de nuevo[/]");
                        duplicated = true;
                    }
                } 
                if (!duplicated) {
                    repeat = false; 
                }           
            }
            Console.WriteLine("Contraseña:");
            string password = Console.ReadLine();

            User newUser = new User(name, username, password);
            allUsers.Add(newUser);
            utils.SendUserData(allUsers, userFile);
            Console.WriteLine("El usuario ha sido registrado correctamente. Ahora puedes iniciar sesión");
            Console.WriteLine("Pulsa cualquier tecla para continuar");
            Console.ReadKey();
        }

        public void ShowUserData(User currentUser) {
            Console.WriteLine($"{System.Environment.NewLine}");
            AnsiConsole.Markup("[bold aquamarine1]MIS DATOS DE USUARIO[/]");
            Console.WriteLine();
            
            var table = new Table();
            table.AddColumn("Identificador");
            table.AddColumn("Nombre");
            table.AddColumn("Usuario");
            table.AddColumn("Contraseña");
            table.AddColumn("Fecha creación");
            table.AddRow($"{currentUser.UserId}", $"{currentUser.Name}", $"{currentUser.Username}", $"{currentUser.Password}", $"{currentUser.CreationDate.ToString("dd/MM/yyyy")}");
            AnsiConsole.Write(table);
            Console.WriteLine("Pulsa cualquier tecla para continuar");
            Console.ReadKey();
        }

        public void LogOut(User currentUser, User emptyUser) {
            Console.WriteLine($"{System.Environment.NewLine}");
            Console.WriteLine("Se ha cerrado correctamente la sesión");
            currentUser.Name = emptyUser.Name;
            currentUser.Username = emptyUser.Username;
            currentUser.Password = emptyUser.Password;
            Console.WriteLine("Pulsa cualquier tecla para continuar");
            Console.ReadKey();
        }
    }
}