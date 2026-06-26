using BeatingQueensGambit.Core.Board;

namespace BeatingQueensGambit.Core.Game;

public class ChessGame
{
    public ChessBoard Board { get; }

    public ChessGame()
    {
        Board = new ChessBoard();

        BoardInitializer.InitializeStandardBoard(Board);
    }
}