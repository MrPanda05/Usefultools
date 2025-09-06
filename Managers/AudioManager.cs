using Godot;
using Objects.Audio;
using System;
using System.Collections.Generic;

namespace Managers
{
    public partial class AudioManager : Node
    {
        public static AudioManager Instance { get; private set; }

        //public List<AudioPlayerMono> AudioPlayerMonos { get; private set; } = new List<AudioPlayerMono>();

        [Export]
        private PackedScene _audioMono;
        [Export]
        private PackedScene _audioMono2D;
        [Export]
        private PackedScene _audioMono3D;

        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
        }
        private AudioPlayerMono InstantiateAudioMonoNode()
        {
            return _audioMono.Instantiate<AudioPlayerMono>();
        }
        private AudioPlayerMono2D InstantiateAudioMonoNode2D()
        {
            return _audioMono2D.Instantiate<AudioPlayerMono2D>();
        }
        private AudioPlayerMono3D InstantiateAudioMonoNode3D()
        {
            return _audioMono3D.Instantiate<AudioPlayerMono3D>();
        }
        /// <summary>
        /// Play an soundeffect globaly, by instantiating a audioNode
        /// Theses audio are one time use
        /// </summary>
        public void PlaySound(AudioStream audio, float minPitch = 1, float maxPitch = 1, string audioBus = "Master")
        {
            var audioNode = InstantiateAudioMonoNode();
            audioNode.Stream = audio;
            float randPitch = GameManager.Instance.RNG.RandfRange(minPitch, maxPitch);
            audioNode.Bus = audioBus;
            GetTree().CurrentScene.AddChild(audioNode);
            audioNode.Play();
        }


        /// <summary>
        /// Play an soundeffect at 2D position
        /// Theses audio are one time use
        /// </summary>
        public void PlaySound2D(AudioStream audio, Vector2 pos,float minPitch = 1, float maxPitch = 1, string audioBus = "Master", float maxDistance = 2000, float attenuation = 1, float panning = 1)
        {
            var audioNode = InstantiateAudioMonoNode2D();
            audioNode.Stream = audio;
            float randPitch = GameManager.Instance.RNG.RandfRange(minPitch, maxPitch);
            audioNode.Bus = audioBus;
            audioNode.MaxDistance = maxDistance;
            audioNode.Attenuation = attenuation;
            audioNode.PanningStrength = panning;
            GetTree().CurrentScene.AddChild(audioNode);
            audioNode.GlobalPosition = pos;
            audioNode.Play();
        }


        /// <summary>
        /// Play an soundeffect at 3D position
        /// Theses audio are one time use
        /// </summary>
        public void PlaySound3D(AudioStream audio, Vector3 pos, float minPitch = 1, float maxPitch = 1, string audioBus = "Master", AudioStreamPlayer3D.AttenuationModelEnum attenuation = AudioStreamPlayer3D.AttenuationModelEnum.InverseDistance, float unitSize = 10, float maxDb = 10, float maxDistance = 0, float panning = 0)
        {
            var audioNode = InstantiateAudioMonoNode3D();
            audioNode.Stream = audio;
            float randPitch = GameManager.Instance.RNG.RandfRange(minPitch, maxPitch);
            audioNode.Bus = audioBus;
            audioNode.AttenuationModel = attenuation;
            audioNode.PanningStrength = panning;
            audioNode.UnitSize = unitSize;
            audioNode.MaxDb = maxDb;
            audioNode.MaxDistance = maxDistance;
            GetTree().CurrentScene.AddChild(audioNode);
            audioNode.GlobalPosition = pos;
            audioNode.Play();
        }
    }
}
