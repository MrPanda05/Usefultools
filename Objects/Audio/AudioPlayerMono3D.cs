using Godot;
using System;

namespace Objects.Audio
{
    public partial class AudioPlayerMono3D : AudioStreamPlayer3D
    {
        public void OnFinished()
        {
            QueueFree();
        }
    }
}
