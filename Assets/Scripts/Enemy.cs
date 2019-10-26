using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    private Player _player;
    Animator _Animator;
    AudioSource _AudioData;

    Collider2D _Collider;
    [SerializeField]
    private GameObject _laserprefab;
    Vector3 offset = new Vector3(0, -1.1f, 0);
    private float firerate = 1.0f;
    private float canfire = 0.0f;
    private bool allowedfire = true;

    // Start is called before the first frame update
    void Start()
    {
       _player = GameObject.Find("Player").GetComponent<Player>();
       _Animator = gameObject.GetComponent<Animator>();
       _AudioData = gameObject.GetComponent<AudioSource>();
       _Collider = gameObject.GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        Calaculatemovement();
        if (Time.time > canfire && allowedfire == true)
        {
            firerate = Random.Range(3.0f, 5.5f);
            canfire = Time.time + firerate;
            Instantiate(_laserprefab, transform.position + offset, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            _AudioData.Play(0);
            _Collider.enabled = false;
            _Animator.SetTrigger("EnemyDestroyed");
            _speed = 0.1f;
            allowedfire = false;
            Destroy(this.gameObject, 2.8f);
        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.addScore(10);
            }
            _AudioData.Play(0);
            _Collider.enabled = false;
            _Animator.SetTrigger("EnemyDestroyed");
            _speed = 0.1f;
            allowedfire = false;
            Destroy(this.gameObject, 2.4f);
        }
    }
    private void Calaculatemovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -6.2f)
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 7, 0);
        }
    }
}
