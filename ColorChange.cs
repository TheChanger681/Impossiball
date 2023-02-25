using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private Renderer myRenderer;
    public float timeToChange = 0.1f;
    private float timeSinceChange = 0f;


    // Start is called before the first frame update
    void Start()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        timeSinceChange += Time.deltaTime;

        if(myRenderer != null && timeSinceChange >= timeToChange)
        {
            Color newColor = new Color(
                Random.value,
                Random.value,
                Random.value
                );
            timeSinceChange = 0f;
            myRenderer.material.color = newColor;
        }
       
    }
}
