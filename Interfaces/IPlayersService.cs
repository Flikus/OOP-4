interface IPlayersService 
{
    void CreateAccont(string userName, string TypeAccount); //створити акаунт
    public bool CheckExistAccount(string userName);         //перевірити чи існує акаунт з таким ім'ям
    public int AccountCount();                              //отримати кількість акаунтів

    void OutputAccountById(string userName);                //вивід гравця за ід
    void OutputAllAccount();                                //вивести всі акаунти
    void OutputPlayerGamesByPlayerId(string userName);      //вивести ігри якиі зіграв гравець

    GameAccount GetAccount(string userName);                //отримати акаунт гравця
}