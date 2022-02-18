using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float InteractRadius = 2f;
    public Transform InteractionTransform;

    private bool isFocus = false;
    private bool hasInreracted = false;
    private Transform player;

    public virtual void Interact()
    {
        //Debug.Log("INTERACT With" + transform.name);
    }

    private void Update()
    {
        if (isFocus == true && hasInreracted == false)
        {
            float distance = Vector3.Distance(player.position, InteractionTransform.position);
            if (distance <= InteractRadius)
            {
                Interact();
                hasInreracted = true;   
            }
        }
    }

    public void OnFocused(Transform playerTranform)
    {
        isFocus = true;
        player = playerTranform;
        hasInreracted = false;
    } // Focus Object
    public void OnDefocused() 
    {
        isFocus = false;
        player = null;
        hasInreracted = true; 
    } // Defocus Object

    private void OnDrawGizmosSelected()
    {
        if (InteractionTransform == null)
            InteractionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractionTransform.position, InteractRadius);
    } // draw Sphere around Interacteble 

} 
