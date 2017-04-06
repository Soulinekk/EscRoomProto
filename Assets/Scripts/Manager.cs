using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public static Manager Instance;


    #region Lerp viarables
    
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Camera cam;
    private float camSizeDefault;
    private float camSizeZoomed;
    private float timeTakenDuringLerp = 1f;
    private bool _isLerping_Zoom;
    private bool _isLerping_defaultPozition;
    private float _timeStartedLerping;
    #endregion

    #region Items viarables
    
    public GameObject[] itemsSlots;
    public GameObject[] itemsByIdBigOne;
    public GameObject[] itemsByIdSmallOne;
    public GameObject[] itemsToDoStuffWith;
    public Transform itemFirstSpawnPlace;
    public float itemPickUpShowTime = 1.5f;
    [HideInInspector]
    public string actualStuffForSwitch;
    public GameObject backButton;
    public int itemActive = -1;

    #endregion

    [HideInInspector]
    public bool countClicksOn = false;
    [HideInInspector]
    public int clickAmount;
    public Text clickCountText;
    

    void Start()
    {
        #region GM Instance secure

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            DestroyImmediate(gameObject);
        }
#endregion

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        camSizeDefault = cam.orthographicSize;
        _startPosition = cam.transform.position;

        itemsSlots = new GameObject[GameObject.Find("Items_Panel").transform.childCount];
        foreach (Transform child in GameObject.Find("Items_Panel").transform)
        {

            itemsSlots[child.GetSiblingIndex()] = child.gameObject;
        }

        itemFirstSpawnPlace = GameObject.Find("Item_first_spawn_parent").transform;

        itemActive = -1;
        clickAmount = 5;
    }

    void Update()
    {

        ClickCount();
    }

    private void FixedUpdate()
    {
        if (_isLerping_Zoom)
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

            cam.transform.position = Vector3.Lerp(_startPosition, _endPosition, percentageComplete);
            cam.orthographicSize = Mathf.Lerp(camSizeDefault, camSizeZoomed, percentageComplete);

            if (percentageComplete >= 1.0f)
            {
                _isLerping_Zoom = false;
            }
        }

        if (_isLerping_defaultPozition)
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

            cam.transform.position = Vector3.Lerp(_endPosition, _startPosition, percentageComplete);
            cam.orthographicSize = Mathf.Lerp(camSizeZoomed, camSizeDefault, percentageComplete);

            if (percentageComplete >= 1.0f)
            {
                _isLerping_defaultPozition = false;
            }
        }
    }

    public void ScreenZoom(Vector3 vectorToZoomTO, float camSize, float lerpSpeed)
    {

        _timeStartedLerping = Time.time;
        timeTakenDuringLerp = lerpSpeed;
        _endPosition = vectorToZoomTO;
        camSizeZoomed = camSize;
        _isLerping_Zoom = true;
    }

    public void ReturnToDefaultScreenPosition()
    {

        _timeStartedLerping = Time.time;
        _isLerping_defaultPozition = true;
    }

    public void OnItemPickUp(int itemId, GameObject pickUpedObject)
    {

        Destroy(pickUpedObject);
        //GameObject itemPlaceHolder = Instantiate(itemsByIdBigOne[itemId], itemFirstSpawnPlace);
        //Destroy(itemPlaceHolder, itemPickUpShowTime);
        for (int i = 0; i <= itemsSlots.Length; i++)
        {
            if (!itemsSlots[i].GetComponent<ItemsBehaviour>().slotTakenOrNot)
            {
                itemsSlots[i].GetComponent<ItemsBehaviour>().itemIdInSlot = itemId;
                Instantiate(itemsByIdSmallOne[itemId], new Vector3 (itemsSlots[i].transform.position.x, itemsSlots[i].transform.position.y, itemsSlots[i].transform.position.z), Quaternion.identity, itemsSlots[i].transform);
                itemsSlots[i].GetComponent<ItemsBehaviour>().slotTakenOrNot = true;
                break;
            }
        }

    }

    public void DiferentBehaviourForEveryCare()
    {
        switch (actualStuffForSwitch)
        {
            case "door_to_close":
                ReturnToDefaultScreenPosition();
                itemsToDoStuffWith[0].SetActive(true);
                backButton.SetActive(false);
                Invoke("EnableVaultDoorCollider", 1);
                break;

            case "box_to_open":

                backButton.SetActive(false);
                itemsSlots[itemActive].GetComponent<ItemsBehaviour>().UnactiveButton();
                itemActive = -1;
                Destroy(itemFirstSpawnPlace.GetChild(0).gameObject);
                itemsToDoStuffWith[1].SetActive(false);
                break;

            default:
                Debug.Log("Error: Switch case default");
                break;
        }
    }

    void EnableVaultDoorCollider()
    {
        
        itemsToDoStuffWith[0].GetComponent<BoxCollider>().enabled = true;
    }

    public void VaultDoorInvokeMethod()
    {
        Invoke("EnableVaultDoorCollider", 0.1f);
    }

    public void GameOver()
    {
        Debug.Log("Game Over Boosted Bonobo!");
        itemsToDoStuffWith[2].SetActive(true);
        itemsToDoStuffWith[3].SetActive(true);
        itemsToDoStuffWith[4].SetActive(false);
        itemFirstSpawnPlace.gameObject.SetActive(false);
        backButton.SetActive(false);
        DestroyImmediate(this.gameObject);

    }

    void ClickCount()
    {
        clickCountText.text = clickAmount.ToString();
    }
}
