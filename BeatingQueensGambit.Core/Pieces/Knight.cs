using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;
using System.Collections.Generic;

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
        var legalMoves = new List<Position>();

        int[,] offsets =
        {
            {-2,-1},
            {-2, 1},
            {-1,-2},
            {-1, 2},
            { 1,-2},
            { 1, 2},
            { 2,-1},
            { 2, 1}
        };

        for (int i = 0; i < offsets.GetLength(0); i++)
        {
            var move = new Position(
                currentPosition.Row + offsets[i,0],
                currentPosition.Column + offsets[i,1]);

            if (!board.IsInsideBoard(move))
                continue;

            if (board.IsEmpty(move) ||
                board.HasEnemyPiece(move, Color))
            {
                legalMoves.Add(move);
            }
        }

        return legalMoves;
    }
}