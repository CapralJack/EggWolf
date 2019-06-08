using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public GameObject zero;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public int playerPos;

    //[HideInInspector]
    public Transform egg;
    //[HideInInspector]
    public GameObject[] egg1;
    //[HideInInspector]
    public GameObject[] egg2;
   // [HideInInspector]
    public GameObject[] egg3;
   // [HideInInspector]
    public GameObject[] egg4;

    public float time = 1;
	
	public int count;
	public int hp;

	public TextMesh counter;

	public GameObject Hp1;
	public GameObject Hp2;
	public GameObject Hp3;
	
	public GameObject PressStart;

	public AudioSource SoundStep;
	public AudioSource SoundCrash;
	public AudioSource SoundCount;

	public bool isPlayMode = false;



	void Start()
    {
		//isPlayMode = true;
        egg = GameObject.Find("Spawn1").transform;
        egg1 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++)
        {
            egg1[i] = egg.Find(i.ToString()).gameObject;
         //   egg1[i].SetActive(false);

        }

        egg = GameObject.Find("Spawn2").transform;
        egg2 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++)
        {
            egg2[i] = egg.Find(i.ToString()).gameObject;
        }

        egg = GameObject.Find("Spawn3").transform;
        egg3 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++)
        {
            egg3[i] = egg.Find(i.ToString()).gameObject;
        }

        egg = GameObject.Find("Spawn4").transform;
        egg4 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++)
        {
            egg4[i] = egg.Find(i.ToString()).gameObject;
        }

        player1.SetActive(true);
        
		this.ActiveOff();
		
		//StartCoroutine(Timer());
    }

	private void ActiveOff()
	{



		player2.SetActive(false);
		player3.SetActive(false);
		player4.SetActive(false);


		foreach (GameObject eg in egg1)
		{
			eg.SetActive(false);
		}

		foreach (GameObject eg in egg2)
		{
			eg.SetActive(false);
		}

		foreach (GameObject eg in egg3)
		{
			eg.SetActive(false);
		}

		foreach (GameObject eg in egg4)
		{
			eg.SetActive(false);
		}

		Hp1.SetActive(false);
		Hp2.SetActive(false);
		Hp3.SetActive(false);
	}


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
			playerPos = 1;
            player1.SetActive(true);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
			playerPos = 3;
            player1.SetActive(false);
            player2.SetActive(true);
            player3.SetActive(false);
            player4.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
			playerPos = 2;
            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(true);
            player4.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
			playerPos = 4;
            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(true);
        }

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (isPlayMode)
			{
				StopGame();
			}
			else
			{
				StartGame();
			}
		}

	}
    IEnumerator Timer()
    {
        //GameObject egg = Instantiate(zero);

        Egg comp = Instantiate(zero).AddComponent<Egg>();
        comp.game = this.GetComponent<Game>();
        comp.spawn = Random.Range(1, 5);
        if(comp.spawn == 1)
        {
            comp.egg = egg1;
        }
        if (comp.spawn == 2)
        {
            comp.egg = egg2;
        }
        if (comp.spawn == 3)
        {
            comp.egg = egg3;
        }
        if (comp.spawn == 4)
        {
            comp.egg = egg4;
        }

        yield return new WaitForSeconds(time);
        StartCoroutine(Timer());
    }
	public void Step()
	{
		SoundStep.Play();
	}

	public void Count()
	{
		count++;
		counter.text = count.ToString();
		SoundCount.Play();
	}

	public void Crash()
	{
		hp++;
		SoundCrash.Play();
		if (hp == 1)
		{
			this.Hp1.SetActive(true);
		}
		else if (hp == 2)
		{
			this.Hp2.SetActive(true);
		}
		else if (hp == 3)
		{
			this.Hp3.SetActive(true);
		}
		else if (hp > 3)
		{
			StopGame();
		}
	}

	void StartGame()
	{

		this.PressStart.SetActive(false);
		this.playerPos = 1;
		hp = 0;
		player1.SetActive(true);
						
		counter.text = (count=0).ToString();


		this.ActiveOff();

		StartCoroutine(Timer());

	}

	void StopGame()
	{
		this.isPlayMode = false;

		StopAllCoroutines();
		ActiveOff();
		player1.SetActive(false);
		
		this.PressStart.SetActive(true);


		GameObject [] eggsArray = GameObject.FindGameObjectsWithTag("zero");
		foreach (GameObject eg in eggsArray)
		{
			if (eg.name == "Egg(Clone)")
			{
				Destroy(eg);
			}
		}

	}

}
