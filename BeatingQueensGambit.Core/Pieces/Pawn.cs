using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Rules;

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

        //------------------------------------------------
        // One square forward
        //------------------------------------------------

        var oneForward =
            new Position(
                currentPosition.Row + direction,
                currentPosition.Column);

        if (board.IsEmpty(oneForward))
        {
            legalMoves.Add(oneForward);

            //------------------------------------------------
            // Initial two-square move
            //------------------------------------------------

            bool startingRow =
                (IsWhite && currentPosition.Row == 6) ||
                (IsBlack && currentPosition.Row == 1);

            var twoForward =
                new Position(
                    currentPosition.Row + direction * 2,
                    currentPosition.Column);

            if (startingRow &&
                board.IsEmpty(twoForward))
            {
                legalMoves.Add(twoForward);
            }
        }

        //------------------------------------------------
        // Capture Left
        //------------------------------------------------

        var captureLeft =
            new Position(
                currentPosition.Row + direction,
                currentPosition.Column - 1);

        if (board.HasEnemyPiece(captureLeft, Color))
        {
            legalMoves.Add(captureLeft);
        }

        //------------------------------------------------
        // Capture Right
        //------------------------------------------------

        var captureRight =
            new Position(
                currentPosition.Row + direction,
                currentPosition.Column + 1);

        if (board.HasEnemyPiece(captureRight, Color))
        {
            legalMoves.Add(captureRight);
        }

        //------------------------------
        // En Passant
        //------------------------------

        if (board.Game != null)
        {
            var enPassantSquare =
                EnPassant.GetEnPassantCaptureSquare(
                    board.Game,
                    currentPosition);

            if (enPassantSquare != null)
            {
                legalMoves.Add(enPassantSquare);
            }
        }

        return legalMoves;
    }
}