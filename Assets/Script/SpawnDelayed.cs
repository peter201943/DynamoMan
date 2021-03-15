using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns an item for a given delay
/// <see href="https://answers.unity.com/questions/205911/help-with-looping-a-coroutine-c.html">Help with looping a coroutine (c#)</see>
/// <see href="https://forum.unity.com/threads/invokerepeating-vs-coroutines-performance.497208/">InvokeRepeating VS Coroutines [Performance]</see>
/// </summary>
public class SpawnDelayed : MonoBehaviour
{
    [Tooltip("Time until an item spawns again")]
    [SerializeField]
    protected int timeDelay = 10;

    [Tooltip("Item we spawn")]
    [SerializeField]
    public GameObject item;

    [Tooltip("Are we actively spawning items?")]
    [SerializeField]
    private bool spawning = true;
    
    /// <summary>
    /// Start spawning at instantiation
    /// </summary>
    private void Start()
    {
        StartCoroutine(spawnItemContinuous(timeDelay));
    }

    /// <summary>
    /// Wait for a certain time and try spawning
    /// </summary>
    /// <param name="timeDelay">How long to wait before spawning something</param>
    /// <returns></returns>
    private IEnumerator spawnItemContinuous(int timeDelay)
    {
        while (spawning)
        {
            yield return new WaitForSecondsRealtime(timeDelay);
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
