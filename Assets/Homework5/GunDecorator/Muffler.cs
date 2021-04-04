using UnityEngine;


namespace Assets.Homework5.GunDecorator
{
    internal sealed class Muffler : IMuffler
    {
        public AudioClip AudioClipMuffler { get; }
        public float VolumeFireOnMuffler { get; }
        public Transform BarrelPositionMuffler { get; }
        public GameObject MufflerInstance { get; }

        public Muffler(AudioClip audioClipMuffler, float volumeFireOnMuffler, Transform barrelPositionMuffler, GameObject mufflerInstance)
        {
            AudioClipMuffler = audioClipMuffler;
            VolumeFireOnMuffler = volumeFireOnMuffler;
            BarrelPositionMuffler = barrelPositionMuffler;
            MufflerInstance = mufflerInstance;
        }
    }
}