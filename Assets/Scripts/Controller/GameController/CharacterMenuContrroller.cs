using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterMenuContrroller : MonoBehaviour
{
    public static CharacterMenuContrroller instance;
    public Image weaponUISprite;
    public int weaponSelection = 0;
    public int currentWeaponSelection;

    public Sprite[] buttonImages;
    public Button equipButton;

    public Image characterUISprite;
    public int currentCharacterSelection = 0;
    

    public TextMeshProUGUI totalGold, weaponPriceText, characterName;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void NextWeaponClick(bool right)
    {
        if (right)
        {
            weaponSelection++;
            if (weaponSelection == GameManager.instance.weaponList.Count)
            {
                weaponSelection = 0;
            }
            weaponUISprite.sprite = GameManager.instance.weaponList[weaponSelection].weaponSprite.sprite;
            if (!GameManager.instance.weaponList[weaponSelection].weaponScripted.isInInventory)
            {
                equipButton.image.sprite = buttonImages[0];
                weaponPriceText.text = GameManager.instance.weaponList[weaponSelection].weaponScripted.price.ToString();
            }
            else if (GameManager.instance.weaponList[weaponSelection].weaponScripted.isInInventory)
            {
                equipButton.image.sprite = buttonImages[1];
                weaponPriceText.text = "EQUIP";
            }

            if (GameManager.instance.weaponList[weaponSelection].weaponScripted.isEquiped)
            {
                equipButton.image.sprite = buttonImages[2];
                weaponPriceText.text = "EQUIPED";
            }

        }
        else
        {
            weaponSelection--;

            if (weaponSelection < 0)
            {
                weaponSelection = GameManager.instance.weaponList.Count - 1;
            }
            weaponUISprite.sprite = GameManager.instance.weaponList[weaponSelection].weaponSprite.sprite;
            if (!GameManager.instance.weaponList[weaponSelection].weaponScripted.isInInventory)
            {
                equipButton.image.sprite = buttonImages[0];
                weaponPriceText.text = GameManager.instance.weaponList[weaponSelection].weaponScripted.price.ToString();
            }
            else if (GameManager.instance.weaponList[weaponSelection].weaponScripted.isInInventory)
            {
                equipButton.image.sprite = buttonImages[1];
                weaponPriceText.text = "EQUIP";
            }

            if (GameManager.instance.weaponList[weaponSelection].weaponScripted.isEquiped)
            {
                equipButton.image.sprite = buttonImages[2];
                weaponPriceText.text = "EQUIPED";
            }
        }

    }

    public void EquipWeapon()
    {
        if (GameManager.instance.weaponList[weaponSelection].weaponScripted.isEquiped)
        {
            return;
        }

        if (!GameManager.instance.weaponList[weaponSelection].weaponScripted.isInInventory)
        {
            if (GameManager.instance.BuyWeapon())
            {
                UpdateMenu();
            }
        }
        else
        {
            foreach (Transform child in Player.Instance.transform)
            {
                if (child != null)
                {
                    child.GetComponent<WeaponController>().weaponScripted.isEquiped = false;
                    GameObject.Destroy(child.gameObject);
                }
            }
            Instantiate(GameManager.instance.weaponList[weaponSelection], Player.Instance.transform.position,
                 Player.Instance.transform.rotation, Player.Instance.transform);

            GameManager.instance.weaponList[weaponSelection].weaponScripted.isEquiped = true;
            currentWeaponSelection = weaponSelection;
            Debug.Log("Equip weapon: " + GameManager.instance.weaponList[weaponSelection].weaponScripted.name);
            Debug.Log("Current weapon: " + currentWeaponSelection);
            UpdateMenu();
        }

    }

    public void NextCharacterClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;
            if (currentCharacterSelection == GameManager.instance.characterSprites.Count)
            {
                currentCharacterSelection = 0;
            }
            OnSelectionChanged();
        }
        else
        {
            currentCharacterSelection--;
            if (currentCharacterSelection < 0)
            {
                currentCharacterSelection = GameManager.instance.characterSprites.Count - 1;
            }
            OnSelectionChanged();
        }
    }

    public void OnSelectionChanged()
    {
        GameManager.instance.Set(currentCharacterSelection);
        UpdateMenu();

    }

    public void UpdateMenu()
    {
        weaponUISprite.sprite = GameManager.instance.weaponList[weaponSelection].weaponSprite.sprite;
        if (!GameManager.instance.weaponList[weaponSelection].weaponScripted.isInInventory)
        {
            equipButton.image.sprite = buttonImages[0];
            weaponPriceText.text = GameManager.instance.weaponList[weaponSelection].weaponScripted.price.ToString();
        }
        else if (GameManager.instance.weaponList[weaponSelection].weaponScripted.isInInventory)
        {
            equipButton.image.sprite = buttonImages[1];
            weaponPriceText.text = "EQUIP";
        }

        if(GameManager.instance.weaponList[weaponSelection].weaponScripted.isEquiped)
        {
            equipButton.image.sprite = buttonImages[2];
            weaponPriceText.text = "EQUIPED";
        }
        totalGold.text = GameManager.instance.Gold.ToString();
        characterUISprite.sprite = GameManager.instance.characterSprites[currentCharacterSelection];
        characterName.text = GameManager.instance.characterName[currentCharacterSelection];
    }

}
