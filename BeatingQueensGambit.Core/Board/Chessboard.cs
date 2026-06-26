using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.Core.Board;

/// <summary>
/// Represents an 8x8 chess board.
/// </summary>
public class ChessBoard
{
    public Piece?[,] Squares { get; } = new Piece?[8,8];
}