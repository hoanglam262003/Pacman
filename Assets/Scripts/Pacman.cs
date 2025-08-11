using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour
{
    public Movement movement { get; private set; }

    public void Awake()
    {
        this.movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            movement.SetDirection(Vector2.up);
        }
        else if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            movement.SetDirection(Vector2.left);
        }
        else if (Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            movement.SetDirection(Vector2.down);
        }
        else if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            movement.SetDirection(Vector2.right);
        }

        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();
    }
}
