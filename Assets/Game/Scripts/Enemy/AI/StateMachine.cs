using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IState CurrentState { get; private set; }


    public StateMachine(IState defaltState)
    {
        CurrentState = defaltState;
    }

    public void SetState(IState state)
    {
        if (CurrentState == state)   //�̹� �ش� �����϶�
        {
            return;
        }

        CurrentState.OperateExit();

        CurrentState = state;

        CurrentState.OperateEnter();

    }

    public void DoOperateUpdate()
    {
        CurrentState.OperateUpdate();
    }





}
