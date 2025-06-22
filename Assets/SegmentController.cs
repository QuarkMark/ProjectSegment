using UnityEngine;

public class SegmentController : MonoBehaviour
{
    public KeyCode rotateLeftKey = KeyCode.Q;
    public KeyCode rotateRightKey = KeyCode.E;
    public float rotationSpeed = 100f;

    void Update()
    {
        float direction = 0f;

        if (Input.GetKey(rotateLeftKey))
            direction = -1f;
        else if (Input.GetKey(rotateRightKey))
            direction = 1f;

        transform.Rotate(0, direction * rotationSpeed * Time.deltaTime, 0);
    }
}
