using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;
using System.Collections.Generic;

namespace BeatingQueensGambit.Core.Pieces;

public class Queen : Piece
{
    public Queen(PieceColor color)
        : base(color, PieceType.Queen)
    {
    }

    public override IEnumerable<Position> GetLegalMoves(
        ChessBoard board,
        Position currentPosition)
    {
        var legalMoves = new List<Position>();

        int[][] directions =
        {
            // Horizontal & Vertical
            new[] {-1, 0},
            new[] { 1, 0},
            new[] { 0,-1},
            new[] { 0, 1},

            // Diagonals
            new[] {-1,-1},
            new[] {-1, 1},
            new[] { 1,-1},
            new[] { 1, 1}
        };

        foreach (var direction in directions)
        {
            int row = currentPosition.Row + direction[0];
            int column = currentPosition.Column + direction[1];

            while (true)
            {
                var nextPosition = new Position(row, column);

                if (!board.IsInsideBoard(nextPosition))
                    break;

                if (board.IsEmpty(nextPosition))
                {
                    legalMoves.Add(nextPosition);
                }
                else
                {
                    if (board.HasEnemyPiece(nextPosition, Color))
                    {
                        legalMoves.Add(nextPosition);
                    }

                    break;
                }

                row += direction[0];
                column += direction[1];
            }
        }

        return legalMoves;
    }
}