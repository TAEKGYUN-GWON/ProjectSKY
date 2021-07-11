using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    PlayerMovement2D movement2D;

    PlayerBattle playerBattle;

    [SerializeField]
    Animator animator;

    [SerializeField]
    SPUM_SpriteList sPUM_Sprite;

    [SerializeField]
    PlayerCommandInvoker commandInvoker = new PlayerCommandInvoker();

    Camera cam;

    [SerializeField]
    Interactable interactableFocus = null;

    // Start is called before the first frame update
    void Start()
    {
        movement2D = GetComponent<PlayerMovement2D>();
        playerBattle = GetComponentInChildren<PlayerBattle>();
        cam = Camera.main;
        InitMoveCommand();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerAction();
    }

    void InitMoveCommand()
    {
        var leftMove = new MoveCommand(movement2D, animator, transform, -1);
        var rightMove = new MoveCommand(movement2D, animator, transform, 1);
        var stopMove = new MoveCommand(movement2D, animator, transform, 0);
        commandInvoker.AddCommand("LEFT_MOVE", leftMove);
        commandInvoker.AddCommand("RIGHT_MOVE", rightMove);
        commandInvoker.AddCommand("STOP_MOVE", stopMove);

        var dash = new DashCommand(movement2D);
        commandInvoker.AddCommand("DASH", dash);

        var jump = new JumpCommand(movement2D);
        commandInvoker.AddCommand("JUMP", jump);
        var downJump = new DownJumpCommand(movement2D);
        commandInvoker.AddCommand("DOWN_JUMP", downJump);

        var swordAttack = new SwordAttackCommand(playerBattle, animator);
        commandInvoker.AddAttackCommand("SWORD_ATTACK", swordAttack);
    }

    void PlayerMovement()
    {

        if (Input.GetKey(KeyManager.Instance.keys[KEY_ACTION.LEFT]))
        {
            commandInvoker.InvokeExcute("LEFT_MOVE");
        }
        else if (Input.GetKey(KeyManager.Instance.keys[KEY_ACTION.RIGHT]))
        {
            commandInvoker.InvokeExcute("RIGHT_MOVE");
        }
        else
        {
            commandInvoker.InvokeExcute("STOP_MOVE");
        }

        if (Input.GetKeyDown(KeyManager.Instance.keys[KEY_ACTION.DASH]))
        {
            commandInvoker.InvokeExcute("DASH");
        }

        if (Input.GetKeyDown(KeyManager.Instance.keys[KEY_ACTION.JUMP]))
        {
            if(movement2D.IsFlatformer && Input.GetKey(KeyManager.Instance.keys[KEY_ACTION.DOWN]))
            {
                commandInvoker.InvokeExcute("DOWN_JUMP");
            }
            else
            {
                commandInvoker.InvokeExcute("JUMP");
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log(TextManager.Instance.Text("t"));
        }

    }

    void PlayerAction()
    {
        if(Input.GetKeyDown(KeyManager.Instance.keys[KEY_ACTION.ATTACK]) && !playerBattle.IsAttacked)
        {
            commandInvoker.InvokeExcuteAttack("SWORD_ATTACK");
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != interactableFocus)
        {
            if (interactableFocus != null)
                interactableFocus.onDefocused();

            interactableFocus = newFocus;
            interactableFocus.OnFocused(transform);
        }
    }

    void RemoveFocus()
    {
        if (interactableFocus != null)
            interactableFocus.onDefocused();

        interactableFocus = null;
    }

    public void ItemSetup(ItemInfo item)
    {
        SetItemPath(item);
        sPUM_Sprite.ResyncData();
    }

    private void SetItemPath(ItemInfo item)
    {
        switch (item.ItemType)
        {
            case E_ITEM_TYPE.EQUIP:
                {
                    var equip = ItemManager.Instance.GetEquipsInfo(item);

                    switch (equip.EquipType)
                    {
                        case E_EQUIP_TYPE.HELMET:
                            {
                                var pathList = sPUM_Sprite._hairListString;
                                pathList[0] = item.SpritePath;
                            }
                            break;
                        case E_EQUIP_TYPE.ARMOR_TOP:
                            {
                                var pathList = sPUM_Sprite._armorListString;
                                for (int i = 0; i < pathList.Count; ++i)
                                {
                                    pathList[i] = item.SpritePath;
                                }
                            }
                            break;
                        case E_EQUIP_TYPE.ARMOR_PANTS:
                            {
                                var pathList = sPUM_Sprite._pantListString;
                                for (int i = 0; i < pathList.Count; ++i)
                                {
                                    pathList[i] = item.SpritePath;
                                }
                            }
                            break;
                    }
                }
                break;
            case E_ITEM_TYPE.WEAPON:
                {
                    var pathList = sPUM_Sprite._weaponListString;
                    pathList[0] = item.SpritePath;
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            SetFocus(collision.GetComponent<Interactable>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            if(interactableFocus == collision.GetComponent<Interactable>())
                RemoveFocus();
        }
    }
}
