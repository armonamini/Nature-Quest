using System.Collections;
using Mapbox.Unity.Location;
using Mapbox.Utils;
using UnityEngine;

public class AdminLocationProvider : AbstractLocationProvider
{
    public double latitude = 0, longitude = 0;
    public float updateInterval = 0.1f;

    void Start()
    {
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        var wait = new WaitForSeconds(updateInterval);
        while (true)
        {
            _currentLocation.LatitudeLongitude = new Vector2d(latitude, longitude);
            _currentLocation.Timestamp = UnixTimestampUtils.To(System.DateTime.UtcNow);
            _currentLocation.IsLocationUpdated = true;
            SendLocation(_currentLocation);
            yield return wait;
        }
    }

    public void PanBy(double dLat, double dLon)
    {
        latitude += dLat;
        longitude += dLon;
    }
}
