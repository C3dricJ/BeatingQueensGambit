using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Moves;
using BeatingQueensGambit.Core.Pieces;
using System.Linq;
using BeatingQueensGambit.Core.Rules;

namespace BeatingQueensGambit.Core.Game;

public class ChessGame
{
    public ChessBoard Board { get; }

    public PieceColor CurrentTurn { get; private set; }

    public ChessGame()
    {
        Board = new ChessBoard();

        BoardInitializer.InitializeStandardBoard(Board);

        CurrentTurn = PieceColor.White;
    }

    public void MakeMove(Move move)
    {
        var piece = Board.GetPiece(move.From);

        if (piece == null)
        {
            throw new InvalidOperationException(
                "No piece exists on the starting square.");
        }

        if (piece.Color != CurrentTurn)
        {
            throw new InvalidOperationException(
                "It is not that player's turn.");
        }

        var legalMoves =
        piece.GetLegalMoves(Board, move.From);

        bool isLegal =
        legalMoves.Any(position =>
        position.Equals(move.To));

        if (!isLegal)
        {
            throw new InvalidOperationException(
            "Illegal move for selected piece.");
        }

        var testBoard = Board.Clone();

        testBoard.ApplyMove(move);

        if (KingSafety.IsKingInCheck(
           testBoard,
           CurrentTurn))
        {
            throw new InvalidOperationException(
               "You cannot leave your king in check.");
        }

        Board.ApplyMove(move);

        if(CurrentTurn == PieceColor.White)
        {
            CurrentTurn = PieceColor.Black;
        }
        else
        {
            CurrentTurn = PieceColor.White;
        }
    }

    public bool IsCheckmate()
    {
        return GameStateEvaluator.IsCheckmate(
            Board,
            CurrentTurn);
    }
}