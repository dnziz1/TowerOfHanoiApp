using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi;

public class HanoiTower
{
    public int DiscsCount { get; private set; }
    public int MovesCount { get; private set; }
    public Stack<int> From { get; private set; }
    public Stack<int> To { get; private set; }
    public Stack<int> Auxillary { get; private set; }
    public event EventHandler<EventArgs> MoveCompleted;

    // Properties for pause/resume functionality
    public bool IsPaused { get; private set; }
    public bool IsCompleted { get; private set; }

    // Tracking performance
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public TimeSpan Duration => IsCompleted ? EndTime - StartTime : DateTime.Now - StartTime;

    public HanoiTower(int discs)
    {
        DiscsCount = discs;
        From = new Stack<int>();
        To = new Stack<int>();
        Auxillary = new Stack<int>();
        for (int i = discs; i >= 1; i--)
        {
            From.Push(i);
        }

    }

    public void Start()
    {
        Move(DiscsCount, From, To, Auxillary);
    }

    public void Move(int discs, Stack<int> from, Stack<int> to, Stack<int> auxillary)
    {
        if (discs > 0)
        {
            // Wait if paused before recursive call
            while (IsPaused)
            {
                Task.Delay(100).Wait();
            }
            Move(discs - 1, from, auxillary, to);

            // Wait if paused before making the move

            while (IsPaused)
            {
                Task.Delay(100).Wait();
            }

            to.Push(from.Pop());
            MovesCount++;
            MoveCompleted?.Invoke(this, EventArgs.Empty);

            Move(discs - 1, auxillary, to, from);
        }
    }

    // Pause the algorithm
    public void Pause()
    {
        IsPaused = true;
    }

    // Resume the algorithm
    public void Resume()
    {
        IsPaused = false;
    }

    // To save current state of game
    public HanoiState SaveState()
    {
        return new HanoiState
        {
            DiscsCount = this.DiscsCount,
            MovesCount = this.MovesCount,
            From = new Stack<int>(new Stack<int>(this.From)),
            To = new Stack<int>(new Stack<int>(this.To)),
            Auxillary = new Stack<int>(new Stack<int>(this.Auxillary)),
            StartTime = this.StartTime
        };
    }

    // To Load state of game
    public void LoadState(HanoiState state)
    {
        this.DiscsCount = state.DiscsCount;
        this.MovesCount = state.MovesCount;
        this.From = state.From;
        this.To = state.To;
        this.Auxillary = state.Auxillary;
        this.StartTime = state.StartTime;
    }
}

// Class to represent game state for save/load functionality
public class HanoiState
{
    public int DiscsCount { get; set; }
    public int MovesCount { get; set; }
    public Stack<int> From { get; set; }
    public Stack<int> To { get; set; }
    public Stack<int> Auxillary { get; set;}
    public DateTime StartTime { get; set; }
}