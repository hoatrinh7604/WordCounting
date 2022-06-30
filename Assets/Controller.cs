using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject inputField;
    [SerializeField] Button addButton;
    [SerializeField] Button continueButton;
    [SerializeField] TextMeshProUGUI amountText;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] WordCount wordCount;

    [SerializeField] GameObject listFieldParent;

    private List<GameObject> list = new List<GameObject>();
    private List<double> listInt = new List<double>();
    private int amount = 0;
    private double result = 0;

    public string CURRENCY_FORMAT = "#,##0.00";
    public NumberFormatInfo NFI = new NumberFormatInfo { NumberDecimalSeparator = ",", NumberGroupSeparator = "." };

    string phrase = "";
    //Singleton
    public static Controller Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    private void Start()
    {
        Clear();
        //addButton.onClick.AddListener(AddField);
    }

    public void UpdateResult()
    {
        resultText.text = result.ToString();
    }

    public void UpdateAmount()
    {
        amountText.text = amount.ToString();
    }

    public void OnValueChanged(int index)
    { 
        phrase = inputField.GetComponent<TMP_InputField>().text;
        Sum();
    }

    private void Sum()
    {
        result = wordCount.Count(phrase);
        UpdateResult();
    }

    public void Clear()
    {
        amount = 0;
        result = 0;
        UpdateAmount();
        UpdateResult();
        inputField.GetComponent<TMP_InputField>().text = "";
        continueButton.interactable = false;
        addButton.interactable = true;
        //for (int i = 0; i < listFieldParent.transform.childCount; i++)
        //{
        //    Destroy(listFieldParent.transform.GetChild(i).gameObject);
        //}
    }

    public void Quit()
    {
        Clear();
        Application.Quit();
    }
}
