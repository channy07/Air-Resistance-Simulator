using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static UnityEditor.ShaderData;

public class MovementManager : MonoBehaviour
{
    public TMP_Text textX;
    public TMP_Text textY;
    public TMP_Text textVx;
    public TMP_Text textVy;
    public TMP_Text RForce;
    public TMP_Text time;
    public TMP_Text shootButtonText;

    public Renderer Background;

    private float t = 0;
    public float Cd = 0.47f;

    private bool progressing = false;

    // Start is called before the first frame update
    void Start()
    {
        textY.text = "y : " + getY().ToString("F3");
        textVx.text = "Vx : " + getVx().ToString("F3");
        textVy.text = "Vy : " + getVy().ToString("F3");
    }

    // Update is called once per frame
    void Update()
    {
        if(progressing)
        {
            t += Time.deltaTime;

            textX.text = "x : " + getX().ToString("F3");
            textY.text = "y : " + getY().ToString("F3");
            textVx.text = "Vx : " + getVx().ToString("F3");
            textVy.text = "Vy : " + getVy().ToString("F3");
            //RForce.text
            time.text = "t : " + t.ToString("F3");

            Background.material.SetTextureOffset("_MainTex", new Vector2(getX(),getY()));
        }
        else
        {

        }
    }

    public float getVx()
    {
        double Vx;

        double v0 = PlayerPrefs.GetFloat("velocity");
        double airDensity = PlayerPrefs.GetFloat("airDensity");
        double r = PlayerPrefs.GetFloat("radius");
        double m = PlayerPrefs.GetFloat("mass");

        double k = 0.5 * airDensity * Cd * r*r * Math.PI;

        Vx = v0 / (1 + v0 * k * t / m);

        return Convert.ToSingle(Vx);
    }

    public float getVy()
    {
        double Vy;

        double airDensity = PlayerPrefs.GetFloat("airDensity");
        double r = PlayerPrefs.GetFloat("radius");
        double m = PlayerPrefs.GetFloat("mass");
        double g = PlayerPrefs.GetFloat("gravityA");

        double k = 0.5 * airDensity * Cd * r * r * Math.PI;
        double Vt = Math.Sqrt(g * m / k);

        Vy = -Vt * Math.Tanh(Math.Sqrt(k*g/m) * t);

        return Convert.ToSingle(Vy);
    }

    public float getX()
    {
        double x;

        double v0 = PlayerPrefs.GetFloat("velocity");
        double airDensity = PlayerPrefs.GetFloat("airDensity");
        double r = PlayerPrefs.GetFloat("radius");
        double m = PlayerPrefs.GetFloat("mass");

        double k = 0.5 * airDensity * Cd * r * r * Math.PI;
        
        x = m / k * Math.Log(1 + v0 * k * t / m);

        return Convert.ToSingle(x);
    }

    public float getY() 
    {
        double y;

        double airDensity = PlayerPrefs.GetFloat("airDensity");
        double r = PlayerPrefs.GetFloat("radius");
        double m = PlayerPrefs.GetFloat("mass");
        double g = PlayerPrefs.GetFloat("gravityA");
        double y0 = PlayerPrefs.GetFloat("height");

        double k = 0.5 * airDensity * Cd * r * r * Math.PI;
        double Vt = Math.Sqrt(g * m / k);

        y = y0 - Vt * Math.Sqrt(m) * Math.Log(Math.Cosh(Math.Sqrt(k * g / m) * t)) / Math.Sqrt(g*k);

        return Convert.ToSingle(y);
    }

    public void OnClickShootButton()
    {
        if(progressing) 
        {
            progressing = false;

            shootButtonText.text = "SHOOT";
            t = 0;
        }
        else
        {
            progressing = true;

            shootButtonText.text = "STOP";
        }
    }
}
