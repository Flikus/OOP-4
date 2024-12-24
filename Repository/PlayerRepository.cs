class PlayerRepository : IPlayerRepository
{
    DbContext dbContext;

    public PlayerRepository(DbContext dbContextObj)
    {
        dbContext = dbContextObj;
    }

    // Додати гравця до бази даних
    public void CreatePlayer(string userName, string typeAccount)
    {   
        if(dbContext.Players.FindIndex(p => p.UserName == userName) >= 0){
            Console.Write("Користувач з таким іменем вже існує\n");           
        }
        else {
            // Створюємо користувача
            switch(typeAccount)
            {
            case "Standart" : dbContext.Players.Add(new StandartAccount(userName));  break;
            case "Pay"      : dbContext.Players.Add(new PayAccount(userName));       break;
            case "Winstreak": dbContext.Players.Add(new WinstreakAccount(userName)); break;
            default: Console.Write("Неіснуючий тип акаунту\n");                      break;
            }  
        }
    }



    // Отримати загальну кількість гравців
    public int ReadPlayer(int value)
    {
        if(value == 1)
            return dbContext.Players.Count();
        return -1;
    }



    // Отримати індекс гравця за іменем
    public int ReadPlayer(string userName)
    {
        int ind = dbContext.Players.FindIndex(p => p.UserName == userName);
        if(ind < 0)
            Console.Write("Користувача з таким іменем не знайдено\n");
        return ind;
    }

    // Отримати гравця за ім'ям
    public GameAccount ReadAccount(string userName)
    {
        return ReadAccount(ReadPlayer(userName));
    }

    // Отримати гравця за індексом
    public GameAccount ReadAccount(int ind)
    {   
        if(ind < 0 || ind >= ReadPlayer(1) ) 
            return new StandartAccount(null);
        else
            return dbContext.Players[ind];
    }





    public void ReadPlayerGamesByPlayerId(string userName)
    {
        if(ReadPlayer(userName) >= 0)
            ReadAccount(userName).GetStats(); 
    }



    // Видалити гравця з бази даних
    public void DeletePlayer(string userName)
    {   
        int index = dbContext.Players.FindIndex(p => p.UserName == userName);
        if(index < 0) 
            Console.Write("Користувача з таким іменем не знайдено\n"); 
        else     
            dbContext.Players.Remove(dbContext.Players[index]);
    }
}