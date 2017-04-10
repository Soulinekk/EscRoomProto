using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLamp : InteractivElement{
    public GameObject BG;
    public Sprite bgdark;

    protected override void Start()
    {
        base.Start();
        activatingState = States.Broken;
        
    }

    protected override void FixedUpdate()
    {
        if (sequenceOn)
        {
            StartCoroutine(AnimSprites(0, avaibleSprites.Length - 1, 1f));
            actualState = States.Broken;
            BG.GetComponent<SpriteRenderer>().sprite = bgdark;
            activationCheck = true;
            sequenceOn = false;
        }
        base.FixedUpdate();
        
    }
    protected override void ChangeToDarkRoom()
    {
        
    }

}
