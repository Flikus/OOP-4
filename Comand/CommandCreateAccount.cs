class CommandCreateAccount : ICommand
{
    public string NameCommand() { return "createAccount"; }
    
    PlayerService adminPlayer;
    public CommandCreateAccount(PlayerService adminPlayerObj)
    {
        adminPlayer = adminPlayerObj;
    }

    public void Command() {
        string userName;
        string typeAccount;

        do{
            Console.Write("Введіть ім'я користувача: ");
            userName = Console.ReadLine(); 
            userName = userName.Trim();         
        } while(userName.Count() < 1);


        if(userName == "break")
            Console.WriteLine("break - зарезервована фраза"); 
        
        else {

            do{
                Console.Write("Введіть тип акаунту(Standart, Pay, Winstreak): ");
                typeAccount = Console.ReadLine();  
                
                if(typeAccount == "break")
                    return;

            } while(!(typeAccount == "Standart" || typeAccount == "Pay" || typeAccount == "Winstreak"));

            adminPlayer.CreateAccont(userName, typeAccount);
        }
    }
}