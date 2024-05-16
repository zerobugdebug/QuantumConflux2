using UnityEngine;

[CreateAssetMenu(fileName = "CardModel", menuName = "QC2/CardModel")]
public class CardModel : ScriptableObject
{
    public string cardName;
    public int power;
    public int damage;
    public string ability;
    public string clan;
}