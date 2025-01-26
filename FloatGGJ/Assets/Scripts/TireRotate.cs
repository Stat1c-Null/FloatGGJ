using UnityEngine;

public class TireRotation : MonoBehaviour
{
    // The rotations per second to apply to the tire
    public float rotationsPerSecond = 1.0f;
    public bool isEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            // Calculate the angle to rotate this frame based on the RPS
            float angle = rotationsPerSecond * 360f * Time.deltaTime;

            // Apply the rotation around the local X axis (adjust axis if needed)
            //transform.Rotate(angle, 0, 0, Space.World);
            transform.Rotate(new Vector3(-1, 0, 0), angle);
        }
    }
}