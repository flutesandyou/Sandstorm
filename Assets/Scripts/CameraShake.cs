using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float positionShakeMagnitude = 0.1f; // Intensity of the positional shake
    public float rotationShakeMagnitude = 0.1f; // Intensity of the rotational shake
    public float frequency = 1.0f; // Frequency of the sine wave

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float elapsedTime;

    void OnEnable()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
        elapsedTime = 0f;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Sinusoidal shake for position
        float xShake = Mathf.Sin(elapsedTime * frequency) * positionShakeMagnitude;
        float yShake = Mathf.Sin(elapsedTime * frequency * 1.2f) * positionShakeMagnitude; // Slightly different frequency for variation
        float zShake = Mathf.Sin(elapsedTime * frequency * 0.8f) * positionShakeMagnitude; // Slightly different frequency for variation

        transform.localPosition = initialPosition + new Vector3(xShake, yShake, zShake);

        // Sinusoidal shake for rotation
        float xRotShake = Mathf.Sin(elapsedTime * frequency * 1.1f) * rotationShakeMagnitude;
        float yRotShake = Mathf.Sin(elapsedTime * frequency * 1.3f) * rotationShakeMagnitude;
        float zRotShake = Mathf.Sin(elapsedTime * frequency * 0.9f) * rotationShakeMagnitude;

        transform.localRotation = initialRotation * Quaternion.Euler(xRotShake, yRotShake, zRotShake);
    }
}
