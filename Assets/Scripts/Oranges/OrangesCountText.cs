using TMPro;
using UnityEngine;

public class OrangesCountText : MonoBehaviour
{
    [SerializeField] private TMP_Text _countText;

    private int _collectedOrangesCount;
    private int _allOrangesCount;

    // TODO    
    // public void SetAllOrangesCount(int allOrangesCount) =>
    //     _allOrangesCount = allOrangesCount;
    //
    // public void SetCollectedOrangesCount(int collectedOrangesCount) =>
    //     _collectedOrangesCount = collectedOrangesCount;

    public void SetCountText(int collectedOrangesCount, int allOrangesCount) =>
        _countText.text = $"{collectedOrangesCount}/{allOrangesCount}";
}