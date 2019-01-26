using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    private Texture2D whiteTex; // The texture who will be displayed during the fade in
    private bool fade = false; // Boolean to check if we are in fade transition
    private float alph = 0; // The alpha value (0=Transparent, 1=Opaque)
    private float fadeSpeed = 0.7f; // The fade speed

    public Camera camera; // the player camera
    public Text text; // The text for the interaction

    private GameObject[] highlightTaggedComponents;

    private void Start()
    {
        // Get the list of all components who can be examinated
        highlightTaggedComponents = GameObject.FindGameObjectsWithTag("Highlight");

        // Init the black texture
        whiteTex = new Texture2D(1, 1);
        whiteTex.SetPixel(0, 0, new Color(0, 0, 0, 0));
        whiteTex.Apply();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DisableUnusedHalo();
        EnableActionInRaycast();

        if (fade)
        {
            if (alph < 1)
            {
                FadeIn();
            } else
            {
                SceneManager.LoadScene("2dLevel"); // Load the new scene when the fade is over
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            fade = true; // Init the fade transition
        }
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), whiteTex);
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var go in highlightTaggedComponents)
        {
            if (((Behaviour)go.GetComponent("Halo")).enabled)
            {
                text.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.enabled = false;
    }

    private void DisableUnusedHalo()
    {
        foreach (var go in highlightTaggedComponents)
        {
            Behaviour behaviour = (Behaviour)go.GetComponent("Halo");
            if (behaviour.enabled)
            {
                behaviour.enabled = false;
            }
        }
    }

    private void EnableActionInRaycast()
    {
        RaycastHit hit;
        Ray r = new Ray(camera.transform.position, camera.transform.forward);

        if (Physics.Raycast(r, out hit))
        {
            Transform t = hit.transform;
            if (t.gameObject.tag == "Highlight")
            {
                ((Behaviour)t.gameObject.GetComponent("Halo")).enabled = true;
            }
        }
    }

    // The fade transition
    void FadeIn()
    {
        alph += Time.deltaTime * fadeSpeed; // Update the alpha value
        if (alph < 0) { alph = 0f; }
        whiteTex.SetPixel(0, 0, new Color(255, 255, 255, alph)); // Update the alpha on the texture
        whiteTex.Apply(); // Apply the texture
    }
}
