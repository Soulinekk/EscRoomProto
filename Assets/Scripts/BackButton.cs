﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {


    public void OnTouchUp()
    {
        Manager.Instance.DiferentBehaviourForEveryCare();
    }
}
