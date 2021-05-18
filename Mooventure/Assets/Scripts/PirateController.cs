using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

public class PirateController : MonoBehaviour
{
    public IPirateCommand ActiveCommand;
    public GameObject ProductPrefab;
    private const int NORMAL_WORK_THRESHOLD = 85;
    private const int SLOW_WORK_THRESHOLD = 25;

    // Start is called before the first frame update
    void Start()
    {
        this.ActiveCommand = ScriptableObject.CreateInstance<NoWorkPirateCommand>();
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
        // The work level will be selected at random. Levels have been weighted to 25% slow work,
        // 60% normal work, and 15% fast work.
        Debug.Log(this.gameObject.name + " has been motivated! Loc: (" + this.gameObject.transform.position.x + ", " + this.gameObject.transform.position.y + ")");
        int workSelector = Random.Range(1, 100);
        
        if (workSelector <= SLOW_WORK_THRESHOLD)
        {
            Debug.Log("(" + workSelector + ") Working slow!");
            this.ActiveCommand = Object.Instantiate(ScriptableObject.CreateInstance<SlowWorkerPirateCommand>());
        }
        else if ((workSelector > SLOW_WORK_THRESHOLD) && (workSelector <= NORMAL_WORK_THRESHOLD))
        {
            Debug.Log("(" + workSelector + ") Working normal!");
            this.ActiveCommand = Object.Instantiate(ScriptableObject.CreateInstance<NormalWorkerPirateCommand>());
        }
        else
        {
            Debug.Log("(" + workSelector + ") working fast!");
            this.ActiveCommand = Object.Instantiate(ScriptableObject.CreateInstance<FastWorkerPirateCommand>());
        }
    }
}
