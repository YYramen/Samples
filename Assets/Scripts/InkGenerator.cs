using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.EventSystems;

/// <summary>
/// インク生成用のコンポーネント
/// </summary>
public class InkGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("クリック開始時のインク")] GameObject _clickInk;
    [SerializeField, Tooltip("ドラッグ中のインク")] GameObject _dragInk;
    [SerializeField, Tooltip("マウスが離れた時のインク")] GameObject _exitInk;
    [SerializeField, Tooltip("子オブジェクトにするGameObject")] Transform _parentPos;

    Ray _ray;
    RaycastHit _hit;
    float _rayDistance = 30f;

    private void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _hit, _rayDistance, LayerMask.GetMask("Paper")) == false)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
        if (Input.GetMouseButton(0))
        {
            OnDrag();
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnClickExit();
        }
    }

    private void InstantiateInk(GameObject inkPrefab)
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        var objPos = Camera.main.ScreenToWorldPoint(mousePos);

        Instantiate(inkPrefab, objPos, Quaternion.identity, _parentPos);
    }

    private void OnClick()
    {
        InstantiateInk(_clickInk);
    }

    private void OnDrag()
    {
        InstantiateInk(_dragInk);
    }

    private void OnClickExit()
    {
        InstantiateInk(_exitInk);
    }
}
