using System;
using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class Molecule
{
    [SerializeField] private string m_Enumber;
    public string ENumber
    {
        get => m_Enumber;
        set => ENumber = value;
    }
    
    public Molecule(string _enumber)
    {
        m_Enumber = _enumber;
    }
}

public class MoleculeJSON
{
    [JsonProperty("Date")]
    public string Date { get; set; }
    [JsonProperty("Enumber")]
    public string[] Enumber { get; set; }
}