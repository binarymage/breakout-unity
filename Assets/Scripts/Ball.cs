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

    void OnCollisionExit2D(Collision2D collision)
    {
        Rigidbody2D ballBody = GetComponent<Rigidbody2D>();

        if (Mathf.Abs(ballBody.velocity.y) < 0.3f)
        {
            // If the velocity is truly horizontal, then add a small downward
            // force to get the ball rolling again
            bool negative = ballBody.velocity.y <= 0;

            ballBody.AddForce(new Vector2(0, negative ? -0.5f : 0.5f));
        }
    }
}
