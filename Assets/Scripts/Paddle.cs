using UnityEngine;

public class Paddle : MonoBehaviour {

	void Update () {
        float x = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, 0.75f, 15.25f);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
	}
}
