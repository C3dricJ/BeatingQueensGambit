using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;
using System.Collections.Generic;
using BeatingQueensGambit.Core.Rules;

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

        int[] directions = { -1, 0, 1 };

        foreach (int rowOffset in directions)
        {
            foreach (int columnOffset in directions)
            {
                if (rowOffset == 0 && columnOffset == 0)
                    continue;

                var destination = new Position(
                    currentPosition.Row + rowOffset,
                    currentPosition.Column + columnOffset);

                if (!board.IsInsideBoard(destination))
                    continue;

                if (board.IsEmpty(destination) ||
                    board.HasEnemyPiece(destination, Color))
                {
                    legalMoves.Add(destination);
                }
            }
        }

        //---------------------------------------------------
        // Kingside Castling
        //---------------------------------------------------

    if (!HasMoved)
    {
        Position rookPosition =
            new Position(currentPosition.Row, 7);

        var rook =
            board.GetPiece(rookPosition) as Rook;

        if (rook != null &&
            !rook.HasMoved &&
            board.IsEmpty(new Position(currentPosition.Row, 5)) &&
            board.IsEmpty(new Position(currentPosition.Row, 6)))
        {
            bool currentSquareSafe =
                !KingSafety.IsSquareUnderAttack(
                    board,
                    currentPosition,
                    Color);

            bool middleSquareSafe =
                !KingSafety.IsSquareUnderAttack(
                    board,
                    new Position(currentPosition.Row, 5),
                    Color);

            bool destinationSafe =
                !KingSafety.IsSquareUnderAttack(
                    board,
                    new Position(currentPosition.Row, 6),
                    Color);

            if (currentSquareSafe &&
                middleSquareSafe &&
                destinationSafe)
            {
                legalMoves.Add(
                    new Position(currentPosition.Row, 6));
            }
        }
    }

        return legalMoves;
    }
}