using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuBack;
    public GameObject Story;
    public GameObject Setting;
    public GameObject CheckMusic;
    public GameObject CheckSound;

    void Start()
    {
        CheckMusic.SetActive(true);
        CheckSound.SetActive(true);
    }

    public void BtnStart()
    {
        SceneManager.LoadScene("Player");
    }
    public void BtnExit()
    {
        Application.Quit();
    }
    public void BtnStory()
    {
        MenuBack.GetComponent<Animator>().SetTrigger("M_Close");
        Invoke("OpenStory", 1.5f);
    }
    public void BtnSetting()
    {
        MenuBack.GetComponent<Animator>().SetTrigger("M_Close");
        Invoke("OpenSetting", 1.5f);
    }

    void OpenStory()
    {
        Story.SetActive(true);
        Story.GetComponent<Animator>().SetTrigger("M_Open");
    }
    void OpenSetting()
    {
        Setting.SetActive(true);
        Setting.GetComponent<Animator>().SetTrigger("M_Open");
    }
    void OpenMenuBack()
    {
        MenuBack.GetComponent<Animator>().SetTrigger("M_Open");
    }
    public void BtnMusic()
    {
        CheckMusic.SetActive(!CheckMusic.activeInHierarchy);
    }
    public void BtnSound()
    {
        CheckSound.SetActive(!CheckMusic.activeInHierarchy);
    }
    public void BtnBack(int num)
    {
        switch (num)
        {
            case 0:
                Story.GetComponent<Animator>().SetTrigger("M_Close");
                Invoke("OpenMenuBack", 1.5f);
                break;
            case 1:
                Setting.GetComponent<Animator>().SetTrigger("M_Close");
                Invoke("OpenMenuBack", 1.5f);
                break;
        }
    }
}
