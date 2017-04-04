using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public static Manager Instalnce;

    private Transform camDefaultPosition;
    private float CamDefaultFOW;

	void Start () {
        camDefaultPosition = this.transform;
        CamDefaultFOW = this.GetComponent<Camera>().fieldOfView;
	}
	
	void Update () {
		
	}

    public void ScreenZoom(float cameraFOW, Transform transformToZoomTO)
    {

    }

    public void OnItemPickUp(int itemId)
    {

    }


}
