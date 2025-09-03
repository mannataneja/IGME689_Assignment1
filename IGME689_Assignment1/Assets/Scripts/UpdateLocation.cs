using UnityEngine;
using Esri.ArcGISMapsSDK.Components;
using Esri.GameEngine.Geometry;

public class UpdateLocation : MonoBehaviour
{
    public ArcGISMapComponent arcGISMap;
    public ArcGISCameraComponent arcGISCamera;
    public ArcGISLocationComponent cameraLocationComponent;

    private void Awake()
    {
        //arcGISMap = GetComponent<ArcGISMapComponent>();
        //arcGISCamera = arcGISMap.GetComponentInChildren<ArcGISCameraComponent>();
        cameraLocationComponent = arcGISCamera.GetComponent<ArcGISLocationComponent>();
    }
    void Start()
    {
        Debug.Log(cameraLocationComponent.Position.X);
        Debug.Log(cameraLocationComponent.Position.Y);
        Debug.Log(arcGISMap.OriginPosition.X);
        Debug.Log(arcGISMap.OriginPosition.Y);

        //Invoke(nameof(MoveToBoston), 5);
    }

    void MoveCamera()
    {
        cameraLocationComponent.Position = new ArcGISPoint(cameraLocationComponent.Position.X + 1, cameraLocationComponent.Position.Y + 3, cameraLocationComponent.Position.Z, ArcGISSpatialReference.WGS84());
        Debug.Log(cameraLocationComponent.Position.X);
        Debug.Log(cameraLocationComponent.Position.Y);
    }
    public void MoveToBoston()
    {
        arcGISMap.OriginPosition = new ArcGISPoint(-71.0565, 42.3555, arcGISMap.OriginPosition.Z, ArcGISSpatialReference.WGS84()); 
        cameraLocationComponent.Position = new ArcGISPoint(-71.0565, 42.3555, cameraLocationComponent.Position.Z, ArcGISSpatialReference.WGS84());

    }
    public void MoveToSanFrancisco()
    {
        arcGISMap.OriginPosition = new ArcGISPoint(-122.4194, 37.7749, arcGISMap.OriginPosition.Z, ArcGISSpatialReference.WGS84());
        cameraLocationComponent.Position = new ArcGISPoint(-122.4194, 37.7749, cameraLocationComponent.Position.Z, ArcGISSpatialReference.WGS84());

    }
    public void MoveToNewYork()
    {
        arcGISMap.OriginPosition = new ArcGISPoint(-74.10572, 40.71209, arcGISMap.OriginPosition.Z, ArcGISSpatialReference.WGS84());
        cameraLocationComponent.Position = new ArcGISPoint(-74.10572, 40.71209, cameraLocationComponent.Position.Z, ArcGISSpatialReference.WGS84());

    }
}
