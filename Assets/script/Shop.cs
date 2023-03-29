using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Button StrengthButton;
    public Text StrengthPriceText;
    private int StrengthPrice;
    public Button HealthButton;
    public Text HealthPriceText;
    private int HealthPrice;
    public Button HealButton;
    public Text HealPriceText;
    private int HealPrice;
    public Button RangeButton;
    public Text RangePriceText;
    private int RangePrice;
    public Button SpeedButton;
    public Text SpeedPriceText;
    private int SpeedPrice;
    private int basePrice = 15;
    public GameObject Zombie;
    private Zombie character;
    public Text MoneyAmmount;

    // Start is called before the first frame update
    void Start()
    {
        this.HealPrice = this.basePrice * 2;
        this.HealthPrice = this.basePrice;
        this.StrengthPrice = this.basePrice;
        this.SpeedPrice = this.basePrice;
        this.RangePrice = this.basePrice;
        this.character = Zombie.GetComponent<Zombie>();
        this.StrengthButton.onClick.AddListener(StrengthPurchase);
        this.HealButton.onClick.AddListener(HealPurchase);
        this.HealthButton.onClick.AddListener(HealthPurchase);
        this.SpeedButton.onClick.AddListener(SpeedPurchase);
        this.RangeButton.onClick.AddListener(RangePurchase); 
    }

    // Update is called once per frame
    void Update()
    {
        this.SpeedPriceText.text = this.SpeedPrice.ToString();
        this.HealthPriceText.text = this.HealthPrice.ToString();
        this.StrengthPriceText.text = this.StrengthPrice.ToString();
        this.RangePriceText.text = this.RangePrice.ToString();
        this.HealPriceText.text = this.HealPrice.ToString();
        this.MoneyAmmount.text = "Purse : " + this.character.purse.ToString();
    }

    void StrengthPurchase()
    {
        if (this.character.purse >= this.StrengthPrice)
        {
            this.character.damage += 1;
            this.character.purse -= this.StrengthPrice;
            this.StrengthPrice += 5;
        }
    }
    
    void HealthPurchase()
    {
        if (this.character.purse >= this.HealthPrice)
        {
            this.character.maxHP += 10;
            this.character.purse -= this.HealthPrice;
            this.HealthPrice += 5;
        }
    }

    void SpeedPurchase()
    {
        if (this.character.purse >= this.SpeedPrice)
        {
            this.character.speed += 0.1f;
            this.character.purse -= this.StrengthPrice;
            this.SpeedPrice += 10;
        }
    }

    void HealPurchase()
    {
        if (this.character.purse >= this.HealPrice)
        {
            this.character.currentHP = this.character.maxHP;
            this.character.purse -= this.HealPrice;
            this.HealPrice += this.basePrice * 2;
        }
    }

    void RangePurchase()
    {
        if (this.character.purse >= this.RangePrice)
        {
            this.character.attackRange += 1;
            this.character.purse -= this.RangePrice;
            this.RangePrice += 5;
        }
    }
}