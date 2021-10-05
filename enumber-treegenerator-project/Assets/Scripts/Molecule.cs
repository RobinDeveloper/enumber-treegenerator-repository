using System;
using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class Molecule
{
    [SerializeField] private string m_Enumber;
    [SerializeField] private Int32 m_Amount;

    public string ENumber
    {
        get => m_Enumber;
        set => ENumber = value;
    }

    public Int32 Amount
    {
        get => m_Amount;
        set => m_Amount = value;
    }

    public Molecule(string _enumber, Int32 _amount)
    {
        m_Enumber = _enumber;
        m_Amount = _amount;
    }
}

public class MoleculeJSON
{
    [JsonProperty("Date")]
    public string Date { get; set; }
    [JsonProperty("Enumber")]
    public string[] Enumber { get; set; }
}