using BeatingQueensGambit.Core.Board;

namespace BeatingQueensGambit.Core.Openings;

public static class OpeningLoader
{
    public static void Load(
        ChessBoard board,
        OpeningType opening)
    {
        // Always initialize a standard board.
        // Openings are now replayed through ChessGame.
        BoardInitializer.InitializeStandardBoard(board);
    }
}