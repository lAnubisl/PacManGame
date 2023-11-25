public class GameBoard {
    // 0 = empty
    // 1 = pacman
    // 2 = enemy
    // 3 = wall
    private byte[,] field;
    private Character[] characters;

    public GameBoard(int width, int height, Character[] characters) {
        field = new byte[width, height];
        this.characters = characters;
        InitializeFieldBorder();
    }

    private void InitializeFieldBorder() {
        for (int i = 0; i < field.GetLength(0); i++) {
            field[i, 0] = 3;
            field[i, field.GetLength(1) - 1] = 3;
        }
        for (int i = 0; i < field.GetLength(1); i++) {
            field[0, i] = 3;
            field[field.GetLength(0) - 1, i] = 3;
        }
    }
}