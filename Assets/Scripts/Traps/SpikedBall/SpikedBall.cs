using UnityEngine;

[RequireComponent(typeof(DamageZone))]
[RequireComponent (typeof(Rigidbody2D))]
public class SpikedBall : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         gameObject.SetActive(false);
    }

    public void StartFall()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
}