using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour {

    private GameObject gameWon;
    private bool won;

	// Use this for initialization
	void Start () {
        won = false;
        gameWon = GameObject.FindGameObjectWithTag("GameWon");
        gameWon.SetActive(false);
	}

    private void Update()
    {
        if (won)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Level2");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        won = true;
        Time.timeScale = 0;
        gameWon.SetActive(true);
    }
}
