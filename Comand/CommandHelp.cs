class CommandHelp : ICommand
{

    public string NameCommand() { return "help"; }

    public void Command()
    {
        Console.WriteLine();
        Console.WriteLine("createAccount   - створити гравця"); 
        Console.WriteLine("createGame      - створити гру"); 
        Console.WriteLine("imagePlayer     - виести данні гравця"); 
        Console.WriteLine("imageAllPlayer  - виести данні всіх гравців"); 
        Console.WriteLine("imagePlayerGame - вивести список ігор гравця"); 
        Console.WriteLine("imageAllGame    - виести всі ігри"); 
        Console.WriteLine("playGame        - зігарти гру"); 
        Console.WriteLine("");
        Console.WriteLine("break           - завершити виконання поточної команди"); 
        Console.WriteLine("exit            - завершити програму\n"); 
    }
}