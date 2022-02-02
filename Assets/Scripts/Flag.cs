using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    //Reference to PlayerScript.cs
    [SerializeField] PlayerScript playerScript;

    [SerializeField] GameObject mobileButtonsCanvas;
    [SerializeField] GameObject wonScreen;
    [SerializeField] ParticleSystem particlesWon;

    bool _gameWon = false;
    private Animator _animator;

    void Start()
    {
        wonScreen.SetActive(false);
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_gameWon)
        {
            playerScript.isAbleToMove = false;
            
            _animator.enabled = true;
            _animator.Play("FlagRise");
            StartCoroutine(WonGame());
            _gameWon = true;
        }
    }
    IEnumerator WonGame()
    {
        yield return new WaitForSeconds(0.2f);
        playerScript.rb2D.velocity = new Vector2(0, playerScript.rb2D.velocity.y);

        yield return new WaitForSeconds(0.8f);
        _animator.enabled = false;
        particlesWon.Play();

        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        mobileButtonsCanvas.SetActive(false);
        wonScreen.SetActive(true);
    }
}
