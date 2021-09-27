using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITestInput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UINavigation.Instance.Push("PopupEquip");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            UINavigation.Instance.Push("PopupDefault");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            UINavigation.Instance.Push("PopupItemInfo");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            UINavigation.Instance.PopTo("PopupEquip");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            UINavigation.Instance.PopTo("PopupDefault");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            UINavigation.Instance.PopTo("PopupItemInfo");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            UINavigation.Instance.Pop();
        }
    }
}
