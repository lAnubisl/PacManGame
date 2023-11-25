public class Character {

    protected GameBoard gameBoard;

    public Character(Position position) {
        this.Position = position;
    }

    public void SetGameBoard(GameBoard gameBoard) {
        this.gameBoard = gameBoard;
    }

    public virtual CharacterMovement Move() {
        return null;
    }

    public Position Position { get; set; }
}