using Godot;
using Managers;
using Objects.Audio;
using System;

namespace Components
{
    /// <summary>
    /// A component that plays sounds, this is supposed to be an alternative to the singleton audio manager
    /// </summary>
    public partial class AudioComponent : Node
    {
        [Export]
        private PackedScene _audioMono;
        private AudioPlayerMono InstantiateAudioMonoNode()
        {
            return _audioMono.Instantiate<AudioPlayerMono>();
        }
        public void PlaySound(AudioStream audio, float minPitch = 1, float maxPitch = 1, string audioBus = "Master")
        {
            var audioNode = InstantiateAudioMonoNode();
            audioNode.Stream = audio;
            float randPitch = GameManager.Instance.RNG.RandfRange(minPitch, maxPitch);
            audioNode.Bus = audioBus;
            GetTree().CurrentScene.AddChild(audioNode);
            audioNode.Play();
        }
    }
}
