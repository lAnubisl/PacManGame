public class ConsolePresenter : IPresenter
{
    private PacMan pacMan;

    public ConsolePresenter()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
    }

    public void SetPacMan(PacMan pacMan)
    {
        this.pacMan = pacMan;
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

    public void ReflectCharacterMovements(CharacterMovement[] characterMovements)
    {
        foreach (var characterMovement in characterMovements)
        {
            SetPosition(characterMovement.From);
            Console.Write(" ");
            SetPosition(characterMovement.To);
            Console.Write(characterMovement.IsPacman ? "☻" : "◘");
        }
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
                case ConsoleKey.LeftArrow: pacMan.TurnLeft(); break;
                case ConsoleKey.RightArrow: pacMan.TurnRight(); break;
                case ConsoleKey.UpArrow: pacMan.TurnUp(); break;
                case ConsoleKey.DownArrow: pacMan.TurnDown(); break;
            }
        }
    }
}