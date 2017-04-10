using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour, IPointerClickHandler{

    public GameObject gmObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(0);
        DestroyImmediate(gmObject);
    }
}
