using UnityEngine;
using Esri.ArcGISMapsSDK.Components;
using Esri.GameEngine.Geometry;

public class UpdateLocation : MonoBehaviour
{
    private ArcGISCameraComponent arcGISCamera;
    private ArcGISMapComponent arcGISMap;
    private ArcGISLocationComponent locationComponent;

    private void Awake()
    {
        arcGISMap = GetComponent<ArcGISMapComponent>();
        arcGISCamera = arcGISMap.GetComponentInChildren<ArcGISCameraComponent>();
        locationComponent = arcGISCamera.GetComponent<ArcGISLocationComponent>();
    }
    void Start()
    {
        Debug.Log(locationComponent.Position.X);
        Debug.Log(locationComponent.Position.Y);
        Invoke(nameof(MoveToNewLocation), 2);
    }

    void MoveCamera()
    {
        locationComponent.Position = new ArcGISPoint(locationComponent.Position.X + 1, locationComponent.Position.Y + 3, locationComponent.Position.Z, ArcGISSpatialReference.WGS84());
        Debug.Log(locationComponent.Position.X);
        Debug.Log(locationComponent.Position.Y);
    }
    void MoveToNewLocation()
    {
        Debug.Log("Move");
        Debug.Log(arcGISMap.OriginPosition);
        arcGISMap.OriginPosition = new ArcGISPoint(-75, 40.7128);
        Debug.Log("Moved");
        Debug.Log(arcGISMap.OriginPosition);

    }
}
