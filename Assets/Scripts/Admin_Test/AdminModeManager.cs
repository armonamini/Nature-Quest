using UnityEngine;
using UnityEngine.UI;         // ← for Toggle
using Mapbox.Unity.Map;

public class AdminModeManager : MonoBehaviour
{
    [Header("UI")]
    [Tooltip("The actual Toggle in your Canvas")]
    public Toggle adminToggle;

    [Header("Providers")]
    public GameObject gpsProvider;
    public GameObject transformProvider;

    [Header("Anchor")]
    public Transform adminAnchor;

    AbstractMap map;

    void Awake()
    {
        map = FindObjectOfType<AbstractMap>();
        // subscribe to the real onValueChanged event
        adminToggle.onValueChanged.AddListener(ToggleAdmin);
        // start in GPS mode
        adminToggle.isOn = false;
    }

    void ToggleAdmin(bool isAdmin)
    {
        Debug.Log($"ToggleAdmin called, isAdmin = {isAdmin}");
        gpsProvider.SetActive(!isAdmin);
        transformProvider.SetActive(isAdmin);
        if (isAdmin)
        {
            var center = map.CenterLatitudeLongitude;
            adminAnchor.position = map.GeoToWorldPosition(center, true);
        }
    }
}
