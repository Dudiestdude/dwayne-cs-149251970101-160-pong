using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public  int         speed;
    public  KeyCode     upKey;
    public  KeyCode     downKey;
    public Vector3      scale;
    public int stretchDuration;
    private Rigidbody2D _rig;
    private Vector3     _defaultScale;
    private float _timer;

    private void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _defaultScale = transform.localScale;
        _timer = 0;
    }

    private void Update()
    {
        MoveObject(GetInput());
        _timer += Time.deltaTime;
    }

    private Vector2 GetInput() // Scan for input
    {
        if (Input.GetKey(upKey))
            return Vector3.up * speed; // Move paddle up
        if (Input.GetKey(downKey))
            return Vector3.down * speed; // Move paddle down

        return Vector2.zero; // Stop paddle when no key is pressed
    }

    private void MoveObject(Vector2 movement)
    {
        Debug.Log("Paddle Speed: " + _rig.velocity);
        _rig.velocity = movement; // Update paddle position
    }

    public void ResetPaddle()
    {
        transform.position = new Vector2(transform.position.x, 0f);
    }
    public void ActivatePUStretch(float modifier)
    {
        
        Debug.Log("Stretch Paddle");
        if (transform.localScale.y > 1)
        {
            Debug.Log("Maxed Out");
            Debug.Log(transform.localScale);
        }
        scale = _defaultScale;
        scale.y = scale.y * modifier;
        transform.localScale = scale;
    }
}
