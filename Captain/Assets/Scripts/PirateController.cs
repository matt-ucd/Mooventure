﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

public class PirateController : MonoBehaviour
{
    public IPirateCommand ActiveCommand;
    public GameObject ProductPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.ActiveCommand = ScriptableObject.CreateInstance<SlowWorkerPirateCommand>();
    }

    // Update is called once per frame
    void Update()
    {
        var working = this.ActiveCommand.Execute(this.gameObject, this.ProductPrefab);

        this.gameObject.GetComponent<Animator>().SetBool("Exhausted", !working);
    }

    //Has received motivation. A likely source is from on of the Captain's morale inducements.
    public void Motivate()
    {
        // generate a random integer 1, 2, or 3
        int randomWork = Random.Range(1,4);
        
        if (randomWork == 1)
        {
            this.ActiveCommand = Object.Instantiate(ScriptableObject.CreateInstance<SlowWorkerPirateCommand>());
        }
        else if (randomWork == 2)
        {
            this.ActiveCommand = Object.Instantiate(ScriptableObject.CreateInstance<NormalWorkerPirateCommand>());
        }
        else if (randomWork == 3)
        {
            this.ActiveCommand = Object.Instantiate(ScriptableObject.CreateInstance<FastWorkerPirateCommand>());
        }
        
    }
}
