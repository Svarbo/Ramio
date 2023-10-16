using UnityEngine;

public class Collectable : MonoBehaviour
{
    private int reward = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
            player.IncreaseScore(reward);
    }
}