using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int IncreaseAmount = 3;
    private int gateCount = 1;
    public TMPro.TMP_Text sayi;
    public string isim;

    private void Start()
    {
        sayi.text = IncreaseAmount.ToString();
    }
}
