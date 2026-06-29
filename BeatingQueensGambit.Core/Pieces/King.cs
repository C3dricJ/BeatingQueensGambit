using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;
using System.Collections.Generic;

namespace BeatingQueensGambit.Core.Pieces;

public class King : Piece
{
    public King(PieceColor color)
        : base(color, PieceType.King)
    {
    }

    public override IEnumerable<Position> GetLegalMoves(
        ChessBoard board,
        Position currentPosition)
    {
        var legalMoves = new List<Position>();

        int[][] directions =
        {
            new[] {-1,-1},
            new[] {-1, 0},
            new[] {-1, 1},
            new[] { 0,-1},
            new[] { 0, 1},
            new[] { 1,-1},
            new[] { 1, 0},
            new[] { 1, 1}
        };

        foreach (var direction in directions)
        {
            var nextPosition = new Position(
                currentPosition.Row + direction[0],
                currentPosition.Column + direction[1]);

            if (!board.IsInsideBoard(nextPosition))
                continue;

            if (board.IsEmpty(nextPosition))
            {
                legalMoves.Add(nextPosition);
            }
            else if (board.HasEnemyPiece(nextPosition, Color))
            {
                legalMoves.Add(nextPosition);
            }
        }

        return legalMoves;
    }
}