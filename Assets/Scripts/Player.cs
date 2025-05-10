using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float movementSpeed;
    public Camera cam;
    Vector2 mousePos;
    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();


    }
    public void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);//Sürekli mouse takip etmesi için
    }
    public void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rb2d.velocity = new Vector2(h * movementSpeed * Time.deltaTime, v * movementSpeed * Time.deltaTime);

        Vector2 lookDirection = mousePos - rb2d.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;//Atan2 fonk ile aradaki açı hesapla o anki konumun bul
        rb2d.rotation = angle;

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpeedPack"))
        {
            collision.gameObject.SetActive(false);
            movementSpeed = 600;
        }
       
    }
   
}
