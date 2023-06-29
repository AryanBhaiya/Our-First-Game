using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    int haveStars, haveDiamonds;
    int carValue = 700;

    [Header("Buy Panel")]
    public Text haveStarText;
    public Text haveDiamondText;
    public Text needmorepaisa;
    public Button BuyCarBtn;
    public Button closePanelBtn;
    public Button buysStar_diamond_btn;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        ChangeCar(0);
    }

    private void Start()
    {
        haveStars = PlayerPrefs.GetInt("totalStar");
        haveDiamonds = PlayerPrefs.GetInt("totalDiamond");
    }

    void ChooseCar(int _index)
    {
        PrevBtn.interactable = (_index != 0);
        NextBtn.interactable = (_index != transform.childCount - 1);
        for (int i = 0; i < transform.childCount; i++)
        {
            string carNo = "CarNo" + i;
            if (i == 0)
            {
                PlayerPrefs.SetInt(carNo, 1);
            }
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }

    }

    public void ChangeCar(int _change)
    {
        currentCar += _change;
        ChooseCar(currentCar);

        ownCarIndex = "CarNo" + currentCar;
        if (PlayerPrefs.GetInt(ownCarIndex) == 1)
        {
            UseBtn.GetComponent<Image>().color = greenColor;
            UseBtn.GetComponentInChildren<Text>().text = "Select";
        }
        else
        {
            UseBtn.GetComponent<Image>().color = redColor;
            UseBtn.GetComponentInChildren<Text>().text = "Buy";
        }

    }

    public void UseBtnClick()
    {
        if (PlayerPrefs.GetInt(ownCarIndex) == 1)
        {
            PlayerPrefs.SetInt("SelectCar", currentCar);
            SceneManager.LoadScene("level");
        }
        else
        {
            buyPanel.SetActive(true);

            haveStarText.text = "You Have " + haveStars + " Stars";
            haveDiamondText.text = "You Have " + haveDiamonds + " Diamonds";

            if (haveStars < carValue)
            {
                int needstarint = carValue - haveStars;
                BuyCarBtn.interactable = false;
                needmorepaisa.text = needstarint + " More Star Needed";

            }


            PrevBtn.interactable = false;
            NextBtn.interactable = false;
            UseBtn.interactable = false;
        }
    }

    public void closePanel()
    {
        buyPanel.SetActive(false);
        PrevBtn.interactable = true;
        NextBtn.interactable = true;
        UseBtn.interactable = true;
    }

    public void buystars()
    {
        haveDiamonds += -1;
        haveStars += -10;
        PlayerPrefs.SetInt("totalStar", haveStars);
        PlayerPrefs.SetInt("totalDiamond", haveDiamonds);
        SetText();
    }

    public void EarnStar()
    {
        haveStars += 100;
        PlayerPrefs.SetInt("totalStar", haveStars);
        SetText();
    }

    void SetText()
    {
        buyPanel.SetActive(true);

        haveStarText.text = "You Have " + haveStars + " Stars";
        haveDiamondText.text = "You Have " + haveDiamonds + " Diamonds";

        if (haveStars < carValue)
        {
            int needstarint = carValue - haveStars;
            BuyCarBtn.interactable = false;
            needmorepaisa.text = needstarint + " More Star Needed";

        }
        if (haveDiamonds < 1)
        {
            buysStar_diamond_btn.interactable = false;
        }
        PrevBtn.interactable = false;
        NextBtn.interactable = false;
        UseBtn.interactable = false;
    }


    public void BuyThisCar()
    {
        PlayerPrefs.SetInt(ownCarIndex, 1);
        haveStars += -carValue;
        PlayerPrefs.SetInt("totalStar", haveStars);
        int currentMinOne = currentMinOne - 1;
        ChangeCar(currentMinOne);
        closePanel();
    }
}
