using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject retry;
    [SerializeField] private GameObject quit;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject padel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale>0)
            {
                Time.timeScale = 0;
                retry.SetActive(true);
                quit.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                retry.SetActive(false);
                quit.SetActive(false);
            }
        }
    }

    public void Retry()
    {
        ball.transform.position = new Vector3(0,3,0);
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, -5, 1);
        WavesManager.instance.level = 1;
        WavesManager.instance.CreateLevel(BricksManager.instance.bricksObject);
        retry.SetActive(false);
        quit.SetActive(false);
        Time.timeScale = 1;
        padel.transform.position =  new Vector3(0, 1, 0);
        ScoreManager.instance.AddScore(-ScoreManager.instance.score);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
