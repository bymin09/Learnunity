using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour,
    IPointerDownHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public Transform parentTr;
    public Transform parentStart;

    private Vector2 beginPoint;
    private Vector2 moveBegin;
    private Transform beginParent;
    CanvasGroup canvasGroup;

    void Awake()
    {
        if(parentTr == null)
        {
            parentTr = this.transform.parent;
            parentStart = this.transform.parent;
        }

        // canvas = GameObject.Find("Canvas");
        canvasGroup = this.GetComponent<CanvasGroup>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        beginPoint = parentTr.position;
        beginParent = this.transform.parent;
        moveBegin = eventData.position;
        if(parentTr == this.transform)
        {
            this.GetComponent<RectTransform>().SetParent(this.transform.parent.parent);
        }
    }

    // �巡�� : ���콺 Ŀ�� ��ġ�� �̵�
    public void OnDrag(PointerEventData eventData)
    {
        parentTr.position = beginPoint + (eventData.position - moveBegin);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(parentStart == beginParent)
        {
            this.transform.SetParent(beginParent);
        }
        if(canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = true;
        }
        if(this.GetComponent<RectTransform>().parent.name == "Inventory")
        {
            this.transform.SetParent(beginParent);
            this.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = false;
        }
    }

}