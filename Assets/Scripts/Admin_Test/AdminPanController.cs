using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Utils;

public class AdminPanController : MonoBehaviour
{
    [Header("Anchor & Speed")]
    [Tooltip("This empty GameObject is just a convenient stand-in for your 'virtual device'")]
    public Transform adminAnchor;
    [Tooltip("How many real-world meters each tap moves you")]
    public float panMeters = 50f;

    AbstractMap map;

    void Start()
    {
        map = FindObjectOfType<AbstractMap>();
    }

    public void PanUp()
    {
        Debug.Log("PanUp called");
        Pan(Vector3.forward);
    }

    public void PanDown()
    {
        Debug.Log("PanDown called");
        Pan(Vector3.back);
    }

    public void PanLeft()
    {
        Debug.Log("PanLeft called");
        Pan(Vector3.left);
    }

    public void PanRight()
    {
        Debug.Log("PanRight called");
        Pan(Vector3.right);
    }

    void Pan(Vector3 dir)
    {
        // 1) move the anchor in Unity world-space
        float worldUnits = panMeters * map.WorldRelativeScale;
        Debug.Log($"Moving anchor {dir} × {panMeters}m → {worldUnits} world units");
        adminAnchor.position += dir.normalized * worldUnits;

        // 2) convert that new world-position back into lat/lon
        Vector2d newLatLon = map.WorldToGeoPosition(adminAnchor.position);
        Debug.Log($"New geo center: {newLatLon.x:F6}, {newLatLon.y:F6}");

        // 3) tell Mapbox to recenter the map there
        map.UpdateMap(newLatLon, map.Zoom);
    }
}
