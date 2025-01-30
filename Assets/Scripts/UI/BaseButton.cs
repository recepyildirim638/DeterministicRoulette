using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => ButtonOnClick());
        BaseStart();
    }



    public void SetButtonInteractive(bool buttonInteractive) => button.interactable = buttonInteractive;

    public abstract void ButtonOnClick();

    public virtual void BaseStart()
    {

    }
}
