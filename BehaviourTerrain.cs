using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTerrain : MonoBehaviour
{
    private GameObject behaviourTerrain;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick_Up"))
        {
            ChangeTerrainScale();
        }
    }

    void ChangeTerrainScale()
    {
        behaviourTerrain.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
