using UnityEngine;
using Esri.ArcGISMapsSDK.Components;
using Esri.GameEngine.Geometry;

public class UpdateLocation : MonoBehaviour
{
    private ArcGISCameraComponent arcGISCamera;
    private ArcGISMapComponent arcGISMap;
    private ArcGISLocationComponent cameraLocationComponent;

    private void Awake()
    {
        arcGISMap = GetComponent<ArcGISMapComponent>();
        arcGISCamera = arcGISMap.GetComponentInChildren<ArcGISCameraComponent>();
        cameraLocationComponent = arcGISCamera.GetComponent<ArcGISLocationComponent>();
    }
    void Start()
    {
        Debug.Log(cameraLocationComponent.Position.X);
        Debug.Log(cameraLocationComponent.Position.Y);
        Invoke(nameof(MoveToBoston), 5);
    }

    void MoveCamera()
    {
        cameraLocationComponent.Position = new ArcGISPoint(cameraLocationComponent.Position.X + 1, cameraLocationComponent.Position.Y + 3, cameraLocationComponent.Position.Z, ArcGISSpatialReference.WGS84());
        Debug.Log(cameraLocationComponent.Position.X);
        Debug.Log(cameraLocationComponent.Position.Y);
    }
    void MoveToBoston()
    {
        cameraLocationComponent.Position = new ArcGISPoint(-71.0565, 42.3555, cameraLocationComponent.Position.Z, ArcGISSpatialReference.WGS84());

    }
}
