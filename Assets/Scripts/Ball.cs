using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private Vector3 positionOffset;
    private bool started;

    // Use this for initialization
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        positionOffset = transform.position - paddle.transform.position;
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            transform.position = paddle.transform.position + positionOffset;

            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(2.0f, 10.0f);
                started = true;
            }
        }
    }
}
