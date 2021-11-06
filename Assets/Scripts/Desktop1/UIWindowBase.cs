using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UIWindowBase : MonoBehaviour, IPointerDownHandler, IDragHandler
{

    private Vector2 originalLocalPointerPosition;
    private Vector3 originalPanelLocalPosition;
    private RectTransform panelRectTransform;
    private RectTransform parentRectTransform;
    public RectTransform canvas;
    //object that is going to be moved
    public GameObject g;

    void Awake()
    {
        panelRectTransform = g.transform as RectTransform;
        parentRectTransform = panelRectTransform.parent as RectTransform;
        canvas = GameObject.FindGameObjectWithTag("Respawn").transform as RectTransform;
        
    }

    public void OnPointerDown(PointerEventData data)
    {
        originalPanelLocalPosition = panelRectTransform.localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, data.position, data.pressEventCamera, out originalLocalPointerPosition);
        panelRectTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData data)
    {
        if (panelRectTransform == null || parentRectTransform == null)
            return;

        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, data.position, data.pressEventCamera, out localPointerPosition))
        {
            float screenWidth = canvas.rect.width;
            float screenHeight = canvas.rect.height;
            float rectWidth = panelRectTransform.rect.width;
            float rectHeight = panelRectTransform.rect.height;
            Vector3 offsetToOriginal = localPointerPosition - originalLocalPointerPosition;
            panelRectTransform.localPosition = originalPanelLocalPosition + offsetToOriginal;
            Vector3 point = panelRectTransform.localPosition;
            point.x = Mathf.Clamp(point.x, -screenWidth / 2 + rectWidth / 4, screenWidth / 2 - rectWidth / 4);
            point.y = Mathf.Clamp(point.y, -screenHeight / 2 + rectHeight / 2, screenHeight / 2 - rectHeight / 2);
            panelRectTransform.localPosition = point;
            panelRectTransform.SetAsLastSibling();
        }

    }


}
