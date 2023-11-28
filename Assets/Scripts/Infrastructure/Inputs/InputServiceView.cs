using UnityEngine;

public class InputServiceView : MonoBehaviour
{
    public void Activate() =>
        gameObject.SetActive(true);

    public void Deactivate() =>
        gameObject.SetActive(false);
}