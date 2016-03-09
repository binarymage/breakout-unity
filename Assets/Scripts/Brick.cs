using UnityEngine;

public class Brick : MonoBehaviour
{
    public int maxHits;

    private int timesHit;
    private LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        timesHit = 0;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
        }
    }

    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
