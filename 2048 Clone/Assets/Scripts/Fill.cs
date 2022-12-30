using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill : MonoBehaviour
{

    public int value;
    [SerializeField]  Text valueDisplay;
    [SerializeField] float speed;

    bool hasCombine;

    Image myImage;


    public void FillValueUpdate(int ValueIn)
    {
        value = ValueIn;
        valueDisplay.text = value.ToString();

        int colorIndex = GetColorIndex(value);
        myImage = GetComponent<Image>();
        myImage.color = GameController.instance.fillColors[colorIndex];


    }

    int GetColorIndex(int valueIn)
    {
        int index = 0;
        while(valueIn != 1)
        {
            index++;
            valueIn /= 2;
        }
        index--;
        return index;

    }

    private void Update()
    {

        if (transform.localPosition != Vector3.zero)
        {

            hasCombine = false;

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);

        }
        else if(hasCombine == false)
        {
            if (transform.parent.GetChild(0) != this.transform)
            {

                Destroy(transform.parent.GetChild(0).gameObject);

            }
            hasCombine = true;
        }
        

    }

    public void Double()
    {
        value *= 2;
        GameController.instance.ScoreUpdate(value);
        valueDisplay.text = value.ToString();

        int colorIndex = GetColorIndex(value);
       
        myImage.color = GameController.instance.fillColors[colorIndex];
        
    }
}
