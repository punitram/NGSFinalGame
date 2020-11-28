using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectCoins : MonoBehaviour
{
    public int points = 0;
    public GUIStyle customGuiStyle;
    private void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 1000, 500), "Score: " + points, customGuiStyle);
    }
}
