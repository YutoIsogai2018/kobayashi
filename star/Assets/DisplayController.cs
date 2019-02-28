using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{
    GameObject m_gameOver;
    GameObject m_clear;

    // Start is called before the first frame update
    void Start()
    {
        m_gameOver = GameObject.Find("GameOverText");
        m_gameOver.GetComponent<Text>().enabled = false;
        m_clear = GameObject.Find("GameClearText");
        m_clear.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayGameOver()
    {
        m_gameOver.GetComponent<Text>().enabled = true;
    }

    public void DisplayGameClear()
    {
        m_clear.GetComponent<Text>().enabled = true;
    }
}
