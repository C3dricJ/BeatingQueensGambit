using Avalonia.Media;
using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.UI.ViewModels;

public class SquareViewModel
{
    public int Row { get; }

    public int Column { get; }

    public Piece? Piece { get; }

    public string PieceSymbol { get; }

    public IBrush SquareColor { get; }

    public SquareViewModel(
        int row,
        int column,
        Piece? piece)
    {
        Row = row;
        Column = column;

        Piece = piece;

        PieceSymbol =
            GetUnicodePiece(piece);

        bool light =
            (row + column) % 2 == 0;

        SquareColor =
            light
            ? Brushes.Bisque
            : Brushes.SaddleBrown;
    }

    private static string GetUnicodePiece(
        Piece? piece)
    {
        if (piece == null)
            return "";

        return piece switch
        {
            King king =>
                king.Color ==
                Core.Enums.PieceColor.White
                ? "♔"
                : "♚",

            Queen queen =>
                queen.Color ==
                Core.Enums.PieceColor.White
                ? "♕"
                : "♛",

            Rook rook =>
                rook.Color ==
                Core.Enums.PieceColor.White
                ? "♖"
                : "♜",

            Bishop bishop =>
                bishop.Color ==
                Core.Enums.PieceColor.White
                ? "♗"
                : "♝",

            Knight knight =>
                knight.Color ==
                Core.Enums.PieceColor.White
                ? "♘"
                : "♞",

            Pawn pawn =>
                pawn.Color ==
                Core.Enums.PieceColor.White
                ? "♙"
                : "♟",

            _ => ""
        };
    }
}