using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerDown : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Floor1Border;
    public GameObject Floor2Border;
    void Start()
    { 
        for (int i = 0; i < Floor2Border.transform.childCount; i++)
        {
            // GameObject child = Floor2Border.transform.GetChild(i).gameObject;
            // child.SetActive(false);
        } 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player" || other.gameObject.tag =="Enemy"){
            other.gameObject.layer = LayerMask.NameToLayer("Layer 1");
            other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Layer 1";

        }
        if(other.gameObject.tag == "Player"){
            for (int i = 0; i < Floor1Border.transform.childCount; i++)
            {
                GameObject child = Floor1Border.transform.GetChild(i).gameObject;
                child.SetActive(true);
                //Do something with child
            }
            for (int i = 0; i < Floor2Border.transform.childCount; i++)
            {
                GameObject child = Floor2Border.transform.GetChild(i).gameObject;
                // child.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    
    void Update()
    {
        
    }
}
