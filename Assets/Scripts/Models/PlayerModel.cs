using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public int Health { get; set; }
    public int Charges { get; set; }
    public List<CardModel> Deck { get; set; }
    public List<CardModel> Hand { get; set; }
}