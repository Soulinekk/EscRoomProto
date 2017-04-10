using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : InteractivElement {
    protected override void Start()
    {
        base.Start();
        activatingState = States.Broken;
        sequenceSlowerer = 2;
    }

}
