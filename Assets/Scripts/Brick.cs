using UnityEngine;

public class Brick : MonoBehaviour
{
	public static int breakableCount = 0;

    public Sprite[] hitSprites;

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
			print(breakableCount);
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
		}
    }

    void OnCollisionExit2D(Collision2D collision)
    {
		if (!isBreakable) {
			return;
		}

        if (timesHit >= hitSprites.Length + 1)
        {
            Destroy(gameObject);
			breakableCount--;
			print(breakableCount);
			levelManager.BrickDestroyed();
        } else
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
    }

    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
