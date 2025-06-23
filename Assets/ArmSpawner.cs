using UnityEngine;

public class SegmentSpawner : MonoBehaviour
{
    public GameObject segmentPrefab;
    public GameObject spawnEffectPrefab; // Assign this in the Inspector
    public float spacing = 1.5f;
    public int maxSegments = 50;

    private Transform lastSegment;
    private int segmentCount = 0;

    void Start()
    {
        lastSegment = transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNextSegment();
        }
    }

    void SpawnNextSegment()
    {
        if (segmentCount >= maxSegments)
        {
            Debug.Log("🚫 Max segment count reached.");
            return;
        }

        GameObject newSegment = Instantiate(segmentPrefab);
        newSegment.name = "ArmSegment_" + segmentCount;
        newSegment.transform.position = lastSegment.position + Vector3.up * spacing;
        newSegment.transform.SetParent(lastSegment);

       
        Renderer rend = newSegment.GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            Material mat = new Material(rend.material);
            mat.color = Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.9f, 1f);
            rend.material = mat;

           
            Debug.Log($"✅ Spawned {newSegment.name} with color: {mat.color}");
        }
        else
        {
            Debug.Log($"✅ Spawned {newSegment.name} (no renderer found)");
        }

    
        if (spawnEffectPrefab != null)
        {
            Instantiate(spawnEffectPrefab, newSegment.transform.position, Quaternion.identity);
        }

        segmentCount++;
        lastSegment = newSegment.transform;
    }
}
