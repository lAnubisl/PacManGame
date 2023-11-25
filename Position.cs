public class Position {

    public Position(int x, int y) {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public Position Clone() {
        return new Position(X, Y);
    }

    public override bool Equals(object obj) {
        if (obj == null) {
            return false;
        }

        if (obj.GetType() != typeof(Position)) {
            return false;
        }

        var other = (Position)obj;
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode() {
        return X.GetHashCode() ^ Y.GetHashCode();
    }
}