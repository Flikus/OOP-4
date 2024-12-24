class CommandCreateGame : ICommand
{
    public string NameCommand() { return "createGame"; }


    GameService adminGame;
    public CommandCreateGame(GameService adminGameObj)
    {
        adminGame = adminGameObj;
    }

    public void Command() {
        string? typeGame;
        string strRatting;
        int rating;

        do{
            Console.Write("Введіть тип гри (Standart, Onerisk, Training): ");
            typeGame = Console.ReadLine();

            if(typeGame == "break")
                return;

        } while(!(typeGame == "Standart" || typeGame == "Onerisk" || typeGame == "Training"));


        do{
            Console.Write("Введіть рейтинг гри: ");
            strRatting = Console.ReadLine();   
            
            if(strRatting == "break")
                return;
   
        } while(!int.TryParse(strRatting, out rating));

        adminGame.CreateGame(typeGame, rating);
    }
}