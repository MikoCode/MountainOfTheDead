using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public float potionsNumber;
    private PlayerHealthManager pH;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI potionsNumberText;
    public TextMeshProUGUI teaNumberText;
    public GameObject buttonHealth;
    public GameObject buttonDamage;
    public GameObject buttonSpeed;
    public SceneManager sceneManager;

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
        healthText.text = ("Health ") + pH.currentHealth + ("/") + pH.startHealth;
        teaNumberText.text = ("") + TeaNumber;
    }


    
}
