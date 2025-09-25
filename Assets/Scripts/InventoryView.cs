using UnityEngine;
using TMPro;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private TMP_Text _prefab;


    private void OnInventoryModified(){

        /*while(transform.childCount > 0){
            var trans = transform.GetChild(0);
            trans.SetParent(null);
            Destroy(trans);
        }*/

        for (int i = transform.childCount - 1; i >= 0; i--) {
            Destroy(transform.GetChild(i).gameObject);
        }

        foreach(var keyValuePair in _inventory.Wallet){
            var entry = Instantiate(_prefab, transform);    //emparentamos directamente al instanciar
            //entry.transform.SetParent(transform);

            entry.gameObject.SetActive(true);
            entry.transform.localScale = Vector3.one;
            entry.text = keyValuePair.Key.Name + ": " + keyValuePair.Value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _prefab.transform.SetParent(null);
        _prefab.gameObject.SetActive(false);
        
        OnInventoryModified();
        _inventory.OnModified += OnInventoryModified;   //nos registramos a un evento
    }

    private void OnDestroy(){
        _inventory.OnModified -= OnInventoryModified;
    }

}
