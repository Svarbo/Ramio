using UnityEngine;

public class LevelMenuView : MonoBehaviour
{
    [field: SerializeField] public LevelsProgress LevelsProgress { get; private set; }
    [field: SerializeField] public ButtonStartGame ButtonStartGame { get; private set; }
    [field: SerializeField] public LevelsRow LevelsRow { get; private set; }
    [field: SerializeField] public EasyDifficultViewButton EasyDifficultViewButton { get; private set; }
    [field: SerializeField] public MediumDifficultViewButton MediumDifficultViewButton { get; private set; }
    [field: SerializeField] public HardDifficultViewButton HardDifficultViewButton { get; private set; }
}