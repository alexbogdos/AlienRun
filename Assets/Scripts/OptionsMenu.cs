using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Toggle toggle;

    bool toggleValue = true;
    string toggleState = "ON";

    void Start()
    {
        if (!PlayerPrefs.HasKey("PtPr Toggle"))
        {
            PlayerPrefs.SetString("PtPr Toggle", "ON");
            toggle.isOn = true;
        }
        else
        {
            string prefsValue = PlayerPrefs.GetString("PtPr Toggle");
            if (prefsValue.Equals("ON"))
            {
                toggle.isOn = true;
            }else
            {
                toggle.isOn = false;
            }
        }

        
    }

    public void ChangeToggleValue()
    {
        if (toggleValue)
        {
            toggleValue = false;
            toggleState = "OFF";
        }else
        {
            toggleValue = true;
            toggleState = "ON";
        }
        PlayerPrefs.SetString("PtPr Toggle", toggleState);
    }

}
