using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouchBehaviour : MonoBehaviour {

    private bool _isLerping = false;
    public float timeTakenDuringLerp;
    private float _timeStartedLerping;
    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private void Start()
    {
        _startPosition = new Vector3(0.1351565f, 0.2244104f, 01168127f);
        _endPosition = new Vector3(0.1351565f, 0.35f, 0.01168127f);
    }

    private void FixedUpdate()
    {
        if (_isLerping)
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

            transform.position = Vector3.Lerp(_startPosition, _endPosition, percentageComplete);
            //cam.orthographicSize = Mathf.Lerp(camSizeDefault, camSizeZoomed, percentageComplete);

            if (percentageComplete >= 1.0f)
            {
                _isLerping = false;
            }
        }
    }

    void OnTouchDown()
    {

    }

    void OnTouchUp()
    {

        _timeStartedLerping = Time.time;
        _isLerping = true;
    }

    void OnTouchStay()
    {

    }

    void OnTouchExit()
    {

    }
}
