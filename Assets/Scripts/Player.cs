using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private UIManager _uimanager;
    [SerializeField]
    private SpawnManager _spawnManager;
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripelShot;
    [SerializeField]
    private bool _tripleShotActive = false;
    [SerializeField]
    private float fireRate = 1.0f;
    private float nextFire = 0.0f;
    [SerializeField]
    private bool sheildsUp = false;
    [SerializeField]
    private GameObject shields;
    [SerializeField]
    private int _score;
    [SerializeField]
    private GameObject _explosionFX;
    [SerializeField]
    private GameObject _rightFire;
    [SerializeField]
    private GameObject _leftFire;
    AudioSource _AudioData;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        transform.position = new Vector3(0, 0, 0);
        if (_uimanager == null)
        {
            Debug.LogError("UI Manager is NULL");
        }
        if (_spawnManager == null)
        {
            Debug.LogError("the spawn Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        Shoot();
        

        //if i press fire1 spawn a laser
    }
    void CalculateMovement()
    {
        //movement script
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        
        transform.Translate(direction *_speed * Time.deltaTime);
        
        //if postion on the Y is greater than 0 
        //y postion is 0 

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.24f, 0), 0);
        //X bounds
        if (transform.position.x > 9.7)
        {
            transform.position = new Vector3 (-9.6f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.6)
        {
            transform.position = new Vector3 (9.7f, transform.position.y, 0);
        }
    }
    void Shoot()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Vector3 offset = new Vector3(0, 1.0f, 0);
            if (_tripleShotActive == false)
            {
                Instantiate(_laserPrefab, transform.position + offset, Quaternion.identity);
            }
            else if (_tripleShotActive == true)
            {
                Instantiate(_tripelShot, transform.position, Quaternion.identity);
            }
        }
    }
    public void Damage()
    {
        if (sheildsUp == true)
       {
           sheildsUp = false;
           shields.transform.gameObject.SetActive(false);
       }
        else if (sheildsUp == false)
       {
           
           _lives --;
           _uimanager.livesUI(_lives);
        if (_lives == 2)
        {
            _rightFire.transform.gameObject.SetActive(true);
        }
        if (_lives == 1)
        {
            _leftFire.transform.gameObject.SetActive(true);
        }   
       }
        if (_lives == 0)
       {
           Instantiate(_explosionFX, transform.position, Quaternion.identity);
           _spawnManager.onPlayerDeath();
           Destroy(this.gameObject);
       }

        
    }
    public void TriplePowerUp()
    {
        _tripleShotActive = true;
        StartCoroutine(TripleshotPowerUpDecay());
    }
   IEnumerator SpeedPowerUpDecay()
   {
       yield return new WaitForSeconds(7.0f);
       _speed = 3.5f;

   }
   IEnumerator TripleshotPowerUpDecay()
   {
       while (_tripleShotActive == true)
       {
           yield return new WaitForSeconds(7.0f);
            _tripleShotActive = false;
       }
   }
   public void SpeedPowerup()
   {
       _speed = 7.0f;
       StartCoroutine(SpeedPowerUpDecay());       
   }
    public void PowerUpShields()
    {
        sheildsUp = true;
        shields.transform.gameObject.SetActive(true);
    }
    public void addScore(int points)
    {
        _score += points;
        _uimanager.UpdateScore(_score);
    }
}

