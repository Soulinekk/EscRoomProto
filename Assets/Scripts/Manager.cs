using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public static Manager Instance;



    #region Lerp viarables

    private Vector3 camDefaultPosition;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Camera cam;
    private float camSizeDefault;
    private float camSizeZoomed;
    public float timeTakenDuringLerp = 1f;
    private bool _isLerping;
    private bool _isLerping_defaultPozition;
    private float _timeStartedLerping;
    #endregion

    void Start()
    {

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            DestroyImmediate(gameObject);
        }

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        camSizeDefault = cam.orthographicSize;
        camDefaultPosition = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (_isLerping)
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

            cam.transform.position = Vector3.Lerp(_startPosition, _endPosition, percentageComplete);
            cam.orthographicSize = Mathf.Lerp(camSizeDefault, camSizeZoomed, percentageComplete);

            if (percentageComplete >= 1.0f)
            {
                _isLerping = false;
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
        _startPosition = cam.transform.position;
        _endPosition = vectorToZoomTO;
        camSizeZoomed = camSize;
        _isLerping = true;
    }

    public void ReturnToDefaultScreenPosition()
    {

        _timeStartedLerping = Time.time;
        _isLerping_defaultPozition = true;
    }

    public void OnItemPickUp(int itemId)
    {

    }
}
