using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public int spawnInterval;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public List<GameObject> powerUpTemplateList;

    private float _timer;
    private List<GameObject> _powerUpList;

    // Start is called before the first frame update
    void Start()
    {
        _powerUpList = new List<GameObject>();
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            _timer -= spawnInterval;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (_powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);
        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        _powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        _powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (_powerUpList.Count > 0)
            RemovePowerUp(_powerUpList[0]);
        _timer = 0; // Timer Resets
    }
}
