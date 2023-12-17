using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 200.0f;
    private Animator animator;
    private Transform cameraTransform;
    private Rigidbody rb;


    void Start()
    {
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
        rb = GetComponent<Rigidbody>();

    }

void Update()
{
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    // Rotate player based on horizontal input
    if (horizontalInput != 0)
    {
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }

    // Move player forward based on vertical input
    if (verticalInput > 0)
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        animator.SetBool("Walk", true);
    }
    else
    {
        animator.SetBool("Walk", false);
    }

}
void OnCollisionEnter(Collision collision)
{
    // If the Minotaur hits Theseus, end the game
    if (collision.gameObject.CompareTag("Minotaur"))
    {
        animator.SetBool("Die", true);
        speed = 0;
    }

      // If Theseus hits the FinishLine, end the game
    if (collision.gameObject.CompareTag("FinishLine"))
        {
            GameOver();
        }
}

    void GameOver()
    {
        // Stop the game
        Time.timeScale = 0;

        // Display the game over screen
        Transform canvasTransform = GameObject.Find("Canvas").transform; 
        Transform gameOverScreen = canvasTransform.Find("VictoryScreen");

        if (gameOverScreen != null)
        {
            gameOverScreen.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("GameOverScreen not found");
        }
    }
}
