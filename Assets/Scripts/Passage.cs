using UnityEngine;

public class Passage : MonoBehaviour
{
    public Transform connection;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 direction = collision.transform.position;
        direction.x = this.connection.position.x;
        direction.y = this.connection.position.y;
        collision.transform.position = direction;
    }
}
