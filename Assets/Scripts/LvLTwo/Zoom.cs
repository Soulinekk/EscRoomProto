using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {
    public GameObject[] areaObjects;
    public Camera mainCam;
    private Vector3 startPos;
    public Vector3 endPos;
    private float startSize;
    public float endSize;


	// Use this for initialization
	void Start () {
		foreach(GameObject obj in areaObjects)
        {
            obj.GetComponent<Collider2D>().enabled = !obj.GetComponent<Collider2D>().enabled;
            startPos = mainCam.transform.position;
            startSize = mainCam.orthographicSize;
        }
	}
	
	public void ZoomIn()
    {
        Debug.Log("zooming in");

        //cam shift
        mainCam.orthographicSize = endSize;
        mainCam.transform.position = endPos;
       // StartCoroutine(ZoomPos(endPos,endSize));
        //StartCoroutine(ZoomSize(endSize));
        
        gameObject.GetComponent<Collider2D>().enabled= !gameObject.GetComponent<Collider2D>().enabled;
        foreach (GameObject obj in areaObjects)
        {
            obj.GetComponent<Collider2D>().enabled = !obj.GetComponent<Collider2D>().enabled;
        }
        //cam shift ;
    }
    public void ZoomOut()
    {
        Debug.Log("zooming out");

        // cam shift

        gameObject.GetComponent<Collider2D>().enabled = !gameObject.GetComponent<Collider2D>().enabled;
        foreach (GameObject obj in areaObjects)
        {
            obj.GetComponent<Collider2D>().enabled = !obj.GetComponent<Collider2D>().enabled;
        }
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
