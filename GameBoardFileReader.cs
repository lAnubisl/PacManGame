public class GameBoardFileReader {

    private DirectoryInfo mapsDirectory;

    public GameBoardFileReader() {
        mapsDirectory = new DirectoryInfo("maps");
    }

    public string[] ListGameBoards() {
        if (mapsDirectory.Exists == false) {
            throw new Exception("maps directory does not exist");
        }

        FileInfo[] files = mapsDirectory.GetFiles("*.txt");
        string[] fileNames = new string[files.Length];
        for (int i = 0; i < files.Length; i++) {
            fileNames[i] = files[i].Name;
        }

        return fileNames;
    }

    public GameBoard ReadFromFile(string filePath) {
        // █ - wall
        // ◘ - ghost
        // ☻ - pacman
        // • - fruit
        FileInfo fileInfo = mapsDirectory.GetFiles(filePath)[0];      
        string[] lines = File.ReadAllLines(fileInfo.FullName);
        GameBoardFileChecker checker = new GameBoardFileChecker();
        var error = checker.Check(lines);
        if (error != null) {
            throw new Exception(error.Message);
        }

        PacMan pacMan = FindPacMan(lines);
        var board = new GameBoard(FindWalls(lines), FindGhosts(lines, pacMan), pacMan, FindFruits(lines));
        return board;
    }

    private PacMan FindPacMan(string[] lines) {
        for (int y = 0; y < lines.Length; y++) {
            for (int x = 0; x < lines[y].Length; x++) {
                if (lines[y][x] == '☻') {
                    return new PacMan(new Position(x, y));
                }
            }
        }

        return null;
    }

    private Ghost[] FindGhosts(string[] lines, PacMan pacMan) {
        List<Ghost> ghosts = new List<Ghost>();
        for (int y = 0; y < lines.Length; y++) {
            for (int x = 0; x < lines[y].Length; x++) {
                if (lines[y][x] == '◘') {
                    ghosts.Add(new Ghost(new Position(x, y), pacMan));
                }
            }
        }

        return ghosts.ToArray();
    }

    private Position[] FindFruits(string[] lines) {
        var fruits = new List<Position>();
        for (int y = 0; y < lines.Length; y++) {
            for (int x = 0; x < lines[y].Length; x++) {
                if (lines[y][x] == '•') {
                    fruits.Add(new Position(x, y));
                }
            }
        }
        return fruits.ToArray();
    }

    private Position[] FindWalls(string[] lines) {
        var walls = new List<Position>();
        for (int y = 0; y < lines.Length; y++) {
            for (int x = 0; x < lines[y].Length; x++) {
                if (lines[y][x] == '█') {
                    walls.Add(new Position(x, y));
                }
            }
        }
        return walls.ToArray();
    }
}