using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Reference to PlayerScript.cs
    [SerializeField] PlayerScript playerScript;

    public void ChangeMoveRight()
    {
        playerScript.movingRight = !playerScript.movingRight;
    }
    public void ChangeMoveLeft()
    {   
        playerScript.movingLeft = !playerScript.movingLeft;
    }
    public void ChangeJump()
    {
        if (Mathf.Abs(playerScript.rb2D.velocity.y) < 0.001f)
            playerScript.jumping = true;
    }
}
