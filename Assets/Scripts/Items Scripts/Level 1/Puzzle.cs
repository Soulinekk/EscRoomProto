using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour {

    public GameObject keyHole;
    public GameObject keySprite;
    public Material ledDiode;
    private int code;
    public Text codeText;
    public bool codeCorrect;
    public bool keyPlaced = false;

    private void Start()
    {
        code = -1;
    }

    public void ButtonBehaviour(int id)
    {
        if (code != -1)
        {
            if (code < 999999999)
            {
                code = code * 10;
                code = code + id + 1;
                DisplayCodeText();
                if(code == 2413)
                {
                    codeCorrect = true;
                    OnCorrectCode();
                }
                else
                {
                    codeCorrect = false;
                    OnCorrectCode();
                }
            }
            else
            {
                DisplayCodeText();
                Debug.Log("*Beep sound* limit of numbers in code.");
            }
        }
        else
        {
            code = id + 1;
            DisplayCodeText();
        }
    }

    public void ResetButton()
    {
        code = -1;
        DisplayCodeText(); 
        codeCorrect = false;
        OnCorrectCode();
    }

    public void Key_OpenBox()
    {
        if (Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.childCount != 0
            && Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.GetChild(0).name == "lvl1_KeySmall(Clone)"
            && Manager.Instance.itemFirstSpawnPlace.childCount == 0)
        {
            Manager.Instance.itemPlaceholder.transform.GetChild(2).gameObject.SetActive(true);
            keyPlaced = true;
        }

        if (codeCorrect && keyPlaced)
        {
            Manager.Instance.itemPlaceholder.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            Manager.Instance.itemPlaceholder.transform.GetChild(2).gameObject.SetActive(false);
            Manager.Instance.itemsToDoStuffWith[8].SetActive(false);
            Manager.Instance.itemsToDoStuffWith[9].SetActive(true);
        }
        else
        {
            Debug.Log("*beep sound* Puzzle not solved, Your mere existance cant open this box");
        }
    }

    public void OnKeyPickUp()
    {
        Manager.Instance.OnItemPickUp(3, Manager.Instance.itemPlaceholder.transform.GetChild(1).transform.GetChild(1).gameObject);
    }

    private void DisplayCodeText()
    {
        if(code != -1)
            codeText.text = code.ToString();
        else
            codeText.text = "";
    }

    private void OnCorrectCode()
    {
        if (codeCorrect == false)
            Manager.Instance.itemPlaceholder.transform.GetChild(0).transform.GetChild(5).GetComponent<Renderer>().material.color = Color.red;
        else
            Manager.Instance.itemPlaceholder.transform.GetChild(0).transform.GetChild(5).GetComponent<Renderer>().material.color = Color.green;
    }
}
