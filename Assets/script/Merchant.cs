using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject shop;
    // Start is called before the first frame update
    void Start()
    {
        shop.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Zombie")
        {
            shop.SetActive(true);
        };
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Zombie")
        {
            shop.SetActive(false);
        }
    }
}