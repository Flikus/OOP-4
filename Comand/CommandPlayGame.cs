class CommandPlayGame : ICommand
{
    public string NameCommand() { return "playGame"; }

    PlayerService adminPlayer;
    GameService adminGame;  

    public CommandPlayGame(PlayerService adminPlayerObj, GameService adminGameObj)
    {
        adminPlayer = adminPlayerObj;
        adminGame = adminGameObj;
    }
    
    public void Command()
    {
        string userName1;
        string userName2;
        string strGameIndex;
        int gameIndex;

        if(adminPlayer.AccountCount() < 2) {
            Console.WriteLine("Недостатньо зареєстрованих акаунтів\n");  
            return;          
        }

        if(adminGame.GameCount() < 1) {
            Console.WriteLine("Немає створених ігор\n");  
            return;
        }


        do{
            Console.Write("Введіть ім'я опонента 1: ");
            userName1 = Console.ReadLine();

            if(userName1 == "break")
                return;

        } while(!adminPlayer.CheckExistAccount(userName1));

        do{
            Console.Write("Введіть ім'я опонента 2: ");
            userName2 = Console.ReadLine();

            if(userName2 == "break")
                return;
            
            if(userName1 == userName2)
                Console.WriteLine("гравець не може зіграти сам з собою");

        } while(!adminPlayer.CheckExistAccount(userName2) || userName1 == userName2);

        adminGame.OutputAllGame();

        do {
            do{
            Console.Write("Введіть індекс гри: ");
            strGameIndex = Console.ReadLine();    

            if(strGameIndex == "break")
                return;
            
            } while(!int.TryParse(strGameIndex, out gameIndex));
        } while(!adminGame.CheckExistGame(gameIndex));

        
        PlayGame play = new PlayGame(adminPlayer.GetAccount(userName1), adminPlayer.GetAccount(userName2), adminGame.GetGame(gameIndex));

        Console.WriteLine("Гру зіграно успішно!!!");
        play.Result();
    }
}