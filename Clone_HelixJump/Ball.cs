using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject splash;
    [SerializeField] private float jumpForce;
    private GameManager gm;
    public Text levelToText;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        levelToText.text = SceneManager.GetActiveScene().name.ToString();
    }

    private void OnCollisionEnter(Collision other) 
    {
        rb.AddForce(Vector3.up * jumpForce);

        GameObject splashObj = Instantiate(splash, transform.position - new Vector3(0, 0.22f, 0f), transform.rotation);
        splashObj.transform.SetParent(other.gameObject.transform);
        Destroy(splashObj, 1);

        string materialName = other.gameObject.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Unsafe Color (Instance)") {
            gm.restartGame();
        }

        if(materialName == "Last Ring (Instance)")
        {
            gm.nextLevel();
        }

        if(materialName == "Finish (Instance)")
        {
            gm.endGame();
        }
    }
}
