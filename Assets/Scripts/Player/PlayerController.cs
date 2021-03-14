using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement2D movement2D;

    private PlayerBattle playerBattle;

    public Texture2D _mainBody;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private SPUM_Prefabs spumPrefabs;

    private float fDirection = 0f;

    // Start is called before the first frame update
    void Start()
    {
        movement2D = GetComponent<PlayerMovement2D>();
        playerBattle = GetComponentInChildren<PlayerBattle>();
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
        if(Input.GetKeyDown(KeyCode.A))
        {
            
            string spritePath = AssetDatabase.GetAssetPath( _mainBody );
            Object[] sprites = AssetDatabase.LoadAllAssetsAtPath(spritePath);
            var sortedList = sprites.OrderBy(go=>go.name).ToList();
            List<Sprite> tSP = new List<Sprite>();
            for (var i = 0; i < sortedList.Count; i++)
            {
                if (sortedList[i].GetType() == typeof(Sprite))
                {
                    tSP.Add((Sprite)sortedList[i]);
                }
            }

            // for(var i = 0 ; i < tSP.Count;i++) Debug.Log(tSP[i]);
            // Debug.Log(tSP.Count);
            spumPrefabs._spriteOBj._bodyList[0].sprite = tSP[5];
            spumPrefabs._spriteOBj._bodyList[1].sprite = tSP[2];
            spumPrefabs._spriteOBj._bodyList[2].sprite = tSP[0];
            spumPrefabs._spriteOBj._bodyList[3].sprite = tSP[1];
            spumPrefabs._spriteOBj._bodyList[4].sprite = tSP[3];
            spumPrefabs._spriteOBj._bodyList[5].sprite = tSP[4];
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
}
