using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Singleton<Inventory> {

    protected Inventory() { }
    List<UseableElement> inventory;
    public Button[] invButtons;
    [HideInInspector]
    public UseableElement activeElement;
    public Sprite noItem;
    


    void Awake()
    {
        ///DontDestroyOnLoad(this);
        inventory = new List<UseableElement>();
        invButtons[0].onClick.AddListener(() => { this.SetActiveElement(0); });
        invButtons[1].onClick.AddListener(() => { this.SetActiveElement(1); });
        invButtons[2].onClick.AddListener(() => { this.SetActiveElement(2); });
        invButtons[3].onClick.AddListener(() => { this.SetActiveElement(3); });
        invButtons[4].onClick.AddListener(() => { this.SetActiveElement(4); });
        invButtons[5].onClick.AddListener(() => { this.SetActiveElement(5); });

    }

    public void AddToInventory(UseableElement item)
    { 
        inventory.Add(item);
        //invButtons[inventory.Count-1].GetComponentInChildren<Image>();


        invButtons[inventory.Count - 1].GetComponentInChildren<Image>().sprite = item.icon;
        
        invButtons[inventory.Count - 1].interactable = true;
        if (item.objName != "hand")
        {
            item.gameObject.GetComponent<Collider2D>().enabled = false;
            item.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
    public void SetActiveElement(int i)
    {
        //Debug.Log(i);
        if (i < 6)
        {
                activeElement = inventory[i];
            if (i != 0)
                invButtons[0].GetComponentInChildren<Image>().sprite = invButtons[i].GetComponentInChildren<Image>().sprite;
            else
                invButtons[0].GetComponentInChildren<Image>().sprite = noItem;

            if(i!=0)
                Feedback.Instance.ShowText(activeElement.name, 0.5f,true);
            //Debug.Log(activeElement.objName);
        }
    }
    public void RemoveFromInventory(UseableElement item)
    {
        
        //invButtons[inventory.IndexOf(item)].GetComponentInChildren<Image>().sprite = null;
       // invButtons[inventory.IndexOf(item)].interactable = false;
        inventory.Remove(item);
        UpdateButtons();
        SetActiveElement(0);
    }
    private void UpdateButtons()
    {
        for(int i=1; i<inventory.Count;i++)
        {
            invButtons[i].GetComponentInChildren<Image>().sprite = inventory[i].icon;
            //invButtons[inventory.Count - 1].interactable = true;
        }
        for(int i= inventory.Count;i<invButtons.Length; i++)
        {
            invButtons[i].image.sprite = noItem;
            invButtons[i].interactable = false;
        }
    }
}
