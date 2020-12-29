using UnityEngine;

public class MenuScript : MonoBehaviour {
	public GameObject[] images = new GameObject[3]; //logo, backB, BG
	public GameObject[] menus = new GameObject[2];
	int cur = -1;
	bool goBack = false;

	void Start()
	{
		Set(0, true, false, 1.1f);
		images[0].transform.position = new Vector2();
	}
	void Update()
	{
		switch (cur) //Logo -> (Have/Need), Have, Need
		{
			case 0:
				if (CheckInput(true))
				{
					Set(-1);
					menus[0].SetActive(true);
				}
				break;
			case 1:
				if (goBack)
				{
					Set(-1);
					menus[1].SetActive(false);
					menus[0].SetActive(true);
					goBack = false;
				}
				break;
		}
	}
	public void PressedButton(int id)
	{
		switch (id)
		{
			case -1:
				goBack = true;
				break;
			case 0:
				Set(1, false, true, 1.4f);
				menus[1].SetActive(true);
				menus[0].SetActive(false);
				break;
		}
	}
	void Set(int current, bool logoB = false, bool backB = false, float bgSize = 1.2f)
	{
		cur = current;
		images[0].SetActive(logoB);
		images[1].SetActive(backB);
		images[2].transform.localScale = new Vector2(1, bgSize);
	}
	bool CheckInput(bool debug = false)
	{
		if (debug)
		{
			return Input.GetMouseButtonDown(0);
		} else
		{
			if (Input.touchCount > 0)
			{
				return Input.touches[Input.touches.Length - 1].deltaTime < 0.6f;
			}
			else return false;
		}
	}
}