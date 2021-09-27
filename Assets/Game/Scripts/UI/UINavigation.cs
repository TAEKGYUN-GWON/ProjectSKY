using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UINavigation : Singleton<UINavigation>
{
    [SerializeField]
    Stack<UIView> historyUI = new Stack<UIView>();
    UIView currentUI = null;

    public UIView Push(string name)
    {
        var uiView = UIView.Get(name);

        if(uiView != null)
        {
            historyUI.Push(uiView);
            currentUI = uiView;

            currentUI.show();
        }

        return currentUI;
    }

    public UIView Pop()
    {
        currentUI.hide();

        currentUI = historyUI.Pop();

        return currentUI;
    }

    public UIView PopTo(string name)
    {
        for(int i = 0; i < historyUI.Count; ++i)
        {
            currentUI.hide();
            currentUI = historyUI.Pop();

            if(currentUI.name.Equals(name))
                break;
        }

        return currentUI;
    }

    public UIView PopToRoot()
    {
        for (int i = 0; i < historyUI.Count - 1; ++i)
        {
            currentUI.hide();
            currentUI = historyUI.Pop();
        }

        return currentUI;
    }
}
