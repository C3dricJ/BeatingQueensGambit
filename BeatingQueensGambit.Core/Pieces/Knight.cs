using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;

namespace BeatingQueensGambit.Core.Pieces;

public class Knight : Piece
{
    public Knight(PieceColor color)
        : base(color, PieceType.Knight)
    {
    }
 
    public override IEnumerable<Position> GetLegalMoves(
        ChessBoard board,
        Position currentPosition)
        {
           return Enumerable.Empty<Position>();
        }
}