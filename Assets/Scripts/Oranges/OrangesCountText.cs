using TMPro;
using UnityEngine;

public class OrangesCountText : MonoBehaviour
{
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private OrangesCounter _orangesCounter;

    public void SetCountText()
    {
        int collectedOrangesCount = _orangesCounter.TakeCollectedOrangesCount();
        int allOrangesCount = _orangesCounter.TakeAllOrangesCount();

        _countText.text = $"{collectedOrangesCount}/{allOrangesCount}";
    }
}