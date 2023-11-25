public class Game {
    private Player player;
    private GameBoard gameBoard;

    private PacMan pacMan;

    public Game() {
        gameBoard = new GameBoard(
            40, 
            30, 
            new Character[] {
                this.pacMan,
                new Ghost(),
                new Ghost(),
                new Ghost(),
                new Ghost(),
            }
        );

        this.pacMan = new PacMan(new Position(0, 0));
    }

    public void Start() {
        Console.WriteLine($"Welcome to the game, Please enter your name: ");
        string playerName = Console.ReadLine();
        this.player = new Player(playerName);
        Console.WriteLine($"Welcome {player.Name}!");
    }

    private bool IsGameOver() {
        return false;
    }

    private void Update() {

    }
}