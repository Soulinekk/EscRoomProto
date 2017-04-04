using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gracz : MonoBehaviour {

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                InteractiveItem f = hit.collider.gameObject.GetComponent<InteractiveItem>();  //thats bad :D
                if (f != null)
                {
                    f.OnClickBehaviour();
                }
            }
        }
    }
}
