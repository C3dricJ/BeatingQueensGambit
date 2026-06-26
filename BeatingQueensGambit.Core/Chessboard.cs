using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.Core.Board;

public class ChessBoard
{
    public Piece?[,] Squares { get; } = new Piece?[8, 8];
}