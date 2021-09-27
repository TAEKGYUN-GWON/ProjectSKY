using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UniRx;

public class UIView : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 posOrigin = Vector3.zero;
    RectTransform rectTransform;
    Canvas canvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponent<Canvas>();
        posOrigin = rectTransform.localPosition;
        hide();
    }


    public static UIView Get(string name)
    {
        UIView result = null;

        result = GameObject.Find(name).GetComponent<UIView>();

        return result;
    }

    public void show()
    {
        rectTransform.localPosition = Vector3.zero;
        canvas.sortingOrder = UINavigation.Instance.Order;

    }

    public void hide()
    {
        rectTransform.localPosition = posOrigin;
    }
}
