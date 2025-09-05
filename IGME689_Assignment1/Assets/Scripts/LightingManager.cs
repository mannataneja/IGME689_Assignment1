using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;

    [Header("Use actual time of day or simulated time")]
    [SerializeField] bool useActualTime;
    [SerializeField, Range(0, 24)] private float SimulatedTimeOfDay;

    void Update()
    {
        if(Preset == null) return;

        if (!useActualTime)
        {
            if (Application.isPlaying)
            {
                SimulatedTimeOfDay += Time.deltaTime;
                SimulatedTimeOfDay %= 24;
                UpdateLighting(SimulatedTimeOfDay / 24f);
            }
            else
            {
                UpdateLighting(SimulatedTimeOfDay / 24f);

            }
        }
        else
        {
            UpdateLighting(System.DateTime.Now.Hour / 24f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if(DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }
}
