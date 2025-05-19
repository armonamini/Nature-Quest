using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Unity.VisualScripting;

public class Pinch : MonoBehaviour
{

    [Header("Map Reference")]
    [Tooltip("Drag your AbstractMap here")]
    [SerializeField] private AbstractMap map;

    [Header("Zoom Settings")]
    [Tooltip("How fast the zoom responds to pinch")]
    [SerializeField] private float zoomSpeed = 0.01f;

    [Tooltip("Minimum map zoom level")]
    [SerializeField] private float minZoom = 1f;

    [Tooltip("Maximum map zoom level")]
    [SerializeField] private float maxZoom = 20f;


    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f)
        {
            float z = Mathf.Clamp(map.Zoom + scroll * (zoomSpeed * 10), minZoom, maxZoom);
            map.UpdateMap(map.CenterLatitudeLongitude, z);
        }
#else
        if(Input.touchCount == 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            // previous position of each touch
            Vector2 t0Prev = t0.position - t0.deltaPosition;
            Vector2 t1Prev = t1.position - t1.deltaPosition;

            // Compute previous and current distances between touches
            float prevDistance = Vector2.Distance(t0Prev, t1Prev);
            float currentDistance = Vector2.Distance(t0.position, t1.position);

            // Delta is how much the pinch changed this frame
            float delta = currentDistance - prevDistance;

            // Calcuate new zoom, then clamp 
            float newZoom = Mathf.Clamp(map.Zoom + delta * zoomSpeed, minZoom, maxZoom);

            // Apply it 
            map.UpdateMap(map.CenterLatitudeLongitude, newZoom);
        }
#endif

    }
}
