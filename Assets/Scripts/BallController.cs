using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    private Rigidbody2D _rig;

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _rig.velocity = speed;
        transform.Translate(speed * Time.deltaTime);
    }

    private void Update()
    {
        if (transform.position.x > 10) // Reset ball when out of bounds
        {
            transform.position = new Vector3(0f, 0f, 0f); // Reset ball position
            _rig.velocity = new Vector2(speed.x * -1, speed.y); // Reset ball speed & flip direction
        }

        if (transform.position.x < -10)
        {
            transform.position = new Vector3(0f, 0f, 0f); // Reset ball position
            _rig.velocity = new Vector2(speed.x, speed.y); // Reset ball speed & flip direction
        }
            
    }
}
