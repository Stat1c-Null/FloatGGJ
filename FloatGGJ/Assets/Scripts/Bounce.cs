using UnityEngine;

public class Bounce : MonoBehaviour
{
    private float baseY; // The initial Y position of the object
    private float bounceAmplitude; // Current bounce height
    private float targetAmplitude; // Target bounce height
    private float bounceFrequency; // Current bounce speed
    private float targetFrequency; // Target bounce speed
    private float elapsedTime; // Keeps track of the time

    private float nextChangeTime; // Time for the next property update
    private float transitionSpeed = 1f; // How fast the transition happens

    void Start()
    {
        // Store the initial Y position of the object
        baseY = transform.position.y;

        // Set initial random amplitude and frequency
        targetAmplitude = Random.Range(0.5f, 2f);
        targetFrequency = Random.Range(1f, 5f);

        bounceAmplitude = targetAmplitude;
        bounceFrequency = targetFrequency;

        // Set the initial time for the next change
        nextChangeTime = Time.time + Random.Range(2f, 5f);
    }

    void Update()
    {
        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Smoothly interpolate amplitude and frequency towards the target values
        bounceAmplitude = Mathf.Lerp(bounceAmplitude, targetAmplitude, Time.deltaTime * transitionSpeed);
        bounceFrequency = Mathf.Lerp(bounceFrequency, targetFrequency, Time.deltaTime * transitionSpeed);

        // Calculate the new Y position using the sine function
        float newY = baseY + Mathf.Sin(elapsedTime * bounceFrequency) * bounceAmplitude;

        // Apply the new position to the object
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Check if it's time to change the target properties
        if (Time.time >= nextChangeTime)
        {
            SetRandomBounceProperties();
            nextChangeTime = Time.time + Random.Range(2f, 5f); // Random interval for the next change
        }
    }

    // Sets new random targets for amplitude and frequency
    void SetRandomBounceProperties()
    {
        targetAmplitude = Random.Range(2f, 8f); // Random target bounce height
        targetFrequency = Random.Range(1f, 5f);   // Random target bounce speed
    }
}
