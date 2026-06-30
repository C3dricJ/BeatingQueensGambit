using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Moves;
using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.Core.Rules;

public static class EnPassant
{
    public static bool WasDoublePawnMove(
        Piece piece,
        Move move)
    {
        if (piece is not Pawn)
        {
            return false;
        }

        return Math.Abs(
            move.To.Row - move.From.Row) == 2;
    }
}