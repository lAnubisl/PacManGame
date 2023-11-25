public class ConsolePresenter : IPresenter
{
    private GameBoard gameBoard;

    public ConsolePresenter()
    {
        Console.WindowHeight = 60;
        Console.WindowWidth = 60;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
    }

    public void SetGameBoard(GameBoard gameBoard)
    {
        this.gameBoard = gameBoard;
    }

    public int AskForBoardNumber()
    {
        Console.WriteLine("Please select a game board: ");
        return int.Parse(Console.ReadLine());
    }

    public string AskForPlayerName()
    {
        Console.WriteLine("Please enter your name: ");
        return Console.ReadLine();
    }

    public void ReflectCharacterMovements(CharacterMovement characterMovements)
    {
        SetPosition(characterMovements.From);
        if (characterMovements.IsPacman == false && gameBoard.IsFruit(characterMovements.From))
        {
            Console.Write("•");
        }
        else
        {
            Console.Write(" ");
        }
        SetPosition(characterMovements.To);
        Console.Write(characterMovements.IsPacman ? "☻" : "◘");
    }

    private void SetPosition(Position position)
    {
        Console.SetCursorPosition(position.X, position.Y);
    }

    public void ShowBoards(string[] boards)
    {
        for (int i = 0; i < boards.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {boards[i]}");
        }
    }

    public void ShowGameBoard(GameBoard gameBoard)
    {
        Console.Clear();
        Thread.Sleep(100);
        foreach (var wall in gameBoard.Walls)
        {
            SetPosition(wall);
            Console.Write("█");
        }

        foreach (var fruit in gameBoard.Fruits)
        {
            SetPosition(fruit);
            Console.Write("•");
        }

        foreach (var ghost in gameBoard.Ghosts)
        {
            SetPosition(ghost.Position);
            Console.Write("◘");
        }

        SetPosition(gameBoard.PacMan.Position);
        Console.Write("☻");
    }

    public void ShowWelcomeMessage()
    {
        Console.WriteLine("Welcome to PacMan!");
    }

    public void StartReadingInput()
    {
        while (true)
        {
            var keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow: gameBoard.PacMan.TurnLeft(); break;
                case ConsoleKey.RightArrow: gameBoard.PacMan.TurnRight(); break;
                case ConsoleKey.UpArrow: gameBoard.PacMan.TurnUp(); break;
                case ConsoleKey.DownArrow: gameBoard.PacMan.TurnDown(); break;
            }
        }
    }
}