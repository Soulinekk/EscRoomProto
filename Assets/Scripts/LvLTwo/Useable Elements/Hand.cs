using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : UseableElement
{

    protected override void Start()
    {
        objName = "hand";
        Inventory.Instance.activeElement = this;
        Inventory.Instance.AddToInventory(this);
        base.Start();
        
    }

}
