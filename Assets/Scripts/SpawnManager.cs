﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerups;
    private bool _stopSpawning = false;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
   
    
    void Start()
    {

    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemeyRoutine());
        StartCoroutine(SpawnPowerUp());
    }
    void Update()
    {
        
    }
    IEnumerator SpawnEnemeyRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawning == false)
        {
            Vector3 SpawnPostion = new Vector3(Random.Range(-8.0f, 8.0f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, SpawnPostion, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(3.0f);
        }
    }
    IEnumerator SpawnPowerUp()
    {
        while (_stopSpawning == false)
        {
            Vector3 SpawnPostion = new Vector3(Random.Range(-8.0f, 8.0f), 7, 0);
            yield return new WaitForSeconds(Random.Range(8.0f, 12.0f));
            int RandomPowerUp = Random.Range(0, 3);
            Instantiate(powerups[RandomPowerUp], SpawnPostion, Quaternion.identity);
        }
    }
    public void onPlayerDeath()
    {
        _stopSpawning = true;
    }
}
    