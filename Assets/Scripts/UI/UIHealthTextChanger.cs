using TMPro;
using UnityEngine;


public class UIHealthTextChanger : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    public void SetHpText(int value)
    {
        if (text == null)
            return;
        text.text = value.ToString();
    }
}
