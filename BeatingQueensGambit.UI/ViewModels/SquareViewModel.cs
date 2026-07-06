using Avalonia.Media;
using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.UI.ViewModels;

public class SquareViewModel
{
    public int Row { get; }

    public int Column { get; }

    public IBrush SquareColor =>
        (Row + Column) % 2 == 0
            ? Brushes.Bisque
            : Brushes.SaddleBrown;

    public string PieceSymbol { get; }

    public SquareViewModel(
        int row,
        int column,
        ChessBoard board)
    {
        Row = row;
        Column = column;

        var piece =
            board.GetPiece(
                new Position(row, column));

        PieceSymbol =
            GetUnicodePiece(piece);
    }

    private static string GetUnicodePiece(Piece? piece)
    {
        if (piece == null)
            return "";

        return piece switch
        {
            King k when k.Color == PieceColor.White => "♔",
            Queen q when q.Color == PieceColor.White => "♕",
            Rook r when r.Color == PieceColor.White => "♖",
            Bishop b when b.Color == PieceColor.White => "♗",
            Knight n when n.Color == PieceColor.White => "♘",
            Pawn p when p.Color == PieceColor.White => "♙",

            King k when k.Color == PieceColor.Black => "♚",
            Queen q when q.Color == PieceColor.Black => "♛",
            Rook r when r.Color == PieceColor.Black => "♜",
            Bishop b when b.Color == PieceColor.Black => "♝",
            Knight n when n.Color == PieceColor.Black => "♞",
            Pawn p when p.Color == PieceColor.Black => "♟",

            _ => ""
        };
    }
}