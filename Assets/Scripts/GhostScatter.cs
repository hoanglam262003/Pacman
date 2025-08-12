using UnityEngine;

public class GhostScatter : GhostBehavior
{
    private void OnDisable()
    {
        this.ghost.chase.Enable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if (node != null && this.enabled && !this.ghost.frightened.enabled && node.availableDirections.Count > 0)
        {
            this.ghost.movement.rb.position = node.transform.position;
            int index = Random.Range(0, node.availableDirections.Count);

            if (node.availableDirections[index] == -this.ghost.movement.direction && node.availableDirections.Count > 1)
            {
                index = (index + 1) % node.availableDirections.Count;
            }
            this.ghost.movement.SetDirection(node.availableDirections[index]);
        }

    }
}
