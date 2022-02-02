using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference to PlayerScript.cs
    [SerializeField] PlayerScript playerScript;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerScript.isAbleToMove)
        {
            if (playerScript.movingRight)
            {
                playerScript.rb2D.velocity = new Vector2(playerScript.moveSpeed, playerScript.rb2D.velocity.y);
            }
            else if (playerScript.movingLeft)
            {
                playerScript.rb2D.velocity = new Vector2(-playerScript.moveSpeed, playerScript.rb2D.velocity.y);
            }
            else
            {
                playerScript.rb2D.velocity = new Vector2(0, playerScript.rb2D.velocity.y);
            }

            if (playerScript.jumping && Mathf.Abs(playerScript.rb2D.velocity.y) < 0.001f)
            {
                playerScript.rb2D.AddForce(new Vector2(playerScript.rb2D.velocity.x, playerScript.jumpingForce), ForceMode2D.Impulse);
                playerScript.jumping = false;
                playerScript.isLanded = false;
            }
        }
    }

    
}
