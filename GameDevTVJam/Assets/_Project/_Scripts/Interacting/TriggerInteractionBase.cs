using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteractionBase : MonoBehaviour, IInteractable
{
    public bool CanInteract { get; set; }

    protected SpriteRenderer spriteRenderer;
    [SerializeField] protected Material outlines;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        outlines = Instantiate(outlines);
        if(spriteRenderer != null)
            spriteRenderer.material = outlines;
    }

    private void Update()
    {
        if(CanInteract)
        {
            if(InputManager.Instance.InteractPressedThisFrame)
            {
                Interact();
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            spriteRenderer?.material.EnableKeyword("_OUTLINES");
            CanInteract = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.material.DisableKeyword("_OUTLINES");
            CanInteract = false;
        }
    }
    public virtual void Interact() { }
}
