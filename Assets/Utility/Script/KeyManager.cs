using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KEY_ACTION
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
    JUMP,
    DASH,
    ATTACK,
    KEYCOUNT
}

public class KeyManager : Singleton<KeyManager>
{
    KeyCode[]defaultKeys = new KeyCode[]{KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, 
        KeyCode.RightArrow, KeyCode.Space, KeyCode.LeftShift, KeyCode.LeftControl };

    int nKey = -1;

    public OS.EnumDictionary<KEY_ACTION, KeyCode>keys = new OS.EnumDictionary<KEY_ACTION, KeyCode>();

    private void Awake()
    {
        DefaultKeySetting();
    }

    void DefaultKeySetting()
    {
        for (int i = 0; i < OS.BitConvert.Enum32ToInt(KEY_ACTION.KEYCOUNT); ++i)
        {
            keys.Add(OS.BitConvert.IntToEnum32<KEY_ACTION>(i), defaultKeys[i]);
        }
    }

    private void OnGUI()
    {
        Event keyEvent = Event.current;
        if(keyEvent.isKey)
        {
            keys[OS.BitConvert.IntToEnum32<KEY_ACTION>(nKey)] = keyEvent.keyCode;
            nKey = -1;
        }
    }

    public void ChangeKey(int _num)
    {
        nKey = _num;
    }
}
