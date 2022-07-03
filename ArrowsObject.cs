using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArrowsObject : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject cloneArrow;
    [SerializeField] float xRange;
    [SerializeField] float yRange;
    public float forwardForce = 2000f;
    private float xPos;
    private float zPos;
    public float sidewayForce = 500f;
    int ArrowCount = 1;
    public TMPro.TMP_Text count;

    private bool IsEndGame;

    public List<GameObject> arrows = new List<GameObject>();

    private void Start()
    {
        count.text = ArrowCount.ToString();
    }

    void FixedUpdate()
    {
        if (IsEndGame) return;

        rb.MovePosition(rb.position + Vector3.forward * forwardForce * Time.fixedDeltaTime);

        if (Input.GetKey("d"))
        {
            rb.MovePosition(rb.position + Vector3.right * sidewayForce * Time.fixedDeltaTime);
        }

        if (Input.GetKey("a"))
        {
            rb.MovePosition(rb.position - Vector3.right * sidewayForce * Time.fixedDeltaTime);
        }

        xPos = Mathf.Clamp(rb.position.x, -1.5f, 1.5f);
        zPos = Mathf.Clamp(rb.position.z, -0.5f, 330f);

        rb.position = new Vector3(xPos, rb.position.y, zPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "EndGate")
        {
            IsEndGame = true;
        }
        if (other.transform.tag=="Gate")
        {
            //Debug.Log(other.GetComponent<Gate>().IncreaseAmount);
            
            if(other.GetComponent<Gate>().IncreaseAmount >= 0)
            {
                for (int i = 0; i < other.GetComponent<Gate>().IncreaseAmount; i++)
                {
                    ArrowCount++;
                    GameObject arrowClone = Instantiate(cloneArrow, transform);
                    arrowClone.transform.localPosition = new Vector3(Random.Range(-xRange, xRange), Random.Range(0, yRange), 0f);
                    arrows.Add(arrowClone);
                }
                
            }
            else
            {
                for (int i = 0; i < Mathf.Abs(other.GetComponent<Gate>().IncreaseAmount); i++)
                {
                    //Debug.Log("second for");
                    ArrowCount--;
                    GameObject dummy = arrows[0];
                    arrows.RemoveAt(0);
                    Destroy(dummy);
                }
            }

            count.text = ArrowCount.ToString();            
        }
    }
}
