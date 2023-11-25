public class Ghost : Character {

    private PacMan pacMan;

    public Ghost(Position position, PacMan pacMan) : base(position) {
        this.pacMan = pacMan;
    }
}