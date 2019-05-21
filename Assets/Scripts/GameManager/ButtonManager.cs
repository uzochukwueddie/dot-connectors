using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private int levelPassed;

    public Button[] objs;

    [SerializeField]
    private Sprite spriteImage;

    [SerializeField]
    private Sprite currentLevelIcon;

    void Start()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");

        int i = 1;
        foreach (Button button in objs)
        {
            if (levelPassed < i)
            {
                button.interactable = false;
                Text levelText = button.GetComponentInChildren<Text>();
                levelText.color = Color.white;
            }
            else
            {
                button.GetComponent<Image>().sprite = spriteImage;
                button.interactable = true;
            }
            i += 1;

            if (levelPassed < i && button.interactable == true)
            {
                button.GetComponent<Image>().sprite = currentLevelIcon;
            }
        }
    }

    public void levelToLoad(int level)
    {
        ButtonPressedSound.instance.PlayButtonSound();
        SceneManager.LoadScene(level);
    }

    public void HomeButton () {
        ButtonPressedSound.instance.PlayButtonSound();
        StartCoroutine(WaitBeforeReplay());
    }

    IEnumerator WaitBeforeReplay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main Menu Scene");
    }
}
