using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureFrame : MonoBehaviour {

    private bool tilted = false;
    private Vector3 _defaultTransform = new Vector3(-0.356f, 0.124f, 1.59f);
    private Vector3 _endTransform = new Vector3(-0.481f, 0.186f, 1.59f);
    private Vector3 _defaultRotation = new Vector3(-270, 180, 0);
    private Vector3 _endRotation = new Vector3(-320.943f, 266.604f, 90f);

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTouchDown()
    {
        
    }

    void OnTouchUp()
    {
        if (Manager.Instance.countClicksOn)
        {
            Manager.Instance.clickAmount--;
            if (Manager.Instance.clickAmount == 0)
                Manager.Instance.GameOver();
        }

        if (tilted)
        {
            this.gameObject.transform.localPosition = _defaultTransform;
            this.gameObject.transform.localEulerAngles = _defaultRotation;
            Manager.Instance.clickCountText.gameObject.SetActive(false);
            tilted = false;
        }
        else
        {
            this.gameObject.transform.localPosition = _endTransform;
            this.gameObject.transform.localEulerAngles = _endRotation;
            Manager.Instance.clickCountText.gameObject.SetActive(true);
            tilted = true;
        }
    }

    void OnTouchStay()
    {

    }

    void OnTouchExit()
    {

    }
}
