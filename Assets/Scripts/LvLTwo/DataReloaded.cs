using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReloaded : MonoBehaviour {

    public static bool vaultPassed = false;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
