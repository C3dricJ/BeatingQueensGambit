using Xunit;
using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Evaluation;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.Tests;

public class BoardEvaluationTests
{
    [Fact]
    public void EmptyBoard_IsZero()
    {
        var board = new ChessBoard();

        int score =
            BoardEvaluator.Evaluate(
                board,
                PieceColor.White);

        Assert.Equal(0, score);
    }

    [Fact]
    public void WhiteQueen_IsPositive()
    {
        var board = new ChessBoard();

        board.SetPiece(
            new Position(3, 3),
            new Queen(PieceColor.White));

        int score =
            BoardEvaluator.Evaluate(
                board,
                PieceColor.White);

        Assert.Equal(900, score);
    }

    [Fact]
    public void BlackQueen_IsNegative()
    {
        var board = new ChessBoard();

        board.SetPiece(
            new Position(3, 3),
            new Queen(PieceColor.Black));

        int score =
            BoardEvaluator.Evaluate(
                board,
                PieceColor.White);

        Assert.Equal(-900, score);
    }
}