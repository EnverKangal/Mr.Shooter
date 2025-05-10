using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity); // Çrptığımız effectin pozisyonuna göre  effect .agırı
        Destroy(effect, 0.3f);
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
        }
    }
    // Enter Stay farklı enter değdigi anda stay ise temas ettigi sürece
    
}
