class Program 
{	
	static int Main() {
    	DbContext dbContext = new DbContext();
		FabricCommand terminal = new FabricCommand();
		PlayerService adminPlayer = new PlayerService(dbContext);
		GameService	  adminGame  = new GameService(dbContext);

		// Додаємо команди
		terminal.AddCommand(new CommandCreateAccount(adminPlayer));
		terminal.AddCommand(new CommandCreateGame(adminGame));
		terminal.AddCommand(new CommandImagePlayer(adminPlayer));
		terminal.AddCommand(new CommandImageAllPlayer(adminPlayer));
		terminal.AddCommand(new CommandImagePlayerGame(adminPlayer));
		terminal.AddCommand(new CommandImageAllGame(adminGame));
		terminal.AddCommand(new CommandPlayGame(adminPlayer, adminGame));
		terminal.AddCommand(new CommandHelp());



		adminPlayer.CreateAccont("User1", "Standart");
		adminPlayer.CreateAccont("User2", "Pay");

		adminGame.CreateGame("Standart", 90);

		do{
			Console.Write("\nВведіть команду: ");

		} while(terminal.Command(Console.ReadLine()));

		return 0;
	}
}

