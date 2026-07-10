using System.Linq;
using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.History;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Moves;
using BeatingQueensGambit.Core.Notation;
using BeatingQueensGambit.Core.Pieces;
using BeatingQueensGambit.Core.Rules;

namespace BeatingQueensGambit.Core.Game;

public class ChessGame
{
    public ChessBoard Board { get; }

    public PieceColor CurrentTurn { get; private set; }
    public Move? LastMove { get; private set; }

    public List<MoveRecord> MoveHistory { get; }
    = new();

    public ChessGame()
    {
        Board = new ChessBoard();

        Board.Game = this;

        BoardInitializer.InitializeStandardBoard(Board);

        CurrentTurn = PieceColor.White;
    }

    public void MakeMove(Move move)
    {
        var piece = Board.GetPiece(move.From);

        bool wasCapture =
            Board.GetPiece(move.To) != null;

        bool wasCastleKingside =
            piece is King &&
            move.From.Column == 4 &&
            move.To.Column == 6;

        bool wasCastleQueenside =
            piece is King &&
            move.From.Column == 4 &&
            move.To.Column == 2;

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

        LastMove = move;

        var moveRecord =
            new MoveRecord(
                piece.Type,
                piece.Color,
                move.From,
                move.To,
                wasCapture,
                wasCastleKingside,
                wasCastleQueenside,
                false,
                null);

        moveRecord.Notation =
            ChessNotation.ToNotation(moveRecord);

        MoveHistory.Add(moveRecord);

        if(CurrentTurn == PieceColor.White)
        {
            CurrentTurn = PieceColor.Black;
        }
        else
        {
            CurrentTurn = PieceColor.White;
        }
    }

    public List<Position> GetLegalMoves(Position from)
    {
        var piece = Board.GetPiece(from);

        if (piece == null)
        {
            return new List<Position>();
        }

        return piece
            .GetLegalMoves(Board, from)
            .ToList();
    }

    public bool TryMove(Position from, Position to)
    {
        try
        {
            MakeMove(new Move(from, to));
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool IsCheckmate()
    {
        return GameStateEvaluator.IsCheckmate(
            Board,
            CurrentTurn);
    }

    public bool IsStalemate()
    {
        return GameStateEvaluator.IsStalemate(
            Board,
            CurrentTurn);
    }

    
}