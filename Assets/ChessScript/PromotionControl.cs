using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PromotionControl : MonoBehaviour
{
	public ChessScript ChessScript;
	public GameObject GetCanvas;
	public List<GameObject> PromotionBcontrol;
	void Start()
	{
		ChessScript = GetComponent<ChessScript>();
		Promotionbuttoninitialize();
	}
	void Update()
	{
		Promotionbuttonactive();
	}
	public void Promotionbuttoninitialize()
	{
		GetCanvas = ChessScript.ALine[0].transform.parent.gameObject;
		PromotionBcontrol.Add(GetCanvas.transform.GetChild(68).gameObject);
		PromotionBcontrol.Add(GetCanvas.transform.GetChild(69).gameObject);
		PromotionBcontrol.Add(GetCanvas.transform.GetChild(70).gameObject);
		PromotionBcontrol.Add(GetCanvas.transform.GetChild(71).gameObject);
		PromotionBcontrol.Add(GetCanvas.transform.GetChild(64).gameObject);
		PromotionBcontrol.Add(GetCanvas.transform.GetChild(65).gameObject);
		PromotionBcontrol.Add(GetCanvas.transform.GetChild(66).gameObject);
		PromotionBcontrol.Add(GetCanvas.transform.GetChild(67).gameObject);
		for (int a = 0; a <= 7; a++)
		{
			PromotionBcontrol[a].SetActive(false);
		}
	}
	public void Promotionbuttonactive()
	{
		for (int a = 0; a <= 7; a++)
		{
			if (ChessScript.Everysquare[a][7].text == "白兵")
			{
				for (int b = 0; b <= 3; b++)
				{
					PromotionBcontrol[b].SetActive(true);
					if (PromotionBcontrol[0].activeSelf == true)
					{
						for (int c = 0; c <= 7; c++)
						{
							ChessScript.ALine[c].enabled = false;
							ChessScript.BLine[c].enabled = false;
							ChessScript.CLine[c].enabled = false;
							ChessScript.DLine[c].enabled = false;
							ChessScript.ELine[c].enabled = false;
							ChessScript.FLine[c].enabled = false;
							ChessScript.GLine[c].enabled = false;
							ChessScript.HLine[c].enabled = false;
						}
					}
					ChessScript.Promotionenablebuttonswitch = true;
					ChessScript.Whitemoving = true;
				}
			}
			if (ChessScript.Everysquare[a][0].text == "黑兵")
			{
				for (int b = 4; b <= 7; b++)
				{
					PromotionBcontrol[b].SetActive(true);
					if (PromotionBcontrol[4].activeSelf == true)
					{
						for (int c = 0; c <= 7; c++)
						{
							ChessScript.ALine[c].enabled = false;
							ChessScript.BLine[c].enabled = false;
							ChessScript.CLine[c].enabled = false;
							ChessScript.DLine[c].enabled = false;
							ChessScript.ELine[c].enabled = false;
							ChessScript.FLine[c].enabled = false;
							ChessScript.GLine[c].enabled = false;
							ChessScript.HLine[c].enabled = false;
						}
					}
					ChessScript.Promotionenablebuttonswitch = true;
					ChessScript.Whitemoving = false;
				}
			}
			if (PromotionBcontrol[0].activeSelf == false && PromotionBcontrol[4].activeSelf == false && ChessScript.Promotionenablebuttonswitch == true)
			{
				ChessScript.ALine[a].enabled = true;
				ChessScript.BLine[a].enabled = true;
				ChessScript.CLine[a].enabled = true;
				ChessScript.DLine[a].enabled = true;
				ChessScript.ELine[a].enabled = true;
				ChessScript.FLine[a].enabled = true;
				ChessScript.GLine[a].enabled = true;
				ChessScript.HLine[a].enabled = true;
				ChessScript.Promotionenablebuttonswitch = false;
			}
		}
	}
	public void Promote(int x)
	{
		for (int a = 0; a <= 7; a++)
		{
			if (ChessScript.Everysquare[a][7].text == "白兵")
			{
				ChessScript.Everysquare[a][7].text = ChessScript.PromotionText[x].text;
				ChessScript.Whitemoving = false;
			}
			if (ChessScript.Everysquare[a][0].text == "黑兵")
			{
				ChessScript.Everysquare[a][0].text = ChessScript.PromotionText[x].text;
				ChessScript.Whitemoving = true;
			}
			PromotionBcontrol[a].SetActive(false);
		}
	}
}