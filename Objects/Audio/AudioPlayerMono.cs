using Godot;
using System;

namespace Objects.Audio
{
    public partial class AudioPlayerMono : AudioStreamPlayer
    {
        public void OnFinished()
        {
            QueueFree();
        }
    }
}
