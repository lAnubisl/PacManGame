public class CharacterMovement {
    public CharacterMovement(Position from, Position to, bool isPacman) {
        From = from;
        To = to;
        IsPacman = isPacman;
    }
    
    public Position From { get; private set; }
    public Position To { get; private set; }
    public bool IsPacman { get; private set; }
}