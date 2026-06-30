using BeatingQueensGambit.Core.Pieces;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Moves;

namespace BeatingQueensGambit.Core.Board;

/// <summary>
/// Represents an 8x8 chess board.
/// </summary>
public class ChessBoard
{
    public Piece?[,] Squares { get; } = new Piece?[8,8];
    public Piece? GetPiece(Position position)
    {
        return Squares[position.Row, position.Column];
    }

    public void SetPiece(Position position, Piece? piece)
    {
        Squares[position.Row, position.Column] = piece;
    }

    public bool IsInsideBoard(Position position)
    {
        return
        position.Row >= 0 &&
        position.Row < 8 &&
        position.Column >= 0 &&
        position.Column < 8;
    }

    public bool IsEmpty(Position position)
    {
        return
        IsInsideBoard(position) &&
        GetPiece(position) == null;
    }

    public bool HasEnemyPiece(
    Position position,
    PieceColor myColor)
    {
    if (!IsInsideBoard(position))
        return false;

    var piece = GetPiece(position);

    return piece != null &&
           piece.Color != myColor;
    }

    public bool HasFriendlyPiece(
    Position position,
    PieceColor myColor)
{
    if (!IsInsideBoard(position))
        return false;

    var piece = GetPiece(position);

    return piece != null &&
           piece.Color == myColor;
    }

    public void ApplyMove(Move move)
    {
        var piece = GetPiece(move.From);

        if (piece == null)
            return;

        //--------------------------------------------------
        // Handle Kingside Castling
        //--------------------------------------------------

        if (piece is King &&
            Math.Abs(move.To.Column - move.From.Column) == 2)
        {
            Position rookStart =
                new Position(move.From.Row, 7);

            Position rookEnd =
                new Position(move.From.Row, 5);

            var rook = GetPiece(rookStart);

            if (rook != null)
            {
                SetPiece(rookEnd, rook);
                SetPiece(rookStart, null);

                rook.MarkAsMoved();
            }
        }

        //--------------------------------------------------
        // Move the selected piece
        //--------------------------------------------------

        SetPiece(move.To, piece);

        SetPiece(move.From, null);

        piece.MarkAsMoved();
    }

    public ChessBoard Clone()
    {
        var clone = new ChessBoard();

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                clone.Squares[row, column] = Squares[row, column];
            }
        }

        return clone;
    }

    
}