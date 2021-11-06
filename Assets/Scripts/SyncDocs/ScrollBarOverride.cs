using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Try to disable mouse dragging in scroll view
/// Scrolling only controlled by scroll bar
/// </summary>

public class ScrollBarOverride : ScrollRect
{
    public override void OnBeginDrag(PointerEventData eventData) {}
    public override void OnDrag(PointerEventData eventData) {}
    public override void OnEndDrag(PointerEventData eventData) {}
}
