using Godot;
using Managers;
using System;

namespace Tests
{
    public partial class TestScene2d : Node2D
    {
        [Export]
        public AudioStream audio;

        public override void _Ready()
        {
            AudioManager.Instance.PlaySound(audio);
        }
    }
}
