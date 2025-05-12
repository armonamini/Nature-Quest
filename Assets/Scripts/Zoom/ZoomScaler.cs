using UnityEngine;
using Mapbox.Unity.Map;

public class ZoomScaler : MonoBehaviour
{
    public AbstractMap map;           // Assign in inspector or dynamically
    public float baseZoom = 14f;      // Zoom level at which scale is 1
    public float baseScale = 1f;      // Original scale at baseZoom
    public float scaleMultiplier = 0.5f; // How much scaling effect should apply

    private Vector3 initialLocalScale;

    void Start()
    {
        if (map == null)
        {
            map = GameObject.FindObjectOfType<AbstractMap>();
        }

        initialLocalScale = transform.localScale;
    }

    void Update()
    {
        float zoomDelta = map.Zoom - baseZoom;
        float scaleFactor = Mathf.Pow(2f, zoomDelta * scaleMultiplier);
        transform.localScale = initialLocalScale * scaleFactor;
        Debug.Log("Zoom: " + map.Zoom);
    }
}
