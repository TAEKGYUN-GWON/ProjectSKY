using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UINavigation : Singleton<UINavigation>
{
    [SerializeField]
    List<UIView> historyUI = new List<UIView>();
    UIView currentUI = null;

    [SerializeField]
    int currentOrder = 1;

    public int Order => currentOrder;

    public UIView Push(string name)
    {
        var uiView = UIView.Get(name);

        if(uiView != null)
        {
            if(historyUI.Find(obj => obj == uiView))
            {
                historyUI.Remove(uiView);
            }
            historyUI.Add(uiView);
            currentUI = uiView;

            currentUI.show();

            currentOrder++;
        }

        return currentUI;
    }

    public UIView Pop()
    {
        if (currentUI == null)
            return currentUI;

        historyUI.Remove(currentUI);
        currentUI.hide();
        if(historyUI.Count > 0)
            currentUI = historyUI.Last();
        else
        {
            currentUI = null;
            currentOrder = 1;
        }

        return currentUI;
    }

    public UIView PopTo(string name)
    {
        for (int i = 0; i < historyUI.Count; ++i)
        {
            historyUI.Remove(currentUI);
            currentUI.hide();
            if (historyUI.Count > 0)
                currentUI = historyUI.Last();
            else
            {
                currentUI = null;
                currentOrder = 1;
            }

            if (currentUI == null || currentUI.name.Equals(name))
                break;
        }

        return currentUI;
    }

    public UIView PopToRoot()
    {
        if (currentUI == null)
            return currentUI;

        for (int i = 0; i < historyUI.Count - 1; ++i)
        {
            historyUI.Remove(currentUI);
            currentUI.hide();
            if (historyUI.Count > 0)
                currentUI = historyUI.Last();
            else
            {
                currentUI = null;
                currentOrder = 1;
            }
        }

        return currentUI;
    }
}
