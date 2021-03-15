using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns an item for a given delay
/// <see href="https://answers.unity.com/questions/205911/help-with-looping-a-coroutine-c.html">Help with looping a coroutine (c#)</see>
/// <see href="https://forum.unity.com/threads/invokerepeating-vs-coroutines-performance.497208/">InvokeRepeating VS Coroutines [Performance]</see>
/// <see href="https://gamedev.stackexchange.com/questions/114264/whats-the-difference-between-unityengine-random-and-system-random">What's the difference between UnityEngine.Random and System.Random?</see>
/// </summary>
public class SpawnDelayed : MonoBehaviour
{
    [Tooltip("Time until an item spawns again")]
    [SerializeField]
    private int timeDelay = 10;

    [Tooltip("Item we spawn")]
    [SerializeField]
    private GameObject item;

    [Tooltip("Are we actively spawning items?")]
    [SerializeField]
    private bool spawning = true;

    [Tooltip("Degree of variation in spawn times")]
    [SerializeField]
    private int timeVariance = 3;
    private int timeVarianceMin;
    private int timeVarianceMax;

    /// <summary>
    /// Get the Variance
    /// Start spawning at instantiation
    /// </summary>
    private void Start()
    {
        timeVarianceMin = -timeVariance / 2;
        timeVarianceMax =  timeVariance / 2;

        StartCoroutine(spawnItemContinuous(timeDelay));
    }

    /// <summary>
    /// Wait for a certain time and try spawning
    /// Will add some variation
    /// </summary>
    /// <param name="timeDelay">How long to wait before spawning something</param>
    /// <returns></returns>
    private IEnumerator spawnItemContinuous(int timeDelay)
    {
        while (spawning)
        {
            yield return new WaitForSecondsRealtime(
                timeDelay + Random.Range(min: timeVarianceMin, max: timeVarianceMax)
            );
            spawnItem();
        }
    }

    /// <summary>
    /// Only add items if there are none at the location
    /// Use our own location for spawning
    /// </summary>
    private void spawnItem()
    {
        if (transform.childCount == 0)
        {
            Instantiate(item, transform);
        }
    }
}
