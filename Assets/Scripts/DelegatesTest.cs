using Codice.Client.Common.GameUI;
using System;
using System.Globalization;
using UnityEngine;

public class DelegatesTest : MonoBehaviour
{
    private float money = 20.0f;
    public delegate string Formatter(float number);
   
    public string EuEuroFormatter(float amount){
        return $"{amount.ToString("#0.00")} €";
    }

    public string UsDollarFormatter(float amount) {
        return $"${amount.ToString("#,0.00")}";
    }

    private void Start()
    {
        Formatter myFormat = EuEuroFormatter;
        myFormat(money); // 20.00 €
        myFormat = UsDollarFormatter;
        myFormat(money); // $20.00
    }

    private void PrintTestLogs(Formatter myFormat)
    {
        Debug.Log(myFormat(money));
        Debug.Log(myFormat(1));
        Debug.Log(myFormat(0));
        Debug.Log(myFormat(1234.99f));
        Debug.Log(myFormat(1234567.99f));
    }
}
