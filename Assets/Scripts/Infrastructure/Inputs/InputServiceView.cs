using UnityEngine;

public class InputServiceView : MonoBehaviour
{
    public void Activate() =>
        enabled = true;

    public void Deactivate() =>
        enabled = false;
}