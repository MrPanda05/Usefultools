using Godot;
using System;

namespace Managers
{
    public partial class GameManager : Node
    {
        public static GameManager Instance { get; private set; }

        public RandomNumberGenerator RNG { get; private set; } = new RandomNumberGenerator();

        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
            RNG.Randomize();
        }
    }
}
