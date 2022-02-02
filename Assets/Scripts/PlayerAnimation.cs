using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] PlayerScript playerScript;
    [SerializeField] Animator headHUDAnim; 
    [SerializeField] Sprite usedSprite;
    [SerializeField] Sprite jumpingSprite;
    [SerializeField] ParticleSystem particlesBlood;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool _ableToPlayDead = true;
    private bool _ableToShowHurt = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = playerScript.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerScript.rb2D.velocity == new Vector2(0,0))
        {
            animator.enabled = true;
            animator.Play("PlayerIdle");
        }
        else if(playerScript.movingRight)
        {
            animator.enabled = true;
            animator.Play("WalkingRight");
        }
        else if(playerScript.movingLeft)
        {
            animator.enabled = true;
            animator.Play("WalkingLeft");
        }
        else if (!playerScript.isLanded || playerScript.rb2D.velocity.y < -1f)
        {
            animator.enabled = false;
            spriteRenderer.sprite = jumpingSprite;
        }
        else
        {
            animator.enabled = false;
            spriteRenderer.sprite = usedSprite;
        }

        if (playerScript.isDead && _ableToPlayDead)
        {
            OozeBlood();
            _ableToPlayDead = false;
        }

        if (playerScript.gotSpiked && _ableToShowHurt)
        {
            headHUDAnim.SetTrigger("Aouts");
            _ableToShowHurt = false;
        }
    }


    internal void OozeBlood()
    {
        particlesBlood.Play();
    }
}
