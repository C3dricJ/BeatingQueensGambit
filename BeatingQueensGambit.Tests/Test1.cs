using BeatingQueensGambit.Core.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeatingQueensGambit.Tests;

[TestClass]
public class ChessGameTests
{
    [TestMethod]
    public void NewGame_ShouldCreateBoard()
    {
        var game = new ChessGame();

        Assert.IsNotNull(game.Board);
    }
}