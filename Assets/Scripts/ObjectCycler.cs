using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCycler : MonoBehaviour
{
    //public List<GameObject> objects = new List<GameObject>();
    public GameObject[] objectList = new GameObject[5];
    public KeyCode key;
    public GameObject buttonText;

    private int currentIndex;
    private int previousIndex;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject gameObject in objectList) {
            gameObject.SetActive(false);
        }

        objectList[0].SetActive(true);
        buttonText.GetComponent<Text>().text = objectList[1].name;

        currentIndex = 0;
        previousIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key)) {
            SwitchModel();
        }
    }

    public void SwitchModel() {

        if (currentIndex == objectList.Length - 1) {
            currentIndex = 0;
            buttonText.GetComponent<Text>().text = objectList[1].name;
        }
        else {
            currentIndex++;

            if (currentIndex == objectList.Length - 1) {
                buttonText.GetComponent<Text>().text = objectList[0].name;
            }
            else {
                buttonText.GetComponent<Text>().text = objectList[currentIndex + 1].name;
            }
        }
        
        objectList[previousIndex].SetActive(false);
        objectList[currentIndex].SetActive(true);
        previousIndex = currentIndex;
    }
}
