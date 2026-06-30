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
        var movingPiece = GetPiece(move.From);

        if (movingPiece == null)
        {
            throw new InvalidOperationException(
            "Cannot move a piece that doesn't exist.");
        }

        SetPiece(move.To, movingPiece);

        SetPiece(move.From, null);
    }
}