class PlayGame
{
    GameAccount Player1;
    GameAccount Player2;
    Game Games;
    public PlayGame(GameAccount player1, GameAccount player2, Game games)
    {
        Player1 = player1;
        Player2 = player2;
        Games = games;

        player1.WinGame(player2.UserName, games);
        player2.LoseGame(player1.UserName, games);
    }

    public void Result()
    {
        	Console.WriteLine("------------------------------");
			Console.WriteLine("| виграв | програв | рейтинг |");	
			Console.Write("|{0,7} |", Player1.UserName);		
			Console.Write("{0,8} |" , Player2.UserName);			
			Console.Write("{0, 8} |", Games.Rating);
            Console.WriteLine();
			Console.WriteLine("------------------------------");
    }
}