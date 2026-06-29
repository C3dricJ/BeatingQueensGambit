using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;
using System.Collections.Generic;

namespace BeatingQueensGambit.Core.Pieces;

public class Bishop : Piece
{
    public Bishop(PieceColor color)
        : base(color, PieceType.Bishop)
    {
    }

    public override IEnumerable<Position> GetLegalMoves(
        ChessBoard board,
        Position currentPosition)
    {
        var legalMoves = new List<Position>();

        int[,] directions =
        {
            {-1,-1},
            {-1, 1},
            { 1,-1},
            { 1, 1}
        };

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            int rowDirection = directions[i, 0];
            int columnDirection = directions[i, 1];

            int row = currentPosition.Row + rowDirection;
            int column = currentPosition.Column + columnDirection;

            while (true)
            {
                var position = new Position(row, column);

                if (!board.IsInsideBoard(position))
                    break;

                if (board.IsEmpty(position))
                {
                    legalMoves.Add(position);
                }
                else
                {
                    if (board.HasEnemyPiece(position, Color))
                    {
                        legalMoves.Add(position);
                    }

                    break;
                }

                row += rowDirection;
                column += columnDirection;
            }
        }

        return legalMoves;
    }
}