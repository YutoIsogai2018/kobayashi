using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject m_star;
    Vector3 m_starPos;
    string m_starName;
    bool m_changeFlag;
    //bool m_shootStar;
    bool m_endStar;

    public GameObject m_prefab;
    public GameObject m_prefab2;

    // Start is called before the first frame update
    void Start()
    {
        // 初期の星を設定
        this.m_star = GameObject.Find("star");

        // 星の生成
        for (int i = 1; i < 50; i++)
        {
            int x = Random.Range(-50, 50);
            int y = Random.Range(-5, 90);
            Instantiate(m_prefab, new Vector3(x, y, 0), Quaternion.identity);
            Instantiate(m_prefab2, new Vector3(x, y, 0), Quaternion.identity);
            m_prefab.name = "" + i;
            m_prefab2.name = "dark" + i;
        }

        // 星の名前を初期の星にする
        m_starName = "star";
        m_changeFlag = false;
        //m_shootStar = false;
        m_endStar = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ぶつかったら
        if (m_changeFlag == true)
        {
            // 現在の星を保存しておく
            GameObject copyStar = m_star;
            // 名前を当たった星の名前に変える
            m_star = GameObject.Find("" + m_starName);
            // if文に入らないようにする
            m_changeFlag = false;
            // フラグを取得
            m_endStar = m_star.GetComponent<StarController>().EndStar();

            // すでに使った星だったら
            if (m_endStar == true)
            {
                // 保存した星に戻す
                m_star = copyStar;
            }
        }
        //m_shootStar = m_star.GetComponent<StarController>().ShootStar();

        // 星の位置を取得
        m_starPos = m_star.transform.position;
        // プレイヤーの位置を星の位置にする
        transform.position = m_starPos;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // 星の数だけ回す
        for (int i = 1; i < 100; i++)
        {
            // 当たった星と名前が一致したら
            if (col.transform.name == i + "(Clone)")
            {
                // 当たった星の名前を取得
                m_starName = i + "(Clone)";
                m_changeFlag = true;
            }
        }
        
        // テキスト表示
        if (col.transform.name == "gameOverLine")
        {
            GameObject.Find("Canvas").GetComponent<DisplayController>().DisplayGameOver();
        }
        if (col.transform.name == "clearLine")
        {
            GameObject.Find("Canvas").GetComponent<DisplayController>().DisplayGameClear();
        }
    }

    public string StarName()
    {
        return m_starName;
    }

    public bool ChangeFlag()
    {
        return m_changeFlag;
    }
}
