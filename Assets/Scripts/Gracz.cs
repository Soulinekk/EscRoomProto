using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gracz : MonoBehaviour {
   

    
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) )
            {
                InteractiveItem f = hit.collider.gameObject.GetComponent<InteractiveItem>(); 
                if (f != null)
                {
                    if (Manager.Instance.countClicksOn)
                    {
                        Manager.Instance.clickAmount--;
                        if (Manager.Instance.clickAmount == 0)
                            Manager.Instance.GameOver();
                    }
                        
                    f.OnClickBehaviour();
                }
            }
        }
    }
}
