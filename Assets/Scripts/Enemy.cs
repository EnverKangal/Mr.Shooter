using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gameManager; // Enemy üretimini durdurmak için tanımlandı
    public Transform player; // Script tanımlamaları
   
    public float moveSpeed = 5;
    private Vector2 movement;
    private Rigidbody2D rb;
    public void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Enemyler bizibulsun ve oradan onaların prefabını erişim için yazdım :)
       
    }

    public void Update()
    {
        Vector3 direction = player.position - transform.position; // Player positon - düşman position 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize(); // Vektörün büyüklüğü 1 den büyük olamıyor
        movement = direction;  // Beni takip et movement 


    }
    public void FixedUpdate()
    {
        moveCharcter(movement);
    }
    public void moveCharcter(Vector2 direction)
    { //Time.deltatime birim kareye (frame) göre hız hareketini sağlıyor
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    public void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            hit.gameObject.SetActive(false);
            Debug.Log("Oyuncum yok oldu");
            gameManager.GameOver(); // Enemy üretimi durdu bize değince
           
        }
            
             
    }

}
