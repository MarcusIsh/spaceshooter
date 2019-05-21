using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField]
    private float _speed = 7.0f;
    [SerializeField]
    private GameObject _enemyExplosionPrefab;


    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();

    }

    private void movement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        //down -6.5
        //up 6.5
        float xStart = Random.Range(-9.73f, 9.7f);
        float yPos = transform.position.y;

        if (yPos < -7f)
        {
            transform.position = new Vector3(xStart, 7, 0);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "laser")
        {
            Destroy(other.gameObject);
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            
        }
        else if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
        }
    }

    }
