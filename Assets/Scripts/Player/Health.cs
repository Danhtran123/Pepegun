using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private static int health;
    public int maxHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Text score;

    public GameObject deathMenuUI;

    void Awake()
    {
        health = maxHearts;
    }

    void Update()
    {

        if(health > maxHearts)
        {
            health = maxHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < maxHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }
        Die();
    }

    public int GetHealth()
    {
        return health;
    }

    public void setHealth(int hp)
    {
        health = hp;
    }

    public void Die()
    {
        if (health <= 0)
        {
            transform.gameObject.SetActive(false);
            Debug.Log("dead");
            GameObject.Find("CameraBase").GetComponent<NewCameraController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PauseMenu.isPaused = true;
            Time.timeScale = 0;
            score.text = "Your score was: " + GameManager.playerScore;
            deathMenuUI.SetActive(true);
        }
    }

}
