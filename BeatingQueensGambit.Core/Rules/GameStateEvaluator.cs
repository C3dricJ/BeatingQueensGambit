using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Game;

namespace BeatingQueensGambit.Core.Rules;

public static class GameStateEvaluator
{
    public static bool IsCheckmate(
        ChessBoard board,
        PieceColor player)
    {
        if (!KingSafety.IsKingInCheck(board, player))
        {
            return false;
        }

        var legalMoves =
            MoveGenerator.GenerateLegalMoves(
                board,
                player);

        return legalMoves.Count == 0;
    }
}