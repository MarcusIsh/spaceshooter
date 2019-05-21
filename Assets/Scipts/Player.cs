using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShotPrefab;


    [SerializeField]
    public int lives = 3;

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private float _fireRate = 0.25f;

    private float _nextFire = 0.0f;

    public bool canTripleShot = false;

    public bool speedBoost = false;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        movement();



        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }


    }

    private void movement()
    {
        if (speedBoost == true)
        {
            _speed = 10.0f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float veritcalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * _speed * veritcalInput);

        float yPos = transform.position.y;
        float xPos = transform.position.x;

        if (yPos > 0)
        {
            transform.position = new Vector3(xPos, 0, 0);
        }
        else if (yPos < -4.254012)
        {
            transform.position = new Vector3(xPos, -4.254012f, 0);
        }

        if (xPos > 11.35)
        {
            transform.position = new Vector3(-xPos, yPos, 0);
        }
        else if (xPos < -11.35)
        {
            transform.position = new Vector3(11.35f, yPos, 0);
        }


    }

    private void shoot()
    {

        if (Time.time > _nextFire)
        {
            if (canTripleShot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.99f, 0), Quaternion.identity);
                _nextFire = Time.time + _fireRate;
            }
        }


    }
    public void TripleShotPowerOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        canTripleShot = false;
    }

    public void SpeedBoostOn()
    {
        speedBoost = true;
        StartCoroutine(SpeedBoostPowerDown());
    }

    public IEnumerator SpeedBoostPowerDown()
    {
        yield return new WaitForSeconds(5.0f);

        speedBoost = false;

        _speed = 5.0f;
    }

    public void Damage()
    {
        lives--;
        if (lives < 1)
        {
            Destroy(this.gameObject);
        }


    }
}
