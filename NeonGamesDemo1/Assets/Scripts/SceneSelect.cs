using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public void selectScene()
    {
        switch(this.gameObject.name)
        {
            case "Level1Button":
                SceneManager.LoadScene("SampleSceneCopy");
                break;

            case "Level2Button":
                SceneManager.LoadScene("Level1Copy");
                break;

            case "Level3Button":
                SceneManager.LoadScene("Level2Copy");
                break;
        }
    }
}
