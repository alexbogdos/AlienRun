using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //Reference to PlayerScript.cs
    //[SerializeField] PlayerScript playerScript;

    [SerializeField] Transform pos1, pos2;
    [SerializeField] float speed;
    [SerializeField] Transform startPos;
    [SerializeField] float distance = 15;

    private PlayerScript playerScript;
    private Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = SceneLoader.FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>();
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x == pos1.position.x && transform.position.y == pos1.position.y)
        {
            nextPos = pos2.position;
        }
        if (transform.position.x == pos2.position.x && transform.position.y == pos2.position.y)
        {
            nextPos = pos1.position;
        }

        bool isNearPos1 = Mathf.Abs(playerScript.transform.position.x - pos1.position.x) <= distance;
        bool isNearPos2 = Mathf.Abs(playerScript.transform.position.x - pos2.position.x) <= distance;

        if (isNearPos1 || isNearPos2)
        {
        transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);    
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
