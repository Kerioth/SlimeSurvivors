using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using CrabStuff;

public class DragBuild : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    Canvas canvas;
    public GameObject tower;
    public GameObject range;
    private RectTransform rect;

    public int cost = 50;

    private Vector3 startPosition;

    public bool isDrag = false;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        startPosition = rect.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("begin drag");
        range.SetActive(true);
        AudioManager.Instance.PlaySound("Pik");

        isDrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("drag");
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("end drag");
        range.SetActive(false);
        Vector3 position = Pointer.GetPointerWorldPosition2D();
        Instantiate(tower, position, Quaternion.identity);
        rect.anchoredPosition = startPosition;

        isDrag = false;

        AudioManager.Instance.PlaySound("Explode");
        Wallet.Instance.Pay(cost);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Pointer Down");
    }
}
