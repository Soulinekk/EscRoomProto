using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLamp : InteractivElement{
    protected override void Start()
    {
        base.Start();
        activatingState = States.Broken;
        activationCheck = true;
    }

    protected override void FixedUpdate()
    {
        if (sequenceOn)
        {
            StartCoroutine(AnimSprites(0, avaibleSprites.Length - 1, 1f));
            actualState = States.Broken;
            sequenceOn = false;
        }
        base.FixedUpdate();
        
    }

}
