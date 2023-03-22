using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Rotate_l : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Button yourButton;
    public float rotateSpeed = 10f;
    private bool isPressed = false;

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
                beach.transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
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
