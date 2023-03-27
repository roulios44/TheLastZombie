using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerUp : MonoBehaviour
{
    public GameObject Floor1Border;
    public GameObject Floor2Border;
    // Start is called before the first frame update
    void Start()
    {
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag=="Player" || other.gameObject.tag =="Enemy"){
            Debug.Log(other.gameObject.tag);
            other.gameObject.layer = LayerMask.NameToLayer("Layer 2");
        }
        other.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Layer 2");
        for (int i = 0; i < Floor1Border.transform.childCount; i++)
        {
            GameObject child = Floor1Border.transform.GetChild(i).gameObject;
            child.SetActive(false);
            //Do something with child
        }
                for (int i = 0; i < Floor2Border.transform.childCount; i++)
        {
            GameObject child = Floor2Border.transform.GetChild(i).gameObject;
            child.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
