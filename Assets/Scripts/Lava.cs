using System.Collections;
using UnityEngine;

public class Lava : MonoBehaviour
{
    //Reference to PlayerScript.cs
    [SerializeField] PlayerScript playerScript;

    [SerializeField] GameObject mobileButtonsCanvas;
    [SerializeField] GameObject lostScreen;

    bool _gameEnded = false;

    void Start()
    {
        //mobileButtonsCanvas.SetActive(true);
        lostScreen.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_gameEnded)
        {
            playerScript.isDead = true;
            playerScript.isAbleToMove = false;
            playerScript.rb2D.velocity = new Vector2(0, playerScript.rb2D.velocity.y);
            StartCoroutine(EndGame());
            _gameEnded = true;
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
        mobileButtonsCanvas.SetActive(false);
        lostScreen.SetActive(true);

    }
}
