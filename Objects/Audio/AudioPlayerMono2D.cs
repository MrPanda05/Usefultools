using Godot;
using System;

namespace Objects.Audio
{
    /// <summary>
    /// Audiostream that plays a single 2D sound them destroys itself
    /// </summary>
    public partial class AudioPlayerMono2D : AudioStreamPlayer2D
    {
        public void OnFinished()
        {
            QueueFree();
        }
    }
}
