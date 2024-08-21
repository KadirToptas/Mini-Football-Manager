using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIPage : MonoBehaviour
{
    public void Show()
    {
        this.gameObject.transform.localScale = Vector3.one;
        OnShow();
    }

    protected virtual void OnShow() { }

    public void Hide()
    {
        this.gameObject.transform.localScale = Vector3.zero;
    }

}