using UnityEngine;
using Mapbox.Unity.Map;

public class MapZoomController : MonoBehaviour
{
    [Header("Map Reference")]
    public AbstractMap map;

    [Header("Zoom Settings")]
    public float minZoom = 14f;
    public float maxZoom = 15f;
    public float zoomStep = 0.5f;

    // Called by the "+" button
    public void ZoomInButton()
    {
        Zoom(zoomStep);
    }

    // Called by the "–" button
    public void ZoomOutButton()
    {
        Zoom(-zoomStep);
    }

    // Core zoom logic with bounds
    private void Zoom(float delta)
    {
        float newZoom = Mathf.Clamp(map.Zoom + delta, minZoom, maxZoom);
        map.UpdateMap(map.CenterLatitudeLongitude, newZoom);
    }
}
