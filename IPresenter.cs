public interface IPresenter {
    void ShowWelcomeMessage();

    string AskForPlayerName();

    void ShowBoards(string[] boards);

    int AskForBoardNumber();

    void ShowGameBoard(GameBoard gameBoard);

    void ReflectCharacterMovements(CharacterMovement[] characterMovements);

    void SetPacMan(PacMan pacMan);

    void StartReadingInput();
}