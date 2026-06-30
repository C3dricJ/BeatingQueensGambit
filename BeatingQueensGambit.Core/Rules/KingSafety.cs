using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Pieces;
using System.Linq;

namespace BeatingQueensGambit.Core.Rules;

public static class KingSafety
{
    public static bool IsKingInCheck(
        ChessBoard board,
        PieceColor kingColor)
    {
        Position? kingPosition = null;

        // Locate the king
        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                var piece = board.Squares[row, column];

                if (piece is King &&
                    piece.Color == kingColor)
                {
                    kingPosition = new Position(row, column);
                    break;
                }
            }

            if (kingPosition != null)
                break;
        }

        if (kingPosition == null)
        {
            throw new InvalidOperationException(
                "King could not be found.");
        }

        // Look at every enemy piece
        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                var piece = board.Squares[row, column];

                if (piece == null)
                    continue;

                if (piece.Color == kingColor)
                    continue;

                var moves =
                    piece.GetLegalMoves(
                        board,
                        new Position(row, column));

                if (moves.Any(move =>
                    move.Equals(kingPosition)))
                {
                    return true;
                }
            }
        }

        return false;
    }
}