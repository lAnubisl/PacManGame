public class Ghost : Character {
    private PacMan pacMan;
    private Direction direction = 0;
    private Random random = new Random();

    public Ghost(Position position, PacMan pacMan) : base(position) {
        direction = Direction.Up;
        this.pacMan = pacMan;
    }

    public override CharacterMovement Move() {
        var right = new Position(Position.X + 1, Position.Y);
        var down = new Position(Position.X, Position.Y + 1);
        var left = new Position(Position.X - 1, Position.Y);
        var up = new Position(Position.X, Position.Y - 1);
        List<Direction> possibleDirections = new List<Direction>();
        if (CanMove(right) && direction != Direction.Left) {
            possibleDirections.Add(Direction.Right);
        }
        if (CanMove(down) && direction != Direction.Up) {
            possibleDirections.Add(Direction.Down);
        }
        if (CanMove(left) && direction != Direction.Right) {
            possibleDirections.Add(Direction.Left);
        }
        if (CanMove(up) && direction != Direction.Down) {
            possibleDirections.Add(Direction.Up);
        }
        if (possibleDirections.Count == 0) {
            // If we can't move in the current direction, we can move in the opposite direction
            if (direction == Direction.Right) {
                possibleDirections.Add(Direction.Left);
            } else if (direction == Direction.Down) {
                possibleDirections.Add(Direction.Up);
            } else if (direction == Direction.Left) {
                possibleDirections.Add(Direction.Right);
            } else if (direction == Direction.Up) {
                possibleDirections.Add(Direction.Down);
            }
        }

        var oldPosition = Position.Clone();
        direction = possibleDirections[random.Next(0, possibleDirections.Count)];
        if (direction == Direction.Right) {
            Position = right;
        } else if (direction == Direction.Down) {
            Position = down;
        } else if (direction == Direction.Left) {
            Position = left;
        } else if (direction == Direction.Up) {
            Position = up;
        }
        
        return new CharacterMovement(oldPosition, Position, false);
    }

    private bool CanMove(Position position) {
        return gameBoard.IsWall(position) == false;
    }

    public bool PacmanCaught() {
        return Position.X == pacMan.Position.X && Position.Y == pacMan.Position.Y;
    }
}