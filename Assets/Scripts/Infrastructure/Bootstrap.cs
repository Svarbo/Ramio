using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Curtain _curtain;

    private void Awake()
    {
        _curtain.Hide();
    }
}