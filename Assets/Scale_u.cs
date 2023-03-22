using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Scale_u : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Button yourButton;
    private bool isPressed = false;
    //public vector3 scalechange;
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    void Update()
    {
        if (isPressed)
        {
            GameObject beach = GameObject.FindGameObjectWithTag("beach");
            if (beach != null)
            {
                
                beach.transform.localScale += new Vector3(0.01f,0.01f,0.01f);
            }
            else
            {
                UnityEngine.Debug.LogWarning("No GameObject with tag 'beach' found!");
            }
        }
    }

    void TaskOnClick()
    {
        UnityEngine.Debug.Log("You have clicked the button!");
    }
}
