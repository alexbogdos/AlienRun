using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    //Reference to PlayerScript.cs
    [SerializeField] PlayerScript playerScript;

    [SerializeField] Sprite heartFull;
    [SerializeField] Sprite heartHalf;
    [SerializeField] Sprite heartEmpty;

    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = heartFull;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.lives == 2)
        {
            image.sprite = heartFull;
        }
        else if (playerScript.lives == 1)
        {
            image.sprite = heartHalf;
        }
        else
        {
            image.sprite = heartEmpty;
        }
    }
}
