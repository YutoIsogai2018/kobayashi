using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject m_player;
    //private GameObject 
    private Camera m_camera;
    float m_scroll;

    // Start is called before the first frame update
    void Start()
    {
        m_camera = GetComponent<Camera>();
        transform.position = new Vector3(m_player.transform.position.x, m_player.transform.position.y, m_player.transform.position.z - 10);
    }

    // Update is called once per frame
    void Update()
    {
        // スクロールでカメラのサイズを変える
        m_scroll -= Input.GetAxis("Mouse ScrollWheel");

        transform.position = new Vector3(m_player.transform.position.x, m_player.transform.position.y, m_player.transform.position.z - 10);

        //if (m_camera.orthographicSize > 0)
        {
            m_camera.orthographicSize = (m_scroll * 20.0f) + 8.0f;
        }
        if (m_camera.orthographicSize < 8)
        {
            m_camera.orthographicSize = 8;
        }

        //transform.Translate(0, 0, m_scroll);
        //float view = m_camera.fieldOfView - scroll;

        //m_camera.fieldOfView = Mathf.Clamp(value: view, min: 0.1f, max: 45f);
    }
}
