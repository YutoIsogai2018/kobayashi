using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    GameObject m_player;
    Rigidbody2D m_rigid2D;
    Vector2 m_vel;
    Vector3 m_clickPosition;
    Vector3 m_playerPosition;
    bool m_shootStar;
    string m_starName;
    bool m_endStar;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("player");
        this.m_rigid2D = GetComponent<Rigidbody2D>();
        m_playerPosition = GameObject.Find("star").transform.position;
        m_rigid2D.gravityScale = 0.0f;
        m_shootStar = false;
        m_endStar = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 星の名前を取得
        m_starName = m_player.GetComponent<PlayerController>().StarName();

        // まだ飛んでいなかったら
        if (m_shootStar == false)
        {
            // プレイヤーの位置と同じだったら
            if (this.transform.position == m_player.transform.position)
            {
                // 重力を付与
                this.m_rigid2D.gravityScale = 0.5f;

                // クリックしたら
                if (Input.GetMouseButtonUp(0))
                {
                    float dx;
                    float dy;
                    float angle;

                    m_clickPosition = Input.mousePosition;
                    //m_playerPosition = GameObject.Find("star").transform.position;
                    m_playerPosition = GameObject.Find("" + m_starName).transform.position;
                    //m_playerPosition = player.GetComponent<UnityChan.UnityChanControlScriptWithRgidBody>().PlayerPos();

                    m_clickPosition.z = 10.0f;
                    Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(m_clickPosition);

                    dx = worldMousePos.x - m_playerPosition.x;
                    dy = worldMousePos.y - m_playerPosition.y;
                    angle = Mathf.Atan2(dy, dx);

                    m_vel.x = Mathf.Cos(angle);
                    m_vel.y = Mathf.Sin(angle);

                    // クリックした方向に飛ぶ
                    this.m_rigid2D.velocity = m_vel * 20.0f;

                    m_shootStar = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // すでに飛んだ星だったら
        if (m_shootStar == true)
        {
            // 位置が星の位置と違ったら
            if (this.transform.position != m_player.transform.position)
            {
                m_endStar = true;
            }
        }
    }

    public Vector3 Position()
    {
        return transform.position;
    }

    //public bool ShootStar()
    //{
    //    return m_shootStar;
    //}

    public bool EndStar()
    {
        return m_endStar;
    }
}
