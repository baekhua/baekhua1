using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [HideInInspector] public ItemData _itemData;
    [SerializeField] GameObject _itemImg;
    [SerializeField] GameObject _actionBtn;
    [SerializeField] GameObject _dropBtn;
    Image _image;
    bool _clickBtn = false;
    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    public void Init(ItemData itemData, Sprite sprite)
    {
        Debug.Log("Init ¿Ï·á.");
        _itemData = itemData;
        _image.sprite = sprite;
        Debug.Log(_itemData._name);
        Debug.Log(sprite.name);
    }
    public void OnButton()
    {
        if(_clickBtn == true)
        {
            return;
        }
        GameObject temp = GameObject.Find("ImagePanel");
        GameObject itemImage = Instantiate(_itemImg, temp.transform);

        GameObject temp2 = GameObject.Find("ButtonPanel");
        GameObject actButton = Instantiate(_actionBtn, temp2.transform);
        GameObject dropButton = Instantiate(_dropBtn, temp2.transform);
        _clickBtn = true;
    }
    public void ActionBtn()
    {
        ItemDataManager data = GameObject.Find("LoadData").GetComponent<ItemDataManager>();
        GameObject temp = data.ItemSpawn();

        GameObject player = GameObject.Find("Player_mecanim_prefab");
        Debug.Log($"temp°¡ ¹®Á¨°¡? : {temp.name}");
        Debug.Log($"player°¡ ¹®Á¨°¡? : {player}");
        temp.transform.SetParent(player.transform);
        temp.transform.localPosition = Vector3.zero;
        temp.transform.localRotation = Quaternion.identity;
        data.SetItemGameObject(temp);
        data.UseItem(temp.GetComponent<ItemType>().Type);
        _clickBtn = false;

        GenericSingleton<Inventory>.Instance.GetComponent<Inventory>().RemoveItem(gameObject);
        //Destroy(gameObject);
        gameObject.SetActive(false);
        Debug.Log(gameObject.name);
    }
    public void DropBtn()
    {
        ItemDataManager data = GameObject.Find("LoadData").GetComponent<ItemDataManager>();
        GameObject player = GameObject.Find("Player_mecanim_prefab");
        GameObject temp = data.ItemSpawn();
        Debug.Log($"temp°¡ ¹®Á¨°¡? : {temp.name}");
        Debug.Log($"player°¡ ¹®Á¨°¡? : {player}");
        temp.transform.position = player.transform.position + player.transform.forward * 0.5f;
        _clickBtn = false;

        GenericSingleton<Inventory>.Instance.GetComponent<Inventory>().RemoveItem(gameObject);
        //Destroy(gameObject);
        gameObject.SetActive(false);
        Debug.Log(gameObject.name);
    }
}
