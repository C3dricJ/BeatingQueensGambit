using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;
using System.Collections.Generic;

namespace BeatingQueensGambit.Core.Pieces;

public class Pawn : Piece
{
    public Pawn(PieceColor color)
        : base(color, PieceType.Pawn)
    {
    }

    public override IEnumerable<Position> GetLegalMoves(
    ChessBoard board,
    Position currentPosition)
    {
        var legalMoves = new List<Position>();

        int direction = IsWhite ? -1 : 1;

        var oneForward = new Position(
            currentPosition.Row + direction,
            currentPosition.Column);

        if (board.IsEmpty(oneForward))
        {
            legalMoves.Add(oneForward);
        }

        return legalMoves;
    }
}