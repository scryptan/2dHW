using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.TryGetComponent<Player>(out var player))
            player.TakeCoin(this);
    }
}
