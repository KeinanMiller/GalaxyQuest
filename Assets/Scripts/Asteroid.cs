using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    
    [SerializeField]
    private float _rotationSpeed = 3.0f;
    [SerializeField]
    private GameObject _explosionFX;
    [SerializeField]
    private SpawnManager _Spawnmanager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }
    //check for lasers
    //instance the explosion
    //remove game object and explosion
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(_explosionFX, transform.position, Quaternion.identity);
            _Spawnmanager.StartSpawning();
            Destroy(this.gameObject, .25f);
        }
    }
}
