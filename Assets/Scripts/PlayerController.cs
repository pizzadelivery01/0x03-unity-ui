using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public Text scoreText;
    public float speed;
    private Rigidbody body;
    private Vector3 movement;
    private int score = 0;
    public int health = 5;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody> ();
        speed = 50.0F;
    }
    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("maze");
            health = 5;
            score = 0;
        }
    }
    // FixedUpdate is called once per fixed framerate frame
    void FixedUpdate()
    {
       movePlayer(movement);
    }
    void movePlayer(Vector3 direction)
    {
        body.AddForce(direction * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            Destroy(other.gameObject);
            score += 1;
			SetScoreText();
            //Debug.Log("Score: " + score);
        }
        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            Debug.Log(string.Format("Health: {0}", health));
        }
          if (other.gameObject.tag == "Goal")
        {
            Debug.Log(string.Format("You win!"));
        }
    }
	void SetScoreText()
	{
		scoreText.text = "Score: " + score.ToString();
	}
}
