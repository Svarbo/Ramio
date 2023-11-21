using UnityEngine;

public class DifficultInfoPanel : MonoBehaviour
{
    [field: SerializeField] public EasyDifficultView EasyDifficultView { get; private set; }
    [field: SerializeField] public MediumDifficultView MediumDifficultView { get; private set; }
    [field: SerializeField] public HardDifficultView HardDifficultView { get; private set; }
}