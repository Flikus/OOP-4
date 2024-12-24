class CommandImageAllPlayer : ICommand
{
    public string NameCommand() { return "imageAllPlayer"; }

    PlayerService adminPlayer;
    public CommandImageAllPlayer(PlayerService adminPlayerObj)
    {
        adminPlayer = adminPlayerObj;
    }

    public void Command()
    {
        if(adminPlayer.AccountCount() < 1) 
            Console.WriteLine("Немає зареєстрованих акаунтів\n");
        else
            adminPlayer.OutputAllAccount();
    }
}