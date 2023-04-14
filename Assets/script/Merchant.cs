using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Merchant : MonoBehaviour
{
    public GameObject shop;
    public Button CloseButton;
    public EventSystem eventSys;
    // Start is called before the first frame update
    void Start()
    {
        this.CloseButton.onClick.AddListener(this.CloseShop);
        shop.SetActive(false);
        eventSys.SetSelectedGameObject(this.CloseButton.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Zombie")
        {
            this.shop.SetActive(true);
            Time.timeScale = 0;
        };
    }
    void CloseShop(){
        Time.timeScale = 1;
        shop.SetActive(false);
    }
}