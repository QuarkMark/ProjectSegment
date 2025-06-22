using UnityEngine;

public class SelfDestructIfTooLow : MonoBehaviour
{
    public float destroyYThreshold = -10f;

    void Update()
    {
        if (transform.position.y < destroyYThreshold)
        {
            Debug.Log($"{gameObject.name} fell too low and was destroyed.");
            Destroy(gameObject);
        }
    }
}
