using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMessageManager : MonoBehaviour
{
    public static SystemMessageManager Instance;

    public GameObject SystemMessageTextObject;
    public Text SystemMessageText;
    [Range(1, 5)] public float showTime = 1f;
    IEnumerator OnSystemMessageText_Coroutine;

    private void Awake()
    {
        Instance = this;
    }

    //Print System Message Text
    public void SendSytemMessageText(string _message)
    {
        if (OnSystemMessageText_Coroutine != null)
            StopCoroutine(OnSystemMessageText_Coroutine);

        OnSystemMessageText_Coroutine = OnSystemMessageText(_message);
        StartCoroutine(OnSystemMessageText_Coroutine);
    }

    public IEnumerator OnSystemMessageText(string _message)
    {
        SystemMessageTextObject.SetActive(true);
        SystemMessageText.text = _message;
        yield return new WaitForSeconds(showTime);
        SystemMessageTextObject.SetActive(false);
    }
}
