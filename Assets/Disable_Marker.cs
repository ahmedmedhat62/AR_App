using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Diagnostics;
using TMPro;

public class Disable_Marker : MonoBehaviour, IPointerDownHandler
{
    public string buttonTextTag = "button_5";
    public GameObject modelWithMarker;
    public GameObject modelWithoutMarker;
    private bool isActive = false;
    private GameObject obj;
    public TMP_Text button_text;

    void Start()
    {
        Button btn = GameObject.FindGameObjectWithTag(buttonTextTag).GetComponent<Button>();

        // Find the game object with the "beach" tag
        obj = GameObject.FindGameObjectWithTag("beach");
        if (obj != null)
        {
            // Set the initial state of the object
            isActive = obj.activeSelf;
        }

        // Deactivate the "beach2" model
        modelWithoutMarker.SetActive(false);

        UpdateButtonText();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ToggleObject();
    }

    void ToggleObject()
    {
        if (obj != null)
        {
            if (isActive)
            {
                // Switch to the "Without a marker" state
                isActive = false;
                obj.SetActive(false);
                modelWithMarker.SetActive(false);
                modelWithoutMarker.SetActive(true);
                obj = GameObject.FindGameObjectWithTag("beach2"); // Set the new active object
                isActive = obj.activeSelf;
                UpdateButtonText();
            }
            else
            {
                // Switch to the "Use a marker" state
                isActive = true;
                obj.SetActive(true);
                modelWithMarker.SetActive(true);
                modelWithoutMarker.SetActive(false);
                obj = GameObject.FindGameObjectWithTag("beach"); // Set the new active object
                isActive = obj.activeSelf;
                UpdateButtonText();
            }

            // Deactivate all other objects
            GameObject[] objects = GameObject.FindGameObjectsWithTag("beach");
            foreach (GameObject obj in objects)
            {
                if (obj != this.obj)
                {
                    obj.SetActive(false);
                }
            }

            GameObject[] objects2 = GameObject.FindGameObjectsWithTag("beach2");
            foreach (GameObject obj in objects2)
            {
                if (obj != this.obj)
                {
                    obj.SetActive(false);
                }
            }
        }
    }

    void UpdateButtonText()
    {
        if (button_text != null)
        {
            if (isActive)
            {
                button_text.text = "Use a marker!";
            }
            else
            {
                button_text.text = "Without a marker";
            }
        }
    }
}
