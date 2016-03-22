using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool autoPlay;

    private Ball ball;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        float x = Mathf.Clamp(getXMovement(), 0.75f, 15.25f);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    private float getXMovement()
    {
        return autoPlay ? ball.transform.position.x : Input.mousePosition.x / Screen.width * 16;
    }
}
