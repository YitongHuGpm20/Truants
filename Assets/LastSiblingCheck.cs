using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSiblingCheck: MonoBehaviour
{
    

    public bool IsLastSibling(Transform t)
    {
        if (t != null && t.parent != null)
        {
            return t.GetSiblingIndex() == (t.parent.childCount - 1);
        }
        return true;
    }

    
}
