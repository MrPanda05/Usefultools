using Godot;
using System;

namespace Objects.Audio
{
    /// <summary>
    /// Audiostream that plays a single 3D sound them destroys itself
    /// </summary>
    public partial class AudioPlayerMono3D : AudioStreamPlayer3D
    {
        public void OnFinished()
        {
            QueueFree();
        }
    }
}
