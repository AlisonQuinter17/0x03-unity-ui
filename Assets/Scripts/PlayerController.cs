using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1000f;
    public Rigidbody rb;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;


    // Fixed Update is called once per frame
    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
            // Debug.Log("Score: " + score);
        }
        if (other.tag == "Trap")
        {
            health--;
            SetHealthText();
            // Debug.Log("Health: " + health);
        }
        if (other.tag == "Goal")
        {
            winLoseBG.gameObject.SetActive(true);
            winLoseBG.color = Color.green;
            winLoseText.color = Color.black;
            winLoseText.text = "You win!";
            StartCoroutine(LoadScene(3));
            // Debug.Log("You win!");
        }
    }

    void Update()
    {
        if (health == 0)
        {
            winLoseBG.gameObject.SetActive(true);
            winLoseBG.color = Color.red;
            winLoseText.color = Color.white;
            winLoseText.text = "Game Over!";
            StartCoroutine(LoadScene(3));
            // Debug.Log("Game Over!");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    /* Score inspection */
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        
    }

    /* Health inspection */
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    /* The scene restarts again after n seconds */
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0);
    }
}
