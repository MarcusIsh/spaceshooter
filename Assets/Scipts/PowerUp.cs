using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private int _powerupId;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with:" + other.name);

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (_powerupId == 0)
                {
                    player.TripleShotPowerOn();
                }
                else if (_powerupId == 1)
                {
                    player.SpeedBoostOn();
                }
                else if (_powerupId == 2)
                {

                }
            }
            Destroy(this.gameObject);
            
        }
        
    }
}
