using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerControlScript : MonoBehaviour
{
    public ParticleSystem partSys;
    public GameObject screen;
    public GameObject heat;

    public void Temp(bool up)
    {
        float delta = up ? .2f : -.2f;
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(new Color(partSys.colorOverLifetime.color.gradient.colorKeys[0].color.r + delta, 0, partSys.colorOverLifetime.color.gradient.colorKeys[0].color.b - delta, 1.0f), 0.0f), new GradientColorKey(new Color32(8,233,250, 255), .6f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        var col = partSys.colorOverLifetime;
        col.color = grad;
    }

    public void Pressure(bool up)
    {
        var m = partSys.main;
        m.startSpeedMultiplier += up ? 10f : -10f;
        var em = partSys.emission;
        em.rateOverTimeMultiplier += up ? 10f : -10f;
        if (m.startSpeedMultiplier < 0) m.startSpeedMultiplier = 0;
        if (em.rateOverTimeMultiplier < 0) em.rateOverTimeMultiplier = 0;
    }

    public void ToggleScreen()
    {
        screen.SetActive(!screen.activeSelf);
    }

    public void ToggleHeat()
    {
        heat.SetActive(!heat.activeSelf);
    }
}
