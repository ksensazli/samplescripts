using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class throwBall : MonoBehaviour
{
    private Vector3 m_ballInitialPosition;
    private Vector2 m_startPos, m_endPos, m_direction;
    private float m_touchTimeStart, m_touchTimeFinish, m_timeInterval;
    private Rigidbody rb;
    public GameObject Player;
    [SerializeField] private float throwForceInXAndY = 1f;
    [SerializeField] private float throwForceInZ = 50f;

    private void Start()
    {
        rb = GetComponent<Rigidbody> ();
        m_ballInitialPosition = transform.position;
    }

    private void Update () 
    {
        if (Input.GetMouseButtonDown(0)) {
            m_touchTimeStart = Time.time;
            m_startPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0)) {
            m_touchTimeFinish = Time.time;
            m_timeInterval = m_touchTimeFinish - m_touchTimeStart;
            m_endPos = Input.mousePosition;
            m_direction = m_startPos - m_endPos;
            if(rb.position.z <= -8f)
            {
                rb.AddForce (- m_direction.x * throwForceInXAndY, - m_direction.y * throwForceInXAndY, throwForceInZ / m_timeInterval);
            }
            if(rb.position.z > -8f)
            {
                Player.transform.DOJump(new Vector3(-4.98f, 1.61f, -0.95f), 2.5f, 1, 0.4f, false);
            }
        }
        
    }
}
