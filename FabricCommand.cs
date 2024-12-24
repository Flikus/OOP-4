class FabricCommand
{
    List<ICommand> listCommand = new List<ICommand>();  //список команд

    public void AddCommand(ICommand command)
    {
        listCommand.Add(command);
    }

    public bool Command(string nameCommand)
    {
        bool ind = true;
        if(nameCommand == "exit")
            return false;


        for(int i = 0; i < listCommand.Count(); i++)
        {
            if(listCommand[i].NameCommand() == nameCommand) {
                listCommand[i].Command();
                ind = false;
            }
        }

        if(ind)
            Console.WriteLine("такої команди не існує, для перегляду всіх команд введіть help\n");

        
        return true;
    }
}