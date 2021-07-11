using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommandInvoker
{
    private Dictionary<string, ICommand> commandDic = new Dictionary<string, ICommand>();

    private Dictionary<string, ICommand> AttackCommandDic = new Dictionary<string, ICommand>();

    public void AddCommand(string name, ICommand command)
    {
        if(commandDic.ContainsValue(command))
        {
            Debug.Log("이미 존재하는 커맨드");
            return;
        }
        commandDic.Add(name, command);
    }
    public void AddAttackCommand(string name, ICommand command)
    {
        if (AttackCommandDic.ContainsValue(command))
        {
            Debug.Log("이미 존재하는 공격 커맨드");
            return;
        }
        AttackCommandDic.Add(name, command);
    }

    public void InvokeExcute(string name)
    {
        ICommand command = null;
        if (commandDic.TryGetValue(name, out command))
            command.Execute();
        else
            Debug.Log("존재하지 않는 커맨드");
    }
    public void InvokeExcuteAttack(string name)
    {
        ICommand command = null;
        if (AttackCommandDic.TryGetValue(name, out command))
            command.Execute();
        else
            Debug.Log("존재하지 않는 공격 커맨드");
    }
}
