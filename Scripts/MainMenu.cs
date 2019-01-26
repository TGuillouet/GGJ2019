using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject option;
    public GameObject home;

    public void PlayClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionClick()
    {
        home.SetActive(false);
        option.SetActive(true);
    }

    public void BackClick()
    {
        option.SetActive(false);
        home.SetActive(true);
    }

    public void Start()
    {
        option.SetActive(false);
        home.SetActive(true);
    }
}
