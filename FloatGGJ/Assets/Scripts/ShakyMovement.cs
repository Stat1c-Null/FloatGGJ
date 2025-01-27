using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakyMovement : MonoBehaviour
{
    public float shakeDuration = 0.5f; // Duration of the shake
    public float shakeIntensity = 0.5f; // How far it shakes to the left and right
    public float shakeSpeed = 50f; // How quickly it shakes

    private Vector3 originalPosition; // Store the object's original position
    private bool isShaking = false; // Check if the object is currently shaking

    public void StartShaking()
    {
        if (!isShaking)
        {
            originalPosition = transform.localPosition;
            StartCoroutine(Shake());
        }
    }

    public void StopShaking()
    {
        isShaking = false; // Stop shaking
        transform.localPosition = originalPosition; // Reset position
    }

    private System.Collections.IEnumerator Shake()
    {
        isShaking = true;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;

            // Calculate a random offset for the shake effect
            float offsetX = Mathf.Sin(Time.time * shakeSpeed) * shakeIntensity;

            // Apply the offset to the object's position
            transform.localPosition = originalPosition + new Vector3(0, offsetX, 0);

            yield return null; // Wait until the next frame
        }

        // Reset position after shaking
        transform.localPosition = originalPosition;
        isShaking = false;
    }
}
