
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 6f;
    bool isFocus = false;
    Transform Players;

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }
    void Update()
    {
        if (isFocus)
        {
            float distance = Vector3.Distance(Players.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                Debug.Log("INTERACT");
              
            }
        }
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        Players = playerTransform;
        
    }
    public void OnDefocused()
    {
        isFocus = false;
        Players= null;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

  
}
