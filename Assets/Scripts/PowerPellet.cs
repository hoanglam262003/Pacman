using UnityEngine;

public class PowerPellet : Pellet
{
    public float duration = 8f;

    protected override void Eat()
    {
        var gameManager = FindAnyObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.PowerPelletEaten(this);
        }
    }
}
