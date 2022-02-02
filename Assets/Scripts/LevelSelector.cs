using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] Sprite LockedImage; 
    public int index;

    public bool unLocked;

    public void GoToLevel()
    {
        SceneManager.LoadScene(index);
    }
}
