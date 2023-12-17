using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MinotaurController : MonoBehaviour
{
    Animator animator;

    public Transform player;
    public float speed = 5.0f;
    public float detectionRange = 10.0f; // The range within which the Minotaur will start chasing the player
    private Vector3 direction = Vector3.forward;
    private Rigidbody rb;
    private bool isGameOver = false;
    private AudioSource audioSource;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
         // If the game is not over and the player is within detection range, update direction to point towards the player
    if (!isGameOver && Vector3.Distance(transform.position, player.position) < detectionRange)
    {
        direction = (player.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction); // Make the Minotaur face the direction of movement
        }
    }

    void FixedUpdate()
    {
        // Move the Minotaur
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // When the Minotaur hits a wall, turn right
        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.Rotate(0, 90, 0);
            direction = transform.forward;
            transform.rotation = Quaternion.LookRotation(direction); // Make the Minotaur face the direction of movement
        }
                // If the Minotaur hits Theseus, end the game
        if (collision.gameObject.CompareTag("Theseus"))
        {
            animator.SetBool("Smack", true);
            speed = 0;
            audioSource.Play();
            GameOver();
        }
    }

void GameOver()
{
    // Set isGameOver to true
    isGameOver = true;
    
    // Delay the end of the game by 5 seconds
    Invoke("EndGame", 3f);


}

void EndGame()
{

    // Display the game over screen
    Transform canvasTransform = GameObject.Find("Canvas").transform; 
    Transform gameOverScreen = canvasTransform.Find("GameOverScreen"); 
    gameOverScreen.gameObject.SetActive(true);
    

    Invoke("StopGame", 10f);
}
void StopGame(){
    // Stop the game
    Time.timeScale = 0;    
}


}
