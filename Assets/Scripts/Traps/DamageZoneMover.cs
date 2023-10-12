using UnityEngine;

public class DamageZoneMover : MonoBehaviour
{
    [SerializeField] private float _motionSpeed;

    private void Update()
    {
        transform.Translate(Vector2.right * _motionSpeed * Time.deltaTime);
    }
}