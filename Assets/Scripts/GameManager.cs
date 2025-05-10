using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyObj;
    public UIManager uiManager;
    public GameObject[] spawnPoints; // Spawn noktalarını toplayacağım bir liste oluşturdum 
    private float spawnDelay = 1f;
    [Range(1, 4)] // Belli range aralığı oluşturduk içindeki değeri değiştirmek bize kalmış
    public int spawnRate;
    public void Start()
    {
        SpawnEnemyLoop();
    }
    public void SpawnEnemyLoop()
    {
         InvokeRepeating("SpawnEnemy", spawnDelay, spawnRate); // İlk başlangıçta bir düşman Start fon daha sonra belirlenen aralıklar süresinde spawn oluyor
    }
    public void GameOver()
    {
        CancelInvoke();
        uiManager.backGroundOpen();
        Time.timeScale = 0;
    }
    public void SpawnEnemy()
    {
        // Quertantion rastgele açıda oluşumunu sağlamak için,Transform.positon-- şuanki objemızın oldugu pozisyon
        int spawn = Random.Range(0, spawnPoints.Length);
        Instantiate(EnemyObj, spawnPoints[spawn].transform.position, Quaternion.identity);
    }
    
}
