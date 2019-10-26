using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;    
    [SerializeField]
    private int powerupID;
   [SerializeField]
   private AudioClip _powerupSounds;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.down * _speed * Time.deltaTime);
        
        if (transform.position.y < -5.5)
        {
            Destroy(this.gameObject);
        }
    }
private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            Player player = other.transform.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(_powerupSounds, transform.position);
            if (player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        player.TriplePowerUp();
                        break;
                    case 1:
                        player.SpeedPowerup();
                        break;
                    case 2:
                        player.PowerUpShields();
                        break;
                }
                
            }
            Destroy(this.gameObject);
        }
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}


