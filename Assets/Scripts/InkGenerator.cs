using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.EventSystems;

/// <summary>
/// �C���N�����p�̃R���|�[�l���g
/// </summary>
public class InkGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("�N���b�N�J�n���̃C���N")] GameObject _clickInk;
    [SerializeField, Tooltip("�h���b�O���̃C���N")] GameObject _dragInk;
    [SerializeField, Tooltip("�}�E�X�����ꂽ���̃C���N")] GameObject _exitInk;
    [SerializeField, Tooltip("�q�I�u�W�F�N�g�ɂ���GameObject")] Transform _parentPos;

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
