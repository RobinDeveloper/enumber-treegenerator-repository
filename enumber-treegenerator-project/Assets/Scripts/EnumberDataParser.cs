using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class EnumberDataParser
{
    private string jsonLocation = @"C:\Users\robin\Documents\Artez\Design by information\Enumbers.json";
    private string jsonValue = "";
    
    public EnumberDataParser()
    {
        
    }

    public List<List<Molecule>> GetMolecules()
    {
        List<List<Molecule>> moleculesDays = new List<List<Molecule>>();
        
        using (StreamReader streamReader = new StreamReader(jsonLocation))
        {
            jsonValue = streamReader.ReadToEnd();
        }
        List<MoleculeJSON> moleculeJsons = JsonConvert.DeserializeObject<List<MoleculeJSON>>(jsonValue);

        for (int i = 0; i < moleculeJsons.Count; i++)
        {
            List<Molecule> moleculesForDay = new List<Molecule>();
            for (int j = 0; j < moleculeJsons[i].Enumber.Length; j++)
            {
                moleculesForDay.Add(new Molecule(moleculeJsons[i].Enumber[j]));
            }
            moleculesDays.Add(moleculesForDay);
        }
        
        return moleculesDays;
    }
}
