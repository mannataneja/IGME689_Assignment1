using UnityEngine;
using Esri.ArcGISMapsSDK.Components;
using Esri.GameEngine.Geometry;
using Esri.HPFramework;
using Unity.Mathematics;

public class ObjectLocation : MonoBehaviour
{
    [SerializeField] private ArcGISMapComponent arcGISMap;

    public void PrintObjectCoordinates()
    {
        double3 worldCoordinates = arcGISMap.GetComponent<HPRoot>().InverseTransformPoint(new double3(transform.position));
        ArcGISPoint coordinates = arcGISMap.View.WorldToGeographic(worldCoordinates);
        Debug.Log("3D Object Coordinates: " + coordinates.X + ", " + coordinates.Y);
    }
}
