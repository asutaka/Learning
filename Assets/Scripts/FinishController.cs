using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishController : MonoBehaviour {

    private Dictionary<int, bool> dicDone;
    public Text txtWin;
    public Text txtScore;
    public Text txtTime;
    public Button btnNextScene;
    private int count;
    private float timeLeft = 180;
    private bool hasCompleted = false;

	// Use this for initialization
	void Start () {
        dicDone = new Dictionary<int, bool>();
        dicDone.Add(1,false);
        dicDone.Add(2, false);
        dicDone.Add(3, false);
        dicDone.Add(4, false);
        dicDone.Add(5, false);
        dicDone.Add(6, false);

        btnNextScene.gameObject.SetActive(false);
        btnNextScene.onClick.AddListener(delegate () { this.ButtonClicked(); });
    }
    private void ButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
        if (!hasCompleted)
        {
            timeLeft -= Time.deltaTime;
            TimeSpan t = TimeSpan.FromSeconds(timeLeft);

            string strTime = string.Format("{0:D2}:{1:D2}:{2:D3}",
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
            txtTime.text = timeLeft <= 0 ? "00:00:000" : strTime;
            if (timeLeft <= 0)
            {
                txtWin.text = "You Lose!";
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("1"))
        {
            var val = !dicDone[1];
            dicDone[1] = val;
            other.gameObject.SetActive(false);
            count++;
        }
        if (other.gameObject.CompareTag("2"))
        {
            var val = !dicDone[2];
            dicDone[2] = val;
            other.gameObject.SetActive(false);
            count++;
        }
        if(other.gameObject.CompareTag("3"))
        {
            var val = !dicDone[3];
            dicDone[3] = val;
            other.gameObject.SetActive(false);
            count++;
        }
        if(other.gameObject.CompareTag("4"))
        {
            var val = !dicDone[4];
            dicDone[4] = val;
            other.gameObject.SetActive(false);
            count++;
        }
        if(other.gameObject.CompareTag("5"))
        {
            var val = !dicDone[5];
            dicDone[5] = val;
            other.gameObject.SetActive(false);
            count++;
        }
        if(other.gameObject.CompareTag("6"))
        {
            var val = !dicDone[6];
            dicDone[6] = val;
            other.gameObject.SetActive(false);
            count++;
        }
        checkComplete();
        txtScore.text = count.ToString();
    }
    private void checkComplete()
    {
        bool isComplete = true;
        foreach (var item in dicDone.Values)
        {
            if (!item)
            {
                isComplete = false;
                break;
            }
        }
        if (isComplete)
        {
            txtWin.text = "You Win!";
            hasCompleted = true;
            btnNextScene.gameObject.SetActive(true);
        }
    }
}
