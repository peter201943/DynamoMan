using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainPlayer : Brain
{
    private bool alive;

    private void Start()
    {
        alive = true;
    }

    private void Update()
    {

    }

    public void Spawn()
    {
        alive = true;
    }

    public void Die()
    {
        alive = false;
    }

    public void Respawn()
    {
        Spawn();
    }
}
