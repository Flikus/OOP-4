class PlayerService : IPlayersService
{   
    PlayerRepository playerRepository;
    public PlayerService(DbContext dbContextObj)
    {
        playerRepository = new PlayerRepository(dbContextObj);
    } 

    //створити акаунт
    public void CreateAccont(string userName, string typeAccount)
    {
        playerRepository.CreatePlayer(userName, typeAccount);
    }



    //перевірити чи існує акаунт з таким ім'ям
    public bool CheckExistAccount(string userName)
    {
        if(playerRepository.ReadPlayer(userName) >= 0)
            return true;
        else 
            return false;
    }

    //отримати кількість акаунтів
    public int AccountCount()
    {
        return playerRepository.ReadPlayer(1);
    }





    //вивід інформації програвця
    private void OutputPlayerById(int index)
    {	
        GameAccount account = playerRepository.ReadAccount(index);
        if(account.UserName == null)
            Console.Write("Користувача не знайдено\n");

        else{
            Console.Write("|{0,7:d3} |", index);
            Console.Write("{0, 8} |" , account.UserName);		
            Console.Write("{0,11} |" , account.TypeAccount);			
            Console.Write("{0, 8} |" , account.CurrentRating);
            Console.Write("{0, 15} |", account.GamesCount);
            Console.Write("\n");            
        }
    }

    //вивід гравця за ід
    public void OutputAccountById(string userName)
    {
        int index = playerRepository.ReadPlayer(userName);
        if(index >= 0) {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("| індекс | гравець | тип акунта | рейтинг | Кількість ігор |");

            OutputPlayerById(index);

            Console.WriteLine("------------------------------------------------------------");
            Console.Write("\n");
        }
    }

    //вивести всі акаунти
    public void OutputAllAccount()
    {   
        Console.WriteLine("------------------------------------------------------------");
		Console.WriteLine("| індекс | гравець | тип акунта | рейтинг | Кількість ігор |");

        for(int i = 0; i < playerRepository.ReadPlayer(1); i++)
            OutputPlayerById(i);

        Console.WriteLine("------------------------------------------------------------");
        Console.Write("\n");
    }




    //вивести ігри які зіграв гравець
    public void OutputPlayerGamesByPlayerId(string userName)
    {
        playerRepository.ReadPlayerGamesByPlayerId(userName);
    }



    //отримати акаунт гравця
    public GameAccount GetAccount(string userName)
    {
        GameAccount account = playerRepository.ReadAccount(userName);
        if(account.UserName == null) {
            Console.Write("Користувача не знайдено\n");
        }
        return playerRepository.ReadAccount(userName);
    }
}