using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenScript : MonoBehaviour
{
    // Set this to your start screen in the inspector
    public GameObject startScreen;
    private Transform canvasTransform; 
    private Transform gameOverScreen; 

    void Start()
    {
        canvasTransform = GameObject.Find("Canvas").transform; 
        gameOverScreen = canvasTransform.Find("GameOverScreen"); 
        
        if (gameOverScreen != null)
        {
            gameOverScreen.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("GameOverScreen not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startScreen.SetActive(false);
        }
    }
}
