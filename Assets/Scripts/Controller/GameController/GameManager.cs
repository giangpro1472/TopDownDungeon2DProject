using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class TOPICNAME
{
    public const string ENEMYDIED = "EnemyDied";
    public const string ENDWAVE = "EndWave";
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<WeaponController> weaponList;

    public List<Sprite> characterSprites;
    public List<string> characterName;

    [SerializeField]
    private AnimatorOverrideController[] overrideControllers;
    [SerializeField]
    AnimatorOverrider overrider;

    [SerializeField]
    Sprite[] avatars;
    [SerializeField]
    Image avatar;

    [SerializeField] PlayerController player;

    public TextMeshProUGUI goldText;

    public void Set(int value)
    {
        overrider.SetAnimation(overrideControllers[value]);
        avatar.sprite = avatars[value];

    }

    public InventoryController inventory;
    public InventoryUI inventoryUI;
    public CharacterMenuContrroller characterMenu;

    int SaveListCount = 0;

    public int Gold;

    public bool gameOver = false;


    public GameObject gameOverUI;
    public GameObject victoryUI;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance);

        DataController.Instance.LoadDataLocal();
        StartNewGame();
        LoadListItem();
        SceneManager.sceneLoaded += LoadState;
        
    }
    
    public bool BuyWeapon()
    { 
       if (Gold >= weaponList[characterMenu.weaponSelection].weaponScripted.price)
       {
            Debug.Log("Mua "+ weaponList[characterMenu.weaponSelection].weaponScripted.name);
            Gold -= weaponList[characterMenu.weaponSelection].weaponScripted.price;
            goldText.text = Gold.ToString();
            weaponList[characterMenu.weaponSelection].weaponScripted.isInInventory = true;
            Debug.Log("Selection: " + characterMenu.weaponSelection);
            Debug.Log("Current Selection: " + characterMenu.currentWeaponSelection);
            return true;
       }
       return false;
    }

    public void SaveListItem()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            //Debug.Log("Save Item" + inventory.items[i].name + " Amount: " + inventory.items[i].name);
            PlayerPrefs.SetInt("Item" + i, inventory.items[i].ID);
        }

        PlayerPrefs.SetInt("Count", inventory.items.Count);
    }

    public void RemoveItemFromList()
    {
        PlayerPrefs.DeleteKey("Item" + (inventory.items.Count));
        Debug.Log("Delete Key:" +inventory.items.Count);
        for (int i = 0; i < inventory.items.Count; i++)
        {
            Debug.Log("Save Item" + inventory.items[i].name + " Amount: " + inventory.items[i].amount);
            PlayerPrefs.SetInt("Item" + i, inventory.items[i].ID);
        }
        PlayerPrefs.SetInt("Count", inventory.items.Count);
    }

    public void LoadListItem()
    {
        SaveListCount = PlayerPrefs.GetInt("Count");
        for (int i = 0; i < SaveListCount; i++)
        {
            int itemID = PlayerPrefs.GetInt("Item" + i);
            Debug.Log("itemID = " + itemID);
            var items = Resources.LoadAll<Item>(path: "Items").OrderBy(i => i.ID).ToList();
            var foundItem = items.Where(i => i.ID != -1 && i.ID < items.Count).OrderBy(i => i.ID).ToList();
            Item itemToLoad = foundItem.Find(d => d.ID == itemID);

            if (itemToLoad != null)
            {
                Debug.Log("Load Item: " + itemToLoad.ID +" Item Name/Amount: " +itemToLoad.name +"/ " +itemToLoad.amount);
                inventory.items.Add(itemToLoad);
                inventoryUI.UpdateInventory(itemToLoad);
            }
        }
    }

    private void OnApplicationQuit()
    {
        SaveState();
        AudioController.instance.SaveMusic();
    }

    public void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        foreach (WeaponController weapon in weaponList)
        {
            weapon.weaponScripted.isEquiped = false;
            weapon.weaponScripted.isInInventory = false;
        }
    }

    public void SaveState()
    {
        string s = "";

        s += Player.Instance.expController.level.ToString() + "|"; 
        s += Player.Instance.expController.currentValue.ToString() + "|";
        s += Gold.ToString() + "|";
        s += CharacterMenuContrroller.instance.currentCharacterSelection.ToString();    
        PlayerPrefs.SetString("Player", s);
        //Debug.Log("Level|EXP|Gold|CurrentSkin|");
        //Debug.Log(s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        string[] data = PlayerPrefs.GetString("Player").Split('|');
        if (data.Length <= 1)
        {
            Debug.Log("Create New Player");
            player.expController.SetLevel(1);
            Set(0);
            characterMenu.currentCharacterSelection = 0;
            player.transform.position = GameObject.Find("SpawnPoint").transform.position;

            Instantiate(weaponList[0], player.transform.position,
               Quaternion.identity, player.transform);
            characterMenu.currentWeaponSelection = 0;
            weaponList[0].weaponScripted.isEquiped = true;
            weaponList[0].weaponScripted.isInInventory = true;

            
            Gold = 0;
            goldText.text = Gold.ToString();

        }
        else
        {
            foreach (Transform child in Player.Instance.transform)
            {
                Destroy(child.gameObject);
            }
           // Debug.Log("Level|EXP|Gold|CurrentSkin|");
           // Debug.Log(data[0] + "|" + data[1] + "|" + data[2] + "|" + data[3]);
            player.expController.SetLevel(int.Parse(data[0]));
            player.expController.SetExp(float.Parse(data[1]));
            player.transform.position = GameObject.Find("SpawnPoint").transform.position;
            

            Gold = int.Parse(data[2]);
            goldText.text = Gold.ToString();

            int count = 0;
            foreach (WeaponController weapon in weaponList)
            {
                if (weapon.weaponScripted.isEquiped)
                {
                    Instantiate(weapon, player.transform.position, player.transform.rotation, player.transform);
                    characterMenu.weaponSelection = count;
                    characterMenu.currentWeaponSelection = count;
                   //Debug.Log("Current Weapon: " + weapon);
                    //Debug.Log("Weapon number: " + count);
                    break;
                }
                count++;
            }
            Set(int.Parse(data[3]));
            characterMenu.currentCharacterSelection = int.Parse(data[3]);
            //Debug.Log("Current Skin: " + characterMenu.currentCharacterSelection);   
        }
        
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;
            gameOverUI.SetActive(true);
            
            Time.timeScale = 0f;
            SaveState();
        }
    }

    public void Victory()
    {
        if (!gameOver)
        {
            gameOver = true;
            victoryUI.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Victory");
            SaveState();
        }
    }

    public void Restart()
    {
        gameOverUI.SetActive(false);
        gameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReturnEnterGameScene()
    {
        gameOver = false;
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("EnterGameScene");
    }

    public void ReturnEnterGameScene2()
    {
        SceneManager.LoadScene("EnterGameScene");
        gameOver = false;
        Time.timeScale = 1f;
        victoryUI.SetActive(false);
        
    }
}
