using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public PlayerMovement movement;
    public float bouncyness = 0.75f;
    public bool willBounceLat;
    public bool willBounceVert;

    void FixedUpdate() 
    {
        // Lateral bounce
        if (movement.speed >= 20 && !movement.isGrounded)
        {
            willBounceLat = true;
        }

        // Vertical Bounce
        if (movement.velocity.y < -5 && !movement.isGrounded)
        {
            willBounceVert = true;
            
        }
    }

    void OnControllerColliderHit() 
    {

        if (willBounceLat) 
        {
            movement.storedVelo = -movement.storedVelo;
            Debug.Log("Hit Wall should bounce back");
        }

        if (willBounceVert) 
        {
            movement.velocity.y = -movement.velocity.y;
            Debug.Log("Hit ground, should bounce up");
        }

        willBounceLat = false;
        willBounceVert = false;
    }
}
