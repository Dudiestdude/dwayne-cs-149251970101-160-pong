using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public GameObject powerUp;
    public Collider2D ball;
    public int spawnDuration;
    public float magnitude;

    private float _timer;

    private void Start()
    {
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > spawnDuration)
        {
            manager.RemovePowerUp(powerUp); // Despawn Self
            Debug.Log("Object Removed");
            _timer -= spawnDuration;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
}
