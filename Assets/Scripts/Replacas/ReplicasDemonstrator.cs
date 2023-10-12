using TMPro;
using UnityEngine;

public class ReplicasDemonstrator : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Show(string content)
    {
        _text.text = content;
    }
}