using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public  int         speed;
    public  KeyCode     upKey;
    public  KeyCode     downKey;
    private Rigidbody2D _rig;

    private void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveObject(GetInput()); 
    }

    private Vector2 GetInput() // Scan for input
    {
        if (Input.GetKey(upKey))
            while (transform.position.y < 3.6f)
                return Vector3.up * speed; // Move paddle up
        if (Input.GetKey(downKey))
            while (transform.position.y > -3.6f)
                return Vector3.down * speed; // Move paddle down

        return Vector2.zero; //
    }

    private void MoveObject(Vector2 movement)
    {
        _rig.velocity = movement; // Update paddle position
    }
}
