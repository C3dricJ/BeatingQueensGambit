using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.Core.Rules;

public static class PawnPromotion
{
    public static bool ShouldPromote(
        Piece piece,
        Position position)
    {
        if (piece is not Pawn)
            return false;

        if (piece.Color == PieceColor.White &&
            position.Row == 0)
        {
            return true;
        }

        if (piece.Color == PieceColor.Black &&
            position.Row == 7)
        {
            return true;
        }

        return false;
    }

    public static void Promote(
        ChessBoard board,
        Position position)
    {
        var pawn = board.GetPiece(position);

        if (pawn is not Pawn)
            return;

        board.SetPiece(
            position,
            new Queen(pawn.Color));
    }
}