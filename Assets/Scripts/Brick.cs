using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int breakableCount;

    public Sprite[] hitSprites;
    public AudioClip sfx;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable {
        get {
            return this.tag == "Breakable";
        }
    }


    // Use this for initialization
    void Start()
    {
        timesHit = 0;
        levelManager = FindObjectOfType<LevelManager>();
        if (isBreakable) {
            breakableCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable) {
            timesHit++;
            AudioSource.PlayClipAtPoint(sfx, transform.position);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (timesHit >= hitSprites.Length + 1)
        {
            Destroy(gameObject);
        } else
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
    }
}
