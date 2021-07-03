using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement2D movement2D;

    private PlayerBattle playerBattle;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private SPUM_SpriteList sPUM_Sprite;

    Camera cam;

    [SerializeField]
    Interactable interactableFocus = null;

    private float fDirection = 0f;

    // Start is called before the first frame update
    void Start()
    {
        movement2D = GetComponent<PlayerMovement2D>();
        playerBattle = GetComponentInChildren<PlayerBattle>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerAction();
    }

    void PlayerMovement()
    {
        fDirection = Input.GetAxisRaw("Horizontal");
        movement2D.Move(fDirection);

        if (fDirection != 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                movement2D.TryDash(fDirection);
            }

            animator.SetBool("Run", true);
            animator.SetFloat("RunState", 0.5f);
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetFloat("RunState", 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(movement2D.IsFlatformer && Input.GetKey(KeyCode.DownArrow))
            {
                movement2D.DownJump();
            }
            else
            {
                movement2D.Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log(TextManager.Instance.Text("t"));
        }

        PlayerFlip(fDirection);
    }

    void PlayerFlip(float _fDir)
    {
        float scaleX = transform.localScale.x;
        if (_fDir > 0)
        {
            if (scaleX > 0)
                scaleX *= -1;

            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (_fDir < 0)
        {
            if (scaleX < 0)
                scaleX *= -1;

            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    void PlayerAction()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) && !playerBattle.IsAttacked)
        {
            animator.SetTrigger("Attack");
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
