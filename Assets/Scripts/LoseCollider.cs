using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    public LevelManager levelManager;

    void OnTriggerEnter2D(Collider2D collider)
    {
        levelManager.LoadLevel("Win");
    }
}
