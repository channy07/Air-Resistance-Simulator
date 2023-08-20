using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public TMP_InputField velocity;
    public TMP_InputField airDensity;
    public TMP_InputField radius;
    public TMP_InputField mass;
    public TMP_InputField gravityA;
    public TMP_InputField height;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("velocity"))
        {
            velocity.text = PlayerPrefs.GetFloat("velocity").ToString("F2");
        }

        if (PlayerPrefs.HasKey("airDensity"))
        {
            airDensity.text = PlayerPrefs.GetFloat("airDensity").ToString("F2");
        }

        if (PlayerPrefs.HasKey("radius"))
        {
            radius.text = PlayerPrefs.GetFloat("radius").ToString("F2");
        }

        if (PlayerPrefs.HasKey("mass"))
        {
            mass.text = PlayerPrefs.GetFloat("mass").ToString("F2");
        }

        if (PlayerPrefs.HasKey("gravityA"))
        {
            gravityA.text = PlayerPrefs.GetFloat("gravityA").ToString("F2");
        }

        if (PlayerPrefs.HasKey("height"))
        {
            height.text = PlayerPrefs.GetFloat("height").ToString("F2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputVelocity(string text)
    {
        if (text != "")
        {
            PlayerPrefs.SetFloat("velocity", float.Parse(text));
            PlayerPrefs.Save();
        }
    }

    public void InputAirDensity(string text)
    {
        if(text != "")
        {
            PlayerPrefs.SetFloat("airDensity", float.Parse(text));
            PlayerPrefs.Save();
        }
    }

    public void InputRadius(string text)
    {
        if (text != "")
        {
            PlayerPrefs.SetFloat("radius", float.Parse(text));
            PlayerPrefs.Save();
        }
    }

    public void InputMass(string text)
    {
        if (text != ""  )
        {
            PlayerPrefs.SetFloat("mass", float.Parse(text));
            PlayerPrefs.Save();
        }
    }

    public void InputGravityA(string text)
    {
        if (text != "")
        {
            PlayerPrefs.SetFloat("gravityA", float.Parse(text));
            PlayerPrefs.Save();
        }
    }

    public void InputHeight(string text)
    {
        if (text != "")
        {
            PlayerPrefs.SetFloat("height", float.Parse(text));
            PlayerPrefs.Save();
        }
    }

    public void onClickPrevious()
    {
        SceneManager.LoadScene("Menu");
    }
}
