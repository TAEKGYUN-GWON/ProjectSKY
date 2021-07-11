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
            Debug.Log("�̹� �����ϴ� Ŀ�ǵ�");
            return;
        }
        commandDic.Add(name, command);
    }
    public void AddAttackCommand(string name, ICommand command)
    {
        if (AttackCommandDic.ContainsValue(command))
        {
            Debug.Log("�̹� �����ϴ� ���� Ŀ�ǵ�");
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
            Debug.Log("�������� �ʴ� Ŀ�ǵ�");
    }
    public void InvokeExcuteAttack(string name)
    {
        ICommand command = null;
        if (AttackCommandDic.TryGetValue(name, out command))
            command.Execute();
        else
            Debug.Log("�������� �ʴ� ���� Ŀ�ǵ�");
    }
}
