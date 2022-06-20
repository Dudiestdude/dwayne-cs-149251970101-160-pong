using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUStretchController : MonoBehaviour
{
    public PowerUpManager manager;
    public GameObject powerUp;
    public Collider2D paddle;
    public Vector3 defaultScale;
    public int stretchDuration;
    public float modifier;
    public Vector2 speed;
    private Rigidbody2D _rig;
    private float _timer;
    
    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
        _rig = GetComponent<Rigidbody2D>();
        _rig.velocity = speed;
        transform.Translate(speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 10 || transform.position.x < -10)
        {
            manager.RemovePowerUp(powerUp); // Despawn Self
            Debug.Log("Object Removed");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == paddle)
        {
            paddle.GetComponent<PaddleController>().ActivatePUStretch(modifier);
            Debug.Log("Collided");
            manager.RemovePowerUp(powerUp);
        }
    }
}
