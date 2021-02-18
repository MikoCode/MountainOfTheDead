using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public float potionsNumber;
    private PlayerHealthManager pH;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI potionsNumberText;
    public TextMeshProUGUI teaNumberText;
    public Button buttonHealth;
    public Button buttonDamage;

    public float TeaNumber;
    // Start is called before the first frame update
    void Start()
    {
        potionsNumber = 0;
        TeaNumber = 1;
        
        pH = GameObject.Find("Player").GetComponent<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        potionsNumberText.text = ("") + potionsNumber;
        healthText.text = ("Health ") + pH.currentHealth;
        teaNumberText.text = ("") + TeaNumber;
    }
}
