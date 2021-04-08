using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    bool hasInteracted = false;
    Transform player;
    public Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();

        if(interactionTransform == null)
            interactionTransform = transform;
        player = null;
    }

    private void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector2.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Interact();
                Debug.Log(name + " INTERACT");
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void onDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    public virtual void Interact()
    {
        // This method is meant to be overwritten

        Debug.Log("Interacting with" + name); 
    }
}
