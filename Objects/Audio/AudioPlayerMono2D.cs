using Godot;
using System;

namespace Objects.Audio
{
    public partial class AudioPlayerMono2D : AudioStreamPlayer2D
    {
        public void OnFinished()
        {
            QueueFree();
        }
    }
}
