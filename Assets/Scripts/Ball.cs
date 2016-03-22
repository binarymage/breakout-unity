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
        Vector2 ballVelocity = ballBody.velocity;

        bool negX = ballVelocity.x <= 0;
        bool negY = ballVelocity.y <= 0;

        Vector2 force = new Vector2(Random.Range(-0.1f, 0.1f), negY ? -0.05f : 0.0f);

        // Ensure that we don't have a "boring loop"
        if (Mathf.Abs(ballVelocity.x) < 2)
        {
            force.x += negX ? -2 : 2;
        }
        if (Mathf.Abs(ballVelocity.y) < 5)
        {
            force.y = negY ? -10 : 10;
        }

        ballVelocity += force;
        if (Mathf.Abs(ballVelocity.x) > 8)
        {
            ballVelocity.x = 8;
        }
        if (Mathf.Abs(ballVelocity.y) > 20)
        {
            ballVelocity.y = 20;
        }

        ballBody.velocity = ballVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (started)
        {
            GameObject collider = collision.gameObject;
            if (!collider.CompareTag("Breakable") && !collider.CompareTag("Lose")) {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
