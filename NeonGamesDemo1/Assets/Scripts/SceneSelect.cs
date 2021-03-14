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
                SceneManager.LoadScene("Level2Copy");
                break;

            case "Level3Button":
                SceneManager.LoadScene("Level1Copy");
                break;

            case "Level4Button":
                SceneManager.LoadScene("1-grapplingTutorial-RH");
                break;

            case "Level5Button":
                SceneManager.LoadScene("2-jumpPadTutorial-RH");
                break;

            case "Level6Button":
                SceneManager.LoadScene("3-TowerLevel-RH");
                break;
        }
    }
}
