using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Interactable focus;
    public LayerMask movementMask;
    static Animator anim;
    public float speed;
    Camera cam;

   
  
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotationSpeed = 80f;
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        //for jumping the character
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }
        //for walking the character
        if (translation != 0)
        {
            anim.SetBool("isWalking", true);
            RemoveFocus();
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        //for runnig the character
        if (Input.GetKey(KeyCode.LeftShift))
        {

            anim.SetBool("isRunning", true);
            RemoveFocus();
        }
        else
        {
            anim.SetBool("isRunning", false);
         
        }

        //for attack animation
        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("isAttacking", true);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }
    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            
            focus = newFocus;
        }
       
        newFocus.OnFocused(transform);
        
    }
    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
 
    }
}
