using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.History;

namespace BeatingQueensGambit.Core.Notation;

/// <summary>
/// Converts moves into Standard Algebraic Notation (SAN).
/// </summary>
public static class ChessNotation
{
    public static string ToNotation(MoveRecord move)
    {
        //-----------------------------------------
        // Castling
        //-----------------------------------------

        if (move.WasCastleKingside)
            return "O-O";

        if (move.WasCastleQueenside)
            return "O-O-O";

        string notation = "";

        //-----------------------------------------
        // Piece Letter
        //-----------------------------------------

        notation += move.Piece switch
        {
            PieceType.King => "K",
            PieceType.Queen => "Q",
            PieceType.Rook => "R",
            PieceType.Bishop => "B",
            PieceType.Knight => "N",
            _ => ""
        };

        //-----------------------------------------
        // Pawn Capture
        //-----------------------------------------

        if (move.Piece == PieceType.Pawn &&
            move.WasCapture)
        {
            notation +=
                (char)('a' + move.From.Column);
        }

        //-----------------------------------------
        // Capture Marker
        //-----------------------------------------

        if (move.WasCapture)
        {
            notation += "x";
        }

        //-----------------------------------------
        // Destination Square
        //-----------------------------------------

        notation +=
            ConvertSquare(move.To);

        //-----------------------------------------
        // Promotion
        //-----------------------------------------

        if (move.WasPromotion &&
            move.PromotionPiece != null)
        {
            notation += "=";

            notation += move.PromotionPiece switch
            {
                PieceType.Queen => "Q",
                PieceType.Rook => "R",
                PieceType.Bishop => "B",
                PieceType.Knight => "N",
                _ => ""
            };
        }

        //-----------------------------------------
        // Check / Checkmate
        //-----------------------------------------

        if (move.WasCheckmate)
        {
            notation += "#";
        }
        else if (move.WasCheck)
        {
            notation += "+";
        }

        return notation;
    }

    private static string ConvertSquare(Models.Position position)
    {
        char file =
            (char)('a' + position.Column);

        int rank =
            8 - position.Row;

        return $"{file}{rank}";
    }
}