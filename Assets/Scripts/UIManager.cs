using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject ReStartButton;
    public TextMeshProUGUI numberBullet;
    public ShootPlayer shootPlayer;
    public void backGroundOpen()
    {
        ReStartButton.SetActive(true); // Hatam şuydu gameObject.backGRoundOpen fonksiyonu farklı bir gameObjecti açar neyi çağırıdığına dikkat

    }
    public void BulletCount()
    {
        numberBullet.text = shootPlayer.bulletcount.ToString();
    }
    public void ReStartScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Sahne yenileme
        Time.timeScale = 1;
    }
    
}
