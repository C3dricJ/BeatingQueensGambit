using Xunit;
using BeatingQueensGambit.Core.AI;
using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.Tests;

public class AlphaBetaTests
{
    private ChessBoard CreateBoard()
    {
        var board = new ChessBoard();

        board.SetPiece(
            new Position(7,4),
            new King(PieceColor.White));

        board.SetPiece(
            new Position(0,4),
            new King(PieceColor.Black));

        return board;
    }

    [Fact]
    public void AlphaBetaReturnsEvaluation()
    {
        var board = CreateBoard();

        board.SetPiece(
            new Position(4,4),
            new Queen(PieceColor.White));

        int score =
            Minimax.Search(
                board,
                2,
                true,
                PieceColor.White);

        Assert.True(score >= 900);
    }
}