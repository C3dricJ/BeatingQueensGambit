using System;
using Xunit;
using BeatingQueensGambit.Core.Openings;

namespace BeatingQueensGambit.Tests;

public class OpeningBookTests
{
    [Fact]
    public void EveryOpeningContainsMoves()
    {
        foreach (OpeningType opening in
                 Enum.GetValues(typeof(OpeningType)))
        {
            // These are menu options, not actual opening lines.
            if (opening == OpeningType.Standard ||
                opening == OpeningType.RandomQueensGambit)
            {
                continue;
            }

            var line = OpeningBook.GetLine(opening);

            Assert.NotNull(line);

            Assert.NotEmpty(line);
        }
    }
}