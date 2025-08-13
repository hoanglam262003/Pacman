using UnityEngine;

public class GhostChase : GhostBehavior
{
    private void OnDisable()
    {
        this.ghost.scatter.Enable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();
        if (node != null && this.enabled && !this.ghost.frightened.enabled && node.availableDirections.Count > 0)
        {
            this.ghost.movement.rb.position = node.transform.position;
            Vector2 bestDirection = node.availableDirections[0];
            float minDistance = float.MaxValue;

            foreach (Vector2 availableDirection in node.availableDirections)
            {
                if (availableDirection == -this.ghost.movement.direction && node.availableDirections.Count > 1)
                    continue;

                Vector3 targetPosition = this.transform.position + (Vector3)availableDirection;
                float distance = (this.ghost.target.position - targetPosition).sqrMagnitude;
                if (distance < minDistance)
                {
                    bestDirection = availableDirection;
                    minDistance = distance;
                }
            }
            this.ghost.movement.SetDirection(bestDirection);
        }
    }
}
