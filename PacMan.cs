public class PacMan : Character {

    // 0 = right, 1 = down, 2 = left, 3 = up
    private byte direction = 0;

    public PacMan(Position position) : base(position) {
    }

    public override CharacterMovement Move()
    {   
        var oldPosition = Position.Clone();
        var newPosition = GetNewPosition();
        Position = newPosition;
        if (gameBoard.IsFruit(newPosition)) {
            gameBoard.RemoveFruit(newPosition);
        }
        return new CharacterMovement(oldPosition, newPosition, true);
    }

    public void TurnLeft() {
        direction = 2;
    }

    public void TurnRight() {
        direction = 0;
    }

    public void TurnDown() {
        direction = 1;
    }

    public void TurnUp() {
        direction = 3;
    }

    private Position GetNewPosition() {
        var newPosition = Position;
        if (direction == 0) {
            newPosition = new Position(Position.X + 1, Position.Y);
        } else if (direction == 1) {
            newPosition = new Position(Position.X, Position.Y + 1);
        } else if (direction == 2) {
            newPosition = new Position(Position.X - 1, Position.Y);
        } else if (direction == 3) {
            newPosition = new Position(Position.X, Position.Y - 1);
        }

        if (gameBoard.IsWall(newPosition)) {
            return Position;
        }

        return newPosition;
    }
}