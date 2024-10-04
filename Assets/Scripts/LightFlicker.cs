using UnityEngine;

// Written by Steve Streeting 2017
// License: CC0 Public Domain http://creativecommons.org/publicdomain/zero/1.0/

/// <summary>
/// Component which will flicker a linked light while active by changing its
/// intensity between the min and max values given. The flickering can be
/// sharp or smoothed depending on the value of the smoothing parameter.
///
/// Just activate / deactivate this component as usual to pause / resume flicker
/// </summary>
public class LightFlickerEffect : MonoBehaviour
{
  [Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
  public new Light light;
  [Tooltip("Minimum random light intensity")]
  public float minIntensity = 0f;
  [Tooltip("Maximum random light intensity")]
  public float maxIntensity = 1f;
  [Tooltip("Minimum random light range")]
  public float minRange = 0f;
  [Tooltip("Maximum random light range")]
  public float maxRange = 1f;
  [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
  [Range(1, 50)]
  public int smoothing = 5;

  SmoothQueue intensityQueue;
  SmoothQueue rangeQueue;

  void Start()
  {
    intensityQueue = new SmoothQueue(smoothing);
    rangeQueue = new SmoothQueue(smoothing);
    // External or internal light?
    if (light == null)
    {
      light = GetComponent<Light>();
    }
  }

  void Update()
  {
    if (light == null)
      return;

    light.intensity = intensityQueue.Enqueue(Random.Range(minIntensity, maxIntensity));
    light.range = rangeQueue.Enqueue(Random.Range(minRange, maxRange));
  }

}