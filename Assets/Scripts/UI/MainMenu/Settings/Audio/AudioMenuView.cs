using Assets.Scripts.Audio;
using UnityEngine;

public class AudioMenuView : MonoBehaviour
{
    [field: SerializeField] public GameAudioData GameAudioData { get; private set; }

    [field: SerializeField] public AllAudioView AllAudioView { get; private set; }
    [field: SerializeField] public EffectsView EffectsView { get; private set; }
    [field: SerializeField] public MusicView MusicView { get; private set; }
}