using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carholder : MonoBehaviour
{
    [SerializeField] Button PrevBtn;
    [SerializeField] Button NextBtn;
    [SerializeField] Button UseBtn;
    [SerializeField] GameObject buyPanel;

    int currentCar;
    string ownCarIndex;
    Color redColor = new Color(1f, 0.1f, 0.1f, 1f);
    Color greenColor = new Color(0.5f, 1f, 0.4f, 1f);

    private void Awake()
    {
        ChangeCar(0);

    }

    void ChooseCar(int _index)
    {
        PrevBtn.interactable = (_index != 0);
        NextBtn.interactable = (_index != transform.childCount - 1);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
        
    }

    public void ChangeCar(int _change)
    {
        currentCar += _change;

        ChooseCar(currentCar);
    }
}
