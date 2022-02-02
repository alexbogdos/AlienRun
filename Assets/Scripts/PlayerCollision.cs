using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //Reference to PlayerScript.cs
    [SerializeField] PlayerScript playerScript;
    [SerializeField] BoxCollider2D boxCollider2D_MID;
    [SerializeField] BoxCollider2D boxCollider2D_BTM;

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
        if (collision.gameObject.CompareTag("Platform"))
         {
             playerScript.isAbleToMove = false;
         }  
     }

     private void OnTriggerExit2D(Collider2D collision)
     {
         playerScript.isAbleToMove = true;
     }
 */

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            playerScript.jumping = false;
            playerScript.transform.parent = collision.gameObject.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            playerScript.transform.parent = null;
        }
    }
}
