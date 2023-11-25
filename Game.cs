public class Game {
    private Player player;
    private GameBoard gameBoard;
    private IPresenter presenter;

    public Game(IPresenter presenter) {
        this.presenter = presenter;
    }

    public void Start() {
        presenter.ShowWelcomeMessage();
        string playerName = presenter.AskForPlayerName();
        player = new Player(playerName);
        
        GameBoardFileReader gameBoardFileReader = new GameBoardFileReader();
        string[] gameBoards = gameBoardFileReader.ListGameBoards();
        presenter.ShowBoards(gameBoards);
        int boardNumber = presenter.AskForBoardNumber();
        string boardName = gameBoards[boardNumber - 1];
        gameBoard = gameBoardFileReader.ReadFromFile(boardName);

        presenter.SetPacMan(gameBoard.PacMan);
        presenter.ShowGameBoard(gameBoard);
        Task.Factory.StartNew(() => {
            presenter.StartReadingInput();
        });

        while(IsGameOver() == false && IsGameWon() == false) {
            Thread.Sleep(300);
            Update();
        }
    }

    private bool IsGameWon() {
        return gameBoard.Fruits.Any() == false;
    }

    private bool IsGameOver() {
        foreach (var ghost in gameBoard.Ghosts) {
            if (ghost.Position.X == gameBoard.PacMan.Position.X && ghost.Position.Y == gameBoard.PacMan.Position.Y) {
                return true;
            }
        }

        return false;
    }

    private void Update() {
        var characterMovements = new List<CharacterMovement>();
        characterMovements.Add(this.gameBoard.PacMan.Move());
        foreach (var ghost in gameBoard.Ghosts) {
            characterMovements.Add(ghost.Move());
        }
        presenter.ReflectCharacterMovements(characterMovements.ToArray());
    }
}