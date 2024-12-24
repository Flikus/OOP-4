class CommandImagePlayerGame : ICommand
{
    public string NameCommand() { return "imagePlayerGame"; }

    PlayerService adminPlayer;
    public CommandImagePlayerGame(PlayerService adminPlayerObj)
    {
        adminPlayer = adminPlayerObj;
    }

    public void Command()
    {
        string userName;

        if(adminPlayer.AccountCount() < 1) {
            Console.WriteLine("Немає зареєстрованих акаунтів\n");
            return;
        }

        do{
            Console.Write("Введіть ім'я користувача: ");
            userName = Console.ReadLine();

            if(userName == "break")
                return; 

        } while(!adminPlayer.CheckExistAccount(userName));
    
        adminPlayer.OutputPlayerGamesByPlayerId(userName);            
    }
}