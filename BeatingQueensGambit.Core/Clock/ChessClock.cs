using System;

namespace BeatingQueensGambit.Core.Clock;

public class ChessClock
{
    public TimeSpan WhiteTime { get; private set; }

    public TimeSpan BlackTime { get; private set; }

    public bool WhiteRunning { get; private set; }

    public bool BlackRunning { get; private set; }

    public ChessClock()
    {
        Reset();
    }

    public void Reset()
    {
        WhiteTime = TimeSpan.FromMinutes(10);
        BlackTime = TimeSpan.FromMinutes(10);

        WhiteRunning = true;
        BlackRunning = false;
    }

    public void SwitchTurn()
    {
        WhiteRunning = !WhiteRunning;
        BlackRunning = !BlackRunning;
    }

    public void Tick()
    {
        if (WhiteRunning && WhiteTime > TimeSpan.Zero)
        {
            WhiteTime -= TimeSpan.FromSeconds(1);
        }

        if (BlackRunning && BlackTime > TimeSpan.Zero)
        {
            BlackTime -= TimeSpan.FromSeconds(1);
        }
    }

    public bool WhiteFlagged =>
        WhiteTime <= TimeSpan.Zero;

    public bool BlackFlagged =>
        BlackTime <= TimeSpan.Zero;
}