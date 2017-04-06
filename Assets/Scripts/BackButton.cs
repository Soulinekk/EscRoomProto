using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {


    public void OnTouchUp()
    {
        Manager.Instance.DiferentBehaviourForEveryCare();

        if (Manager.Instance.countClicksOn)
        {
            Manager.Instance.clickAmount--;
            if (Manager.Instance.clickAmount == 0)
                Manager.Instance.GameOver();
        }
    }
}
