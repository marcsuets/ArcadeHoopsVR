using UnityEngine;

// A LED node emitting light based on start/stop signals from the previous node in the chain.

public class LEDNode : MonoBehaviour
{
    // Previous linked LED node.
    public LEDNode prevNode = null;
    // Start/stop signals for the next linked LED node.
    public bool nextStart { get; private set; } = false;

    // Mark in GUI if first node in the chain.
    public bool isFirstNode = false;
    // Point light enable control.
    public bool isPointLightEn = false;
    // Slow light progress indicator.
    public bool slowProgress = false;

    // Attached components.
    private Light pointLight = null;
    private Renderer rend = null;

    // Emitted light intensity parameters.
    private float intensity = 10.0f; // Fixed intensity for constant light
    private float minIntensity = 0;
    private float maxIntensity = 20.0f; // max intensity is unused now
    private float onTime = 0;
    private float maxOnTime = 1.0f; // max on time is also unused
    private float onTimerSpeed = 5.0f; // this is not necessary anymore
    private float offTime = 0;
    private float maxOffTime = 20.0f; // max off time is also unused
    private float offTimerSpeed = 20.0f; // this is not necessary anymore

    // Emitted light increase/decrease controls.
    private enum LightState { INCR, DECR, IDLE }
    private LightState lightState = LightState.IDLE;

    void Start()
    {
        // Init the attached components.
        pointLight = this.GetComponent<Light>();
        rend = GetComponent<Renderer>();

        // Ensure the point light is enabled if desired
        if (isPointLightEn)
        {
            pointLight.enabled = true;  // Make sure the light is ON from the start
        }

        // Set the intensity to a constant value (maximum)
        intensity = maxIntensity;

        // Make sure the material color is updated to reflect the intensity immediately
        UpdateColor();
    }

    void Update()
    {
        // No need to resolve state since we want the light to remain constant and always on
        UpdateColor();
    }

    // Update color for constant phosphorescent light
    private void UpdateColor()
    {
        Material mat = rend.material;

        // Set a bright neon green color for the phosphorescent effect
        Color finalColor = new Color(0.0f, 1.0f, 0.0f) * Mathf.LinearToGammaSpace(intensity);
        mat.SetColor("_EmissionColor", finalColor);

        // Ensure the point light is using the same color
        if (pointLight != null && pointLight.enabled)
        {
            pointLight.color = new Color(0.0f, 1.0f, 0.0f); // Neon green
        }
    }
}
