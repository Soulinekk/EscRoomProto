﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour {
    public GameObject[] areaObjects;
    public GameObject backButton;
    public Camera mainCam;
    private Vector3 startPos;
    public Vector3 endPos;
    private float startSize;
    public float endSize;
    public bool areaSwitch = false;
    

	// Use this for initialization
	void Start () {
        /*foreach(GameObject obj in areaObjects)
        {
            obj.GetComponent<Collider2D>().enabled = !obj.GetComponent<Collider2D>().enabled;
            
        }*/
        
        if(!areaSwitch)
            backButton.SetActive(false);
	}
	
	public void ZoomIn()
    {
        if (!this.areaSwitch)
        {
            Debug.Log("zooming in");
            startPos = mainCam.transform.position;
            startSize = mainCam.orthographicSize;
            //cam shift
            mainCam.orthographicSize = endSize;
            mainCam.transform.position = endPos;
            // StartCoroutine(ZoomPos(endPos,endSize));
            //StartCoroutine(ZoomSize(endSize));

            gameObject.GetComponent<Collider2D>().enabled = false;
            foreach (GameObject obj in areaObjects)
            {
                if (obj.active)
                    obj.GetComponent<Collider2D>().enabled = !obj.GetComponent<Collider2D>().enabled;
            }
            backButton.GetComponent<Button>().onClick.AddListener(() => { this.ZoomOut(); });
            backButton.SetActive(true);
            //cam shift ;
        }
        else
        {
            mainCam.transform.position = endPos;
            startPos = endPos;
            //startSize = mainCam.orthographicSize;
        }
    }
    public void ZoomOut()
    {
        Debug.Log("zooming out");

        // cam shift
        mainCam.orthographicSize = startSize;
        mainCam.transform.position = startPos;

        gameObject.GetComponent<Collider2D>().enabled = true;
        foreach (GameObject obj in areaObjects)
        {
            if (obj.active)
                obj.GetComponent<Collider2D>().enabled = !obj.GetComponent<Collider2D>().enabled;
        }
        backButton.GetComponent<Button>().onClick.RemoveAllListeners();
        backButton.SetActive(false);
    }

    private IEnumerator ZoomPos(Vector3 endV3,float endF)
    {
        
        while(mainCam.transform.position!=endV3 || mainCam.orthographicSize > endF)
        {
            mainCam.orthographicSize = Mathf.MoveTowards(mainCam.orthographicSize, endF,  Time.deltaTime);
            yield return null;
            mainCam.transform.position = Vector3.MoveTowards(mainCam.transform.position, endV3, Time.deltaTime);
            yield return null;
           
        }

        yield return null;
    }

   
   /* private IEnumerator ZoomSize(float end)
    {

        while (mainCam.orthographicSize > end)
        {
            
        }

        yield return null;
    }*/

}
