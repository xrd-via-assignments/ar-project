using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class changeColor : MonoBehaviour
{
    public Material carMaterial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeColor()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (name == "Yellow")
        {
            carMaterial.color = new Color(255 / 255f, 190 / 255f, 0 / 255f);
        }
        else if (name == "White")
        {
            carMaterial.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
        }
        else if (name == "Black")
        {
            carMaterial.color = new Color(51 / 255f, 51 / 255f, 51 / 255f);
        }
        else if (name == "Red")
        {
            carMaterial.color = new Color(248 / 255f, 81 / 255f, 81 / 255f);
        }
        else if (name == "Blue")
        {
            carMaterial.color = new Color(36 / 255f, 110 / 255f, 245 / 255f);
        }
    }
}
