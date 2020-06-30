using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinController : MonoBehaviour
{
    public float jetpackForce = 75.0f;
    public float fowardMovementSpeed = 3.0f;
    private void FixedUpdate()
    {
        bool jetpackActive = Input.GetButton("Fire1");
        if(jetpackActive)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2
                (0, jetpackForce));
        }
        MoveX();
        
    }
    void MoveX()
    {
        Vector2 newVelocity = this.GetComponent
            <Rigidbody2D>().velocity;
        newVelocity.x = fowardMovementSpeed;
        this.GetComponent<Rigidbody2D>().velocity = newVelocity;
    }
}
