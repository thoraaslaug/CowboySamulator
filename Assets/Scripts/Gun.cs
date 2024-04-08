using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using StarterAssets;

public class Gun : MonoBehaviour
{
    private StarterAssetsInputs inputs;
    
    [SerializeField]  private GameObject bullet;
    [SerializeField]  private GameObject bulletPoint;

    public float bulletspeed = 600;
    // Start is called before the first frame update
    void Start()
    {
        inputs = transform.root.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
     {
        if (inputs.shoot)
        {
            Shoot();
            inputs.shoot = false;
        }
    }

    void Shoot()
    {
        Debug.Log("shot");
        GameObject Bullet =Instantiate(bullet, bulletPoint.transform.position, transform.rotation);
        Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletspeed);
        Destroy(Bullet, 1f);
    }
}