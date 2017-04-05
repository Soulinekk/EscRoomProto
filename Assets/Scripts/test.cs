using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    void OnTouchDown()
    {
        Debug.Log("on touch down");
    }

    void OnTouchUp()
    {
        Debug.Log("on touch up");
    }

    void OnTouchStay()
    {
        Debug.Log("on touch Stay");
    }

    void OnTouchExit()
    {
        Debug.Log("on touch exit");
    }
}
