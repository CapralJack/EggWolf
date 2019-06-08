using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public Game game;
    public GameObject[] egg;
    public int spawn;
    public int step = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Steps());
    }

    // Update is called once per frame
    void Update()
    {
     if (step==5 
		&&
		game.playerPos == spawn)
		{
			egg[4].SetActive(false);
			Destroy(this.gameObject);
			game.Count();
			
		}
    }

    IEnumerator Steps()
    {
        if (step == 0)
        {
            egg[step].SetActive(true);
        }
        else if (step == 10)
        {
            Destroy(this.gameObject);
        }
        else
        {
            egg[step].SetActive(true);
            egg[step-1].SetActive(false);
			if (step == 5)
			{
				game.Crash();
			}
			else
			{
				game.Step();
			}
        }
        step++;
        yield return new WaitForSeconds(game.time);
        StartCoroutine(Steps());
    }

}
