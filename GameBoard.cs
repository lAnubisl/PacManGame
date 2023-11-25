public class GameBoard {
    public Ghost[] Ghosts {get; private set;}
    public PacMan PacMan {get; private set;}
    public HashSet<Position> Walls { get; private set; }
    public HashSet<Position> Fruits { get; private set; }
    public GameBoard(Position[] walls, Ghost[] ghosts, PacMan pacMan, Position[] fruits) {
        Walls = new HashSet<Position>(walls);
        Fruits = new HashSet<Position>(fruits);
        Ghosts = ghosts;
        PacMan = pacMan;
        pacMan.SetGameBoard(this);
        foreach (var ghost in ghosts) {
            ghost.SetGameBoard(this);
        }
    }

    public bool IsWall(Position position) {
        return Walls.Contains(position);
    }

    public bool IsFruit(Position position) {
        return Fruits.Contains(position);
    }

    public void RemoveFruit(Position position) {
        Fruits.Remove(position);
    }
}