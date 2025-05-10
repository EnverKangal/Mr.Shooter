using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public Transform firePoint;
    public UIManager uIManager;
    public float bulletForce = 10;
    public int bulletcount = 10;
    public GameObject bulletPrefab;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && bulletcount > 0)
        {
            Shoot();

        }
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);
        bulletcount--;
        Debug.Log(bulletcount);
        uIManager.BulletCount();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AmmoPack") && bulletcount < 90)
        {
            collision.gameObject.SetActive(false);
            bulletcount += 10;
            uIManager.BulletCount(); // Yerdeki mermiyi günceller anlık olarak
        }
         else if (collision.CompareTag("Hnegatif"))
        {
            collision.gameObject.SetActive(false);
            bulletcount -= 5;
            uIManager.BulletCount();
        }
    }
    
}
