using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    [SerializeField] internal PlayerInput playerInput;
    [SerializeField] internal PlayerMovement playerMovement;
    [SerializeField] internal PlayerAnimation playerAnimation;

    [SerializeField] internal float moveSpeed = 8;
    [SerializeField] internal float jumpingForce = 120f;

    internal Transform transfrm;
    internal Rigidbody2D rb2D;

    internal bool movingRight;
    internal bool movingLeft;
    internal bool jumping;
    internal bool isLanded;
    internal bool isDead;
    internal bool isAbleToMove = true;
    internal bool gotSpiked;

    internal int lives = 2;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1f;
        transfrm = GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    

    
}
