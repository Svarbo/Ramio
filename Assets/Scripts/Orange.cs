using Players;
using UnityEngine;

public class Orange : MonoBehaviour
{
    private int reward = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            gameObject.SetActive(false);
            player.IncreaseScore(reward);
        }
    }
}