using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boardcalculation : MonoBehaviour
{
	public ChessScript ChessScript;
	public string pin;
	public string[,] incheckcalculation;
	public bool incheckcalculationinitialize;
	public void Start()
	{
		ChessScript = GetComponent<ChessScript>();
		incheckcalculation = new string[8, 8];
		incheckcalculationinitialize = false;
		pin = "pinned";
		for (int a = 0; a <= 7; a++)
		{
			for (int b = 0; b <= 7; b++)
			{
				incheckcalculation[a, b] = "";
			}
		}
	}
	void Update()
	{
	}
	void incheckcalculationformula()
	{
		if (incheckcalculationinitialize == true)
		{
			for (int a = 0; a <= 7; a++)
			{
				for (int b = 0; b <= 7; b++)
				{
					incheckcalculation[a, b] = "";
				}
			}
			incheckcalculationinitialize = false;
		}
		for (int a = 0; a <= 7; a++)
		{
			for (int b = 0; b <= 6; b++)
			{
				if (ChessScript.Whitemoving == true)
				{
					if (ChessScript.Everysquare[a][b].text.IndexOf("黑兵") != -1)
					{
						if (a + 1 <= 7)
						{
							incheckcalculation[a + 1, b - 1] = incheckcalculation[a + 1, b - 1].Insert(0, "p");
						}
						if (a - 1 >= 0)
						{
							incheckcalculation[a - 1, b - 1] = incheckcalculation[a - 1, b - 1].Insert(0, "p");
						}
					}
					if (ChessScript.Everysquare[a][b].text.IndexOf("黑騎") != -1)
					{
						if (a + 1 <= 7)
						{
							if (b + 2 <= 7)
							{
								incheckcalculation[a + 1, b + 2] = incheckcalculation[a + 1, b + 2].Insert(0, "n");
							}
							if (b - 2 >= 0)
							{
								incheckcalculation[a + 1, b - 2] = incheckcalculation[a + 1, b - 2].Insert(0, "n");
							}
							if (a + 2 <= 7)
							{
								if (b + 1 <= 7)
								{
									incheckcalculation[a + 2, b + 1] = incheckcalculation[a + 2, b + 1].Insert(0, "n");
								}
								if (b - 1 >= 0)
								{
									incheckcalculation[a + 2, b - 1] = incheckcalculation[a + 2, b - 1].Insert(0, "n");
								}
							}
						}
						if (a - 1 >= 0)
						{
							if (b + 2 <= 7)
							{
								incheckcalculation[a - 1, b + 2] = incheckcalculation[a - 1, b + 2].Insert(0, "n");
							}
							if (b - 2 >= 0)
							{
								incheckcalculation[a - 1, b - 2] = incheckcalculation[a - 1, b - 2].Insert(0, "n");
							}
							if (a - 2 >= 0)
							{
								if (b + 1 <= 7)
								{
									incheckcalculation[a - 2, b + 1] = incheckcalculation[a + 2, b + 1].Insert(0, "n");
								}
								if (b - 1 >= 0)
								{
									incheckcalculation[a - 2, b - 1] = incheckcalculation[a + 2, b - 1].Insert(0, "n");
								}
							}
						}
					}
					if (ChessScript.Everysquare[a][b].text.IndexOf("黑主") != -1)
					{
						for (int c = a + 1, d = b + 1; c <= 7 && d <= 7; c++, d++)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "b");
						}
						for (int c = a - 1, d = b + 1; c >= 0 && d <= 7; c--, d++)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "b");
						}
						for (int c = a - 1, d = b - 1; c >= 0 && d >= 0; c--, d--)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "b");
						}
						for (int c = a + 1, d = b - 1; c <= 7 && d >= 7; c++, d--)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "b");
						}
					}
					if (ChessScript.Everysquare[a][b].text.IndexOf("黑城") != -1)
					{
						for (int c = a + 1; c <= 7; c++)
						{
							incheckcalculation[c, b] = incheckcalculation[c, b].Insert(0, "r");
						}
						for (int c = b + 1; c <= 7; c++)
						{
							incheckcalculation[a, c] = incheckcalculation[a, c].Insert(0, "r");
						}
						for (int c = a - 1; c >= 0; c--)
						{
							incheckcalculation[c, b] = incheckcalculation[c, b].Insert(0, "r");
						}
						for (int c = b - 1; c <= 7; c--)
						{
							incheckcalculation[a, c] = incheckcalculation[a, c].Insert(0, "r");
						}
					}
					if (ChessScript.Everysquare[a][b].text.IndexOf("黑皇") != -1)
					{
						for (int c = a + 1; c <= 7; c++)
						{
							incheckcalculation[c, b] = incheckcalculation[c, b].Insert(0, "q");
						}
						for (int c = a + 1, d = b + 1; c <= 7 && d <= 7; c++, d++)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "q");
						}
						for (int c = b + 1; c <= 7; c++)
						{
							incheckcalculation[a, c] = incheckcalculation[a, c].Insert(0, "q");
						}
						for (int c = a - 1, d = b + 1; c >= 0 && d <= 7; c--, d++)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "q");
						}
						for (int c = a - 1; c >= 0; c--)
						{
							incheckcalculation[c, b] = incheckcalculation[c, b].Insert(0, "q");
						}
						for (int c = a - 1, d = b - 1; c >= 0 && d >= 0; c--, d--)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "q");
						}
						for (int c = b - 1; c <= 7; c--)
						{
							incheckcalculation[a, c] = incheckcalculation[a, c].Insert(0, "q");
						}
						for (int c = a + 1, d = b - 1; c <= 7 && d >= 7; c++, d--)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "q");
						}
					}
					if (ChessScript.Everysquare[a][b].text.IndexOf("黑國") != -1)
					{
						if (a + 1 <= 7)
						{
							incheckcalculation[a + 1, b] = incheckcalculation[a + 1, b].Insert(0, "k");
							if (b + 1 <= 7)
							{
								incheckcalculation[a + 1, b + 1] = incheckcalculation[a + 1, b + 1].Insert(0, "k");
							}
							if (b - 1 >= 0)
							{
								incheckcalculation[a + 1, b - 1] = incheckcalculation[a + 1, b - 1].Insert(0, "k");
							}
						}
						if (b + 1 <= 7)
						{
							incheckcalculation[a, b + 1] = incheckcalculation[a + 1, b + 1].Insert(0, "k");
						}
						if (b - 1 >= 0)
						{
							incheckcalculation[a, b - 1] = incheckcalculation[a + 1, b + 1].Insert(0, "k");
						}
						if (a - 1 >= 0)
						{
							incheckcalculation[a - 1, b] = incheckcalculation[a + 1, b + 1].Insert(0, "k");
							if (b + 1 <= 7)
							{
								incheckcalculation[a - 1, b + 1] = incheckcalculation[a + 1, b + 1].Insert(0, "k");
							}
							if (b - 1 >= 0)
							{
								incheckcalculation[a - 1, b - 1] = incheckcalculation[a + 1, b + 1].Insert(0, "k");
							}
						}
					}
				}
				else
				{
					if (ChessScript.Everysquare[a][b].text.IndexOf("白兵") != -1)
					{
						if (a + 1 <= 7)
						{
							incheckcalculation[a + 1, b + 1] = incheckcalculation[a + 1, b + 1].Insert(0, "p");
						}
						if (a - 1 >= 0)
						{
							incheckcalculation[a - 1, b + 1] = incheckcalculation[a - 1, b + 1].Insert(0, "p");
						}
					}
					if (ChessScript.Everysquare[a][b].text.IndexOf("白騎") != -1)
					{
						if (a + 1 <= 7)
						{
							if (b + 2 <= 7)
							{
								incheckcalculation[a + 1, b + 2] = incheckcalculation[a + 1, b + 2].Insert(0, "n");
							}
							if (b - 2 >= 0)
							{
								incheckcalculation[a + 1, b - 2] = incheckcalculation[a + 1, b - 2].Insert(0, "n");
							}
							if (a + 2 <= 7)
							{
								if (b + 1 <= 7)
								{
									incheckcalculation[a + 2, b + 1] = incheckcalculation[a + 2, b + 1].Insert(0, "n");
								}
								if (b - 1 >= 0)
								{
									incheckcalculation[a + 2, b - 1] = incheckcalculation[a + 2, b - 1].Insert(0, "n");
								}
							}
						}
						if (a - 1 >= 0)
						{
							if (b + 2 <= 7)
							{
								incheckcalculation[a - 1, b + 2] = incheckcalculation[a - 1, b + 2].Insert(0, "n");
							}
							if (b - 2 >= 0)
							{
								incheckcalculation[a - 1, b - 2] = incheckcalculation[a - 1, b - 2].Insert(0, "n");
							}
							if (a - 2 >= 0)
							{
								if (b + 1 <= 7)
								{
									incheckcalculation[a - 2, b + 1] = incheckcalculation[a + 2, b + 1].Insert(0, "n");
								}
								if (b - 1 >= 0)
								{
									incheckcalculation[a - 2, b - 1] = incheckcalculation[a + 2, b - 1].Insert(0, "n");
								}
							}
						}
					}
					if (ChessScript.Everysquare[a][b].text.IndexOf("白主") != -1)
					{
						for (int c = a + 1, d = b + 1; c <= 7 && d <= 7; c++, d++)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "b");
						}
						for (int c = a - 1, d = b + 1; c >= 0 && d <= 7; c--, d++)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "b");
						}
						for (int c = a - 1, d = b - 1; c >= 0 && d >= 0; c--, d--)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "b");
						}
						for (int c = a + 1, d = b - 1; c <= 7 && d >= 7; c++, d--)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "b");
						}
					}
					if (ChessScript.Everysquare[a][b].text.IndexOf("白城") != -1)
					{
						for (int c = a + 1; c <= 7; c++)
						{
							incheckcalculation[c, b] = incheckcalculation[c, b].Insert(0, "r");
						}
						for (int c = b + 1; c <= 7; c++)
						{
							incheckcalculation[a, c] = incheckcalculation[a, c].Insert(0, "r");
						}
						for (int c = a - 1; c >= 0; c--)
						{
							incheckcalculation[c, b] = incheckcalculation[c, b].Insert(0, "r");
						}
						for (int c = b - 1; c <= 7; c--)
						{
							incheckcalculation[a, c] = incheckcalculation[a, c].Insert(0, "r");
						}
					}
					if (ChessScript.Everysquare[a][b].text.IndexOf("白皇") != -1)
					{
						for (int c = a + 1; c <= 7; c++)
						{
							incheckcalculation[c, b] = incheckcalculation[c, b].Insert(0, "q");
						}
						for (int c = a + 1, d = b + 1; c <= 7 && d <= 7; c++, d++)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "q");
						}
						for (int c = b + 1; c <= 7; c++)
						{
							incheckcalculation[a, c] = incheckcalculation[a, c].Insert(0, "q");
						}
						for (int c = a - 1, d = b + 1; c >= 0 && d <= 7; c--, d++)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "q");
						}
						for (int c = a - 1; c >= 0; c--)
						{
							incheckcalculation[c, b] = incheckcalculation[c, b].Insert(0, "q");
						}
						for (int c = a - 1, d = b - 1; c >= 0 && d >= 0; c--, d--)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "q");
						}
						for (int c = b - 1; c <= 7; c--)
						{
							incheckcalculation[a, c] = incheckcalculation[a, c].Insert(0, "q");
						}
						for (int c = a + 1, d = b - 1; c <= 7 && d >= 7; c++, d--)
						{
							incheckcalculation[c, d] = incheckcalculation[c, d].Insert(0, "q");
						}
					}
					if (ChessScript.Everysquare[a][b].text.IndexOf("白國") != -1)
					{
						if (a + 1 <= 7)
						{
							incheckcalculation[a + 1, b] = incheckcalculation[a + 1, b].Insert(0, "k");
							if (b + 1 <= 7)
							{
								incheckcalculation[a + 1, b + 1] = incheckcalculation[a + 1, b + 1].Insert(0, "k");
							}
							if (b - 1 >= 0)
							{
								incheckcalculation[a + 1, b - 1] = incheckcalculation[a + 1, b - 1].Insert(0, "k");
							}
						}
						if (b + 1 <= 7)
						{
							incheckcalculation[a, b + 1] = incheckcalculation[a + 1, b + 1].Insert(0, "k");
						}
						if (b - 1 >= 0)
						{
							incheckcalculation[a, b - 1] = incheckcalculation[a + 1, b + 1].Insert(0, "k");
						}
						if (a - 1 >= 0)
						{
							incheckcalculation[a - 1, b] = incheckcalculation[a + 1, b + 1].Insert(0, "k");
							if (b + 1 <= 7)
							{
								incheckcalculation[a - 1, b + 1] = incheckcalculation[a + 1, b + 1].Insert(0, "k");
							}
							if (b - 1 >= 0)
							{
								incheckcalculation[a - 1, b - 1] = incheckcalculation[a + 1, b + 1].Insert(0, "k");
							}
						}
					}
				}
			}
		}
	}
}
