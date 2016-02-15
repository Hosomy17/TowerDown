using UnityEngine;
using System.Collections;

public class ManagerCamera : MonoBehaviour
{
    public PixelBoy pixelBoy;
    public Shaker shaker;

    void Update()
    {
        if (pixelBoy.w < 720)
            pixelBoy.w += 8;
    }

    public void DamageEffect()
    {
        pixelBoy.w = 20;
        shaker.Shake(20,0.5f);
    }
}
