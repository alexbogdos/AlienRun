using UnityEngine;

public class VFXToggle : MonoBehaviour
{
    [SerializeField]
    GameObject volume;

    void Awake()
    {
        if (PlayerPrefs.HasKey("PtPr Toggle"))
        {
            string toggleValue = PlayerPrefs.GetString("PtPr Toggle");
            if (toggleValue.Equals("ON"))
            {
                volume.SetActive(true);
            }else
            {
                volume.SetActive(false);
            }
        }
    }
}
