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

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        posOrigin = rectTransform.position;
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
        rectTransform.position = Vector3.zero;
    }

    public void hide()
    {
        rectTransform.position = posOrigin;
    }
}
