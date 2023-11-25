public class GameBoardFileChecker{
    internal GameBoardFileError Check(string[] lines){
        if (CheckIfSinglePacmanIsOnBoard(lines) == false) {
            return new GameBoardFileError("There should be exactly one pacman on the board");
        }

        if (CheckIfAtLeastOneGhostIsOnBoard(lines) == false) {
            return new GameBoardFileError("There should be at least one ghost on the board");
        }

        if (CheckIfCharactersCantEscape(lines) == false) {
            return new GameBoardFileError("Characters should not be able to escape from the board");
        }

        if (CheckIfAtLeastOneFruitIsOnBoard(lines) == false) {
            return new GameBoardFileError("There should be at least one fruit on the board");
        }

        return null;
    }

    private bool CheckIfAtLeastOneFruitIsOnBoard(string[] lines) {
        int fruitCount = 0;
        foreach (var line in lines) {
            foreach (var character in line) {
                if (character == '•') {
                    fruitCount++;
                }
            }
        }

        return fruitCount > 0;
    }

    private bool CheckIfSinglePacmanIsOnBoard(string[] lines) {
        int pacmanCount = 0;
        foreach (var line in lines) {
            foreach (var character in line) {
                if (character == '☻') {
                    pacmanCount++;
                }
            }
        }

        return pacmanCount == 1;
    }

    private bool CheckIfAtLeastOneGhostIsOnBoard(string[] lines) {
        int ghostCount = 0;
        foreach (var line in lines) {
            foreach (var character in line) {
                if (character == '◘') {
                    ghostCount++;
                }
            }
        }

        return ghostCount > 0;
    }

    private bool CheckIfCharactersCantEscape(string[] lines) {
        return CheckIfCharactersCantEscapeFromLeft(lines) &&
               CheckIfCharactersCantEscapeFromRight(lines) &&
               CheckIfCharactersCantEscapeFromTop(lines) &&
               CheckIfCharactersCantEscapeFromBottom(lines);
    }

    private bool CheckIfCharactersCantEscapeFromLeft(string[] lines) {
        foreach (var line in lines) {
            if (line[0] == ' ') {
                return false;
            }
        }

        return true;
    }

    private bool CheckIfCharactersCantEscapeFromRight(string[] lines) {
        foreach (var line in lines) {
            if (line[line.Length - 1] == ' ') {
                return false;
            }
        }

        return true;
    }

    private bool CheckIfCharactersCantEscapeFromTop(string[] lines) {
        foreach (var character in lines[0]) {
            if (character == ' ') {
                return false;
            }
        }

        return true;
    }

    private bool CheckIfCharactersCantEscapeFromBottom(string[] lines) {
        foreach (var character in lines[lines.Length - 1]) {
            if (character == ' ') {
                return false;
            }
        }

        return true;
    }
}