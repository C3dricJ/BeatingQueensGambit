using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Game;
using BeatingQueensGambit.Core.Models;
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

    public static Position? GetEnPassantCaptureSquare(
        ChessGame game,
        Position pawnPosition)
    {
        if (game.LastMove == null)
        {
            return null;
        }

        var lastMovedPiece =
            game.Board.GetPiece(game.LastMove.To);

        if (lastMovedPiece == null)
        {
            return null;
        }

        if (!WasDoublePawnMove(
                lastMovedPiece,
                game.LastMove))
        {
            return null;
        }

        if (lastMovedPiece.Color ==
            game.CurrentTurn)
        {
            return null;
        }

        if (game.LastMove.To.Row !=
            pawnPosition.Row)
        {
            return null;
        }

        if (Math.Abs(
                game.LastMove.To.Column -
                pawnPosition.Column) != 1)
        {
            return null;
        }

        int direction =
            game.CurrentTurn == PieceColor.White
            ? -1
            : 1;

        return new Position(
            pawnPosition.Row + direction,
            game.LastMove.To.Column);
    }
}