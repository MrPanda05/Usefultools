using Godot;
using System;

namespace Objects.Audio
{
    /// <summary>
    /// Audiostream that plays a single sound them destroys itself
    /// </summary>
    public partial class AudioPlayerMono : AudioStreamPlayer
    {
        public void OnFinished()
        {
            QueueFree();
        }
    }
}
