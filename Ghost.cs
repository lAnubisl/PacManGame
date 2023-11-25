public class Ghost : Character {
    private PacMan pacMan;

    public Ghost(Position position, PacMan pacMan) : base(position) {
        this.pacMan = pacMan;
    }

    public override CharacterMovement Move() {
        var pacManPosition = pacMan.Position;
        var oldPosition = Position.Clone();
        var newPosition = Position;
        if (pacManPosition.X > Position.X) {
            newPosition = new Position(Position.X + 1, Position.Y);
        } else if (pacManPosition.X < Position.X) {
            newPosition = new Position(Position.X - 1, Position.Y);
        } else if (pacManPosition.Y > Position.Y) {
            newPosition = new Position(Position.X, Position.Y + 1);
        } else if (pacManPosition.Y < Position.Y) {
            newPosition = new Position(Position.X, Position.Y - 1);
        }

        if (gameBoard.IsWall(newPosition)) {
            return new CharacterMovement(Position, Position, false);
        }

        Position = newPosition;
        return new CharacterMovement(oldPosition, newPosition, false);
    }
}