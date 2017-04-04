using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultBehaviour : MonoBehaviour {

    private Vector3 vectorToZoomTo = new Vector3(0.44f, 0.96f, 0.5f);
    private float camSize = 0.17f;
    private float timeLerp = 0.5f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OpenVault()
    {

        Manager.Instance.ScreenZoom(vectorToZoomTo, camSize, timeLerp);
    }

    public void ExitVault()
    {

        Manager.Instance.ReturnToDefaultScreenPosition();
    }
}