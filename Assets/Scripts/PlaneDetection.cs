using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneDetection : MonoBehaviour
{
    ARRaycastManager _raycastManager;
    [SerializeField] GameObject _sphere;

    private void Awake()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount == 0 || Input.GetTouch(0).phase != TouchPhase.Ended || _sphere == null)
        {
            return;
        }

        var hits = new List<ARRaycastHit>();
        // TrackableType.PlaneWithinPolygon���w�肷�邱�Ƃɂ���Č��o�������ʂ�Ώۂɂł���
        if (_raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            // �C���X�^���X��
            Instantiate(_sphere, hitPose.position, hitPose.rotation);
        }
    }
}