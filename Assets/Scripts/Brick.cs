using UnityEngine;

public class Brick : MonoBehaviour
{
    public int maxHits;
    public Sprite[] hitSprites;

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
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (timesHit >= hitSprites.Length + 1)
        {
            Destroy(gameObject);
        } else
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit-1];
        }
    }

    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
