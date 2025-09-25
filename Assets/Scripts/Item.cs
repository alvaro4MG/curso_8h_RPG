using UnityEngine;

[CreateAssetMenu]       //Aparece si le damos al Create, encima de Folder
public class Item : ScriptableObject       //MonoBehaviour implica que tiene que ser sí o sí componente de un gameObject
{
    //public string Name => name;   //Para coger directamente el nombre del Item
    public string Name;
}
