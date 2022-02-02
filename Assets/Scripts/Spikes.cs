using System.Collections;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    //Reference to PlayerScript.cs
    [SerializeField] PlayerScript playerScript;
    [SerializeField] GameObject mobileButtonsCanvas;
    [SerializeField] GameObject lostScreen;

    bool canStrike = true;
    bool _playerDied;

    float time1;
    float time2;

    void Start()
    {
        time1 = 0;
        time2 = Time.realtimeSinceStartup;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerScript.lives > 0 && canStrike)
        {
            playerScript.lives--;
            canStrike = false;
            playerScript.gotSpiked = true;

            time1 = time2;
        }

        if (!_playerDied && playerScript.lives <= 0)
        {
            playerScript.isDead = true;
            playerScript.isAbleToMove = false;
            playerScript.rb2D.velocity = new Vector2(0, playerScript.rb2D.velocity.y);
            StartCoroutine(EndGame());
            _playerDied = true;
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 0f;
        mobileButtonsCanvas.SetActive(false);
        lostScreen.SetActive(true);

    }


    void FixedUpdate()
    {
        time2 = Time.realtimeSinceStartup;
        canStrike = time2 - time1 >= 1;

        //Debug.Log(time1.ToString() + ", " + time2.ToString() + ", " +  canStrike.ToString());
    }
}
