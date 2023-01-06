using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PieceMovement : MonoBehaviour
{
	public ChessScript ChessScript;
	public void Start()
	{
		ChessScript = GetComponent<ChessScript>();
	}
	void Update()
	{
	}
	public void Piecemoving(int x, int y)
	{
		switch (ChessScript.incheck)
		{
			case 0:
				if (ChessScript.Everysquare[x][y].text != "")
				{
					if (ChessScript.Everysquare[x][y].text.LastIndexOf("動") == -1 && ChessScript.Everysquare[x][y].text.LastIndexOf("易") == -1 && ChessScript.Everysquare[x][y].text.LastIndexOf("吃") == -1)
					{
						if (ChessScript.Whitemoving == true)
						{
							if (ChessScript.Everysquare[x][y].text.IndexOf("白") != -1)
							{
								for (int a = 0; a <= 7; a++)
								{
									for (int b = 0; b <= 7; b++)
									{
										if (ChessScript.Everysquare[a][b].text.IndexOf("黑") == -1)
										{
											if (ChessScript.Everysquare[a][b].text.LastIndexOf("動") != -1)
											{
												ChessScript.Everysquare[a][b].text = "";
											}
											if (ChessScript.Everysquare[a][b].text.LastIndexOf("吃") != -1)
											{
												ChessScript.Everysquare[a][b].text = ChessScript.Everysquare[a][b].text.TrimEnd('吃');
											}
											ChessScript.Everysquare[a][b].text = ChessScript.Everysquare[a][b].text.TrimEnd('選');
										}
									}
								}
								if (ChessScript.Everysquare[x][y].text.LastIndexOf("兵") != -1)
								{
									if (y == 1)
									{
										if (ChessScript.Everysquare[x][y + 1].text == "")
										{
											ChessScript.Everysquare[x][y + 1].text = ChessScript.Everysquare[x][y].text.PadRight(3, '動');
											if (ChessScript.Everysquare[x][y + 2].text == "")
											{
												ChessScript.Everysquare[x][y + 2].text = ChessScript.Everysquare[x][y].text.PadRight(3, '動');
											}
										}
									}
									else if (y == 4)
									{
										if (ChessScript.Everysquare[x + 1][y].text.IndexOf("黑兵") != -1 && ChessScript.abletoenpassant == true)
										{
											ChessScript.Everysquare[x + 1][y + 1].text = ChessScript.Everysquare[x + 1][y + 1].text.PadRight(3, '吃');
										}
										else if (ChessScript.Everysquare[x - 1][y].text.IndexOf("黑兵") != -1 && ChessScript.abletoenpassant == true)
										{
											ChessScript.Everysquare[x - 1][y + 1].text = ChessScript.Everysquare[x - 1][y + 1].text.PadRight(3, '吃');
										}
									}
									else
									{
										if (ChessScript.Everysquare[x][y + 1].text == "")
										{
											ChessScript.Everysquare[x][y + 1].text = ChessScript.Everysquare[x][y].text.PadRight(3, '動');
										}
									}
									if (x + 1 <= 7)
									{
										if (ChessScript.Everysquare[x + 1][y + 1].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[x + 1][y + 1].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x + 1][y + 1].text = ChessScript.Everysquare[x + 1][y + 1].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x + 1][y + 1].text = ChessScript.Everysquare[x + 1][y + 1].text.PadRight(4, '吃');
											}
										}
									}
									if (x - 1 >= 0)
									{
										if (ChessScript.Everysquare[x - 1][y + 1].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[x - 1][y + 1].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x - 1][y + 1].text = ChessScript.Everysquare[x - 1][y + 1].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x - 1][y + 1].text = ChessScript.Everysquare[x - 1][y + 1].text.PadRight(4, '吃');
											}
										}
									}
								}
								else if (ChessScript.Everysquare[x][y].text.LastIndexOf("騎士") != -1)
								{
									if (x + 1 <= 7)
									{
										if (y + 2 <= 7)
										{
											if (ChessScript.Everysquare[x + 1][y + 2].text == "")
											{
												ChessScript.Everysquare[x + 1][y + 2].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x + 1][y + 2].text.IndexOf("黑") != -1)
											{
												if (ChessScript.Everysquare[x + 1][y + 2].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x + 1][y + 2].text = ChessScript.Everysquare[x + 1][y + 2].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x + 1][y + 2].text = ChessScript.Everysquare[x + 1][y + 2].text.PadRight(4, '吃');
												}
											}
										}
										if (y - 2 >= 0)
										{
											if (ChessScript.Everysquare[x + 1][y - 2].text == "")
											{
												ChessScript.Everysquare[x + 1][y - 2].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x + 1][y - 2].text.IndexOf("黑") != -1)
											{
												if (ChessScript.Everysquare[x + 1][y - 2].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x + 1][y - 2].text = ChessScript.Everysquare[x + 1][y - 2].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x + 1][y - 2].text = ChessScript.Everysquare[x + 1][y - 2].text.PadRight(4, '吃');
												}
											}
										}
										if (x + 2 <= 7)
										{
											if (y + 1 <= 7)
											{
												if (ChessScript.Everysquare[x + 2][y + 1].text == "")
												{
													ChessScript.Everysquare[x + 2][y + 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
												}
												else if (ChessScript.Everysquare[x + 2][y + 1].text.IndexOf("黑") != -1)
												{
													if (ChessScript.Everysquare[x + 2][y + 1].text.IndexOf("兵") != -1)
													{
														ChessScript.Everysquare[x + 2][y + 1].text = ChessScript.Everysquare[x + 2][y + 1].text.PadRight(3, '吃');
													}
													else
													{
														ChessScript.Everysquare[x + 2][y + 1].text = ChessScript.Everysquare[x + 2][y + 1].text.PadRight(4, '吃');
													}
												}
											}
											if (y - 1 >= 0)
											{
												if (ChessScript.Everysquare[x + 2][y - 1].text == "")
												{
													ChessScript.Everysquare[x + 2][y - 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
												}
												else if (ChessScript.Everysquare[x + 2][y - 1].text.IndexOf("黑") != -1)
												{
													if (ChessScript.Everysquare[x + 2][y - 1].text.IndexOf("兵") != -1)
													{
														ChessScript.Everysquare[x + 2][y - 1].text = ChessScript.Everysquare[x + 2][y - 1].text.PadRight(3, '吃');
													}
													else
													{
														ChessScript.Everysquare[x + 2][y - 1].text = ChessScript.Everysquare[x + 2][y - 1].text.PadRight(4, '吃');
													}
												}
											}
										}
									}
									if (x - 1 >= 0)
									{
										if (y + 2 <= 7)
										{
											if (ChessScript.Everysquare[x - 1][y + 2].text == "")
											{
												ChessScript.Everysquare[x - 1][y + 2].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x - 1][y + 2].text.IndexOf("黑") != -1)
											{
												if (ChessScript.Everysquare[x - 1][y + 2].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x - 1][y + 2].text = ChessScript.Everysquare[x - 1][y + 2].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x - 1][y + 2].text = ChessScript.Everysquare[x - 1][y + 2].text.PadRight(4, '吃');
												}
											}
										}
										if (y - 2 >= 0)
										{
											if (ChessScript.Everysquare[x - 1][y - 2].text == "")
											{
												ChessScript.Everysquare[x - 1][y - 2].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x - 1][y - 2].text.IndexOf("黑") != -1)
											{
												if (ChessScript.Everysquare[x - 1][y - 2].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x - 1][y - 2].text = ChessScript.Everysquare[x - 1][y - 2].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x - 1][y - 2].text = ChessScript.Everysquare[x - 1][y - 2].text.PadRight(4, '吃');
												}
											}
										}
										if (x - 2 >= 0)
										{
											if (y + 1 <= 7)
											{
												if (ChessScript.Everysquare[x - 2][y + 1].text == "")
												{
													ChessScript.Everysquare[x - 2][y + 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
												}
												else if (ChessScript.Everysquare[x - 2][y + 1].text.IndexOf("黑") != -1)
												{
													if (ChessScript.Everysquare[x - 2][y + 1].text.IndexOf("兵") != -1)
													{
														ChessScript.Everysquare[x - 2][y + 1].text = ChessScript.Everysquare[x - 2][y + 1].text.PadRight(3, '吃');
													}
													else
													{
														ChessScript.Everysquare[x - 2][y + 1].text = ChessScript.Everysquare[x - 2][y + 1].text.PadRight(4, '吃');
													}
												}
											}
											if (y - 1 >= 0)
											{
												if (ChessScript.Everysquare[x - 2][y - 1].text == "")
												{
													ChessScript.Everysquare[x - 2][y - 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
												}
												else if (ChessScript.Everysquare[x - 2][y - 1].text.IndexOf("黑") != -1)
												{
													if (ChessScript.Everysquare[x - 2][y - 1].text.IndexOf("兵") != -1)
													{
														ChessScript.Everysquare[x - 2][y - 1].text = ChessScript.Everysquare[x - 2][y - 1].text.PadRight(3, '吃');
													}
													else
													{
														ChessScript.Everysquare[x - 2][y - 1].text = ChessScript.Everysquare[x - 2][y - 1].text.PadRight(4, '吃');
													}
												}
											}
										}
									}
								}
								else if (ChessScript.Everysquare[x][y].text.LastIndexOf("主教") != -1)
								{
									for (int c = x + 1, d = y + 1; c <= 7 && d <= 7; c++, d++)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x - 1, d = y + 1; c >= 0 && d <= 7; c--, d++)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x - 1, d = y - 1; c >= 0 && d >= 0; c--, d--)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x + 1, d = y - 1; c <= 7 && d >= 0; c++, d--)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
								}
								else if (ChessScript.Everysquare[x][y].text.LastIndexOf("城堡") != -1)
								{
									for (int c = x + 1; c <= 7; c++)
									{
										if (ChessScript.Everysquare[c][y].text == "")
										{
											ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][y].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[c][y].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int d = y + 1; d <= 7; d++)
									{
										if (ChessScript.Everysquare[x][d].text == "")
										{
											ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x][d].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[x][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x - 1; c >= 0; c--)
									{
										if (ChessScript.Everysquare[c][y].text == "")
										{
											ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][y].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[c][y].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int d = y - 1; d >= 0; d--)
									{
										if (ChessScript.Everysquare[x][d].text == "")
										{
											ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x][d].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[x][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
								}
								else if (ChessScript.Everysquare[x][y].text.LastIndexOf("皇后") != -1)
								{
									for (int c = x + 1; c <= 7; c++)
									{
										if (ChessScript.Everysquare[c][y].text == "")
										{
											ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][y].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[c][y].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;

									}
									for (int c = x + 1, d = y + 1; c <= 7 && d <= 7; c++, d++)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int d = y + 1; d <= 7; d++)
									{
										if (ChessScript.Everysquare[x][d].text == "")
										{
											ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x][d].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[x][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x - 1, d = y + 1; c >= 0 && d <= 7; c--, d++)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x - 1; c >= 0; c--)
									{
										if (ChessScript.Everysquare[c][y].text == "")
										{
											ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][y].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[c][y].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x - 1, d = y - 1; c >= 0 && d >= 0; c--, d--)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int d = y - 1; d >= 0; d--)
									{
										if (ChessScript.Everysquare[x][d].text == "")
										{
											ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x][d].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[x][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x + 1, d = y - 1; c <= 7 && d >= 0; c++, d--)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
								}
								else
								{
									if (x == 4 && y == 0)
									{
										if (ChessScript.Everysquare[x + 3][y].text.LastIndexOf("城堡") != -1)
										{
											if (ChessScript.Everysquare[x + 1][y].text == "" && ChessScript.Everysquare[x + 2][y].text == "")
											{
												if (ChessScript.Whiteshortcastleprivilege == true)
												{
													ChessScript.Everysquare[x + 2][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '易');
												}
											}
										}
										if (ChessScript.Everysquare[x - 4][y].text.LastIndexOf("城堡") != -1)
										{
											if (ChessScript.Everysquare[x - 1][y].text == "" && ChessScript.Everysquare[x - 2][y].text == "" && ChessScript.Everysquare[x - 3][y].text == "")
											{
												if (ChessScript.Whitelongcastleprivilege == true)
												{
													ChessScript.Everysquare[x - 2][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '易');
												}
											}
										}
									}
									if (x + 1 <= 7)
									{
										if (ChessScript.Everysquare[x + 1][y].text == "")
										{
											ChessScript.Everysquare[x + 1][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x + 1][y].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[x + 1][y].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x + 1][y].text = ChessScript.Everysquare[x + 1][y].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x + 1][y].text = ChessScript.Everysquare[x + 1][y].text.PadRight(4, '吃');
											}
										}
										if (y + 1 <= 7)
										{
											if (ChessScript.Everysquare[x + 1][y + 1].text == "")
											{
												ChessScript.Everysquare[x + 1][y + 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x + 1][y + 1].text.IndexOf("黑") != -1)
											{
												if (ChessScript.Everysquare[x + 1][y + 1].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x + 1][y + 1].text = ChessScript.Everysquare[x + 1][y + 1].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x + 1][y + 1].text = ChessScript.Everysquare[x + 1][y + 1].text.PadRight(4, '吃');
												}
											}
										}
										if (y - 1 >= 0)
										{
											if (ChessScript.Everysquare[x + 1][y - 1].text == "")
											{
												ChessScript.Everysquare[x + 1][y - 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x + 1][y - 1].text.IndexOf("黑") != -1)
											{
												if (ChessScript.Everysquare[x + 1][y - 1].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x + 1][y - 1].text = ChessScript.Everysquare[x + 1][y - 1].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x + 1][y - 1].text = ChessScript.Everysquare[x + 1][y - 1].text.PadRight(4, '吃');
												}
											}
										}
									}
									if (y + 1 <= 7)
									{
										if (ChessScript.Everysquare[x][y + 1].text == "")
										{
											ChessScript.Everysquare[x][y + 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x][y + 1].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[x][y + 1].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x][y + 1].text = ChessScript.Everysquare[x][y + 1].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x][y + 1].text = ChessScript.Everysquare[x][y + 1].text.PadRight(4, '吃');
											}
										}
									}
									if (y - 1 >= 0)
									{
										if (ChessScript.Everysquare[x][y - 1].text == "")
										{
											ChessScript.Everysquare[x][y - 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x][y - 1].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[x][y - 1].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x][y - 1].text = ChessScript.Everysquare[x][y - 1].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x][y - 1].text = ChessScript.Everysquare[x][y - 1].text.PadRight(4, '吃');
											}
										}
									}
									if (x - 1 >= 0)
									{
										if (ChessScript.Everysquare[x - 1][y].text == "")
										{
											ChessScript.Everysquare[x - 1][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x - 1][y].text.IndexOf("黑") != -1)
										{
											if (ChessScript.Everysquare[x - 1][y].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x - 1][y].text = ChessScript.Everysquare[x - 1][y].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x - 1][y].text = ChessScript.Everysquare[x - 1][y].text.PadRight(4, '吃');
											}
										}
										if (y + 1 <= 7)
										{
											if (ChessScript.Everysquare[x - 1][y + 1].text == "")
											{
												ChessScript.Everysquare[x - 1][y + 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x - 1][y + 1].text.IndexOf("黑") != -1)
											{
												if (ChessScript.Everysquare[x - 1][y + 1].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x - 1][y + 1].text = ChessScript.Everysquare[x - 1][y + 1].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x - 1][y + 1].text = ChessScript.Everysquare[x - 1][y + 1].text.PadRight(4, '吃');
												}
											}
										}
										if (y - 1 >= 0)
										{
											if (ChessScript.Everysquare[x - 1][y - 1].text == "")
											{
												ChessScript.Everysquare[x - 1][y - 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x - 1][y - 1].text.IndexOf("黑") != -1)
											{
												if (ChessScript.Everysquare[x - 1][y - 1].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x - 1][y - 1].text = ChessScript.Everysquare[x - 1][y - 1].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x - 1][y - 1].text = ChessScript.Everysquare[x - 1][y - 1].text.PadRight(4, '吃');
												}
											}
										}
									}
								}
								ChessScript.Everysquare[x][y].text = ChessScript.Everysquare[x][y].text + "選";
							}
						}
						else
						{
							if (ChessScript.Everysquare[x][y].text.IndexOf("黑") != -1)
							{
								for (int a = 0; a <= 7; a++)
								{
									for (int b = 0; b <= 7; b++)
									{
										if (ChessScript.Everysquare[a][b].text.IndexOf("白") == -1)
										{
											if (ChessScript.Everysquare[a][b].text.LastIndexOf("動") != -1)
											{
												ChessScript.Everysquare[a][b].text = "";
											}
											if (ChessScript.Everysquare[a][b].text.LastIndexOf("吃") != -1)
											{
												ChessScript.Everysquare[a][b].text = ChessScript.Everysquare[a][b].text.TrimEnd('吃');
											}
											ChessScript.Everysquare[a][b].text = ChessScript.Everysquare[a][b].text.TrimEnd('選');
										}
									}
								}
								if (ChessScript.Everysquare[x][y].text.LastIndexOf("兵") != -1)
								{
									if (y == 6)
									{
										if (ChessScript.Everysquare[x][y - 1].text == "")
										{
											ChessScript.Everysquare[x][y - 1].text = ChessScript.Everysquare[x][y].text.PadRight(3, '動');
											if (ChessScript.Everysquare[x][y - 2].text == "")
											{
												ChessScript.Everysquare[x][y - 2].text = ChessScript.Everysquare[x][y].text.PadRight(3, '動');
											}
										}
									}
									else if (y == 3)
									{
										if (ChessScript.Everysquare[x + 1][y].text.IndexOf("白兵") != -1 && ChessScript.abletoenpassant == true)
										{
											ChessScript.Everysquare[x + 1][y + 1].text = ChessScript.Everysquare[x + 1][y - 1].text.PadRight(3, '吃');
										}
										else if (ChessScript.Everysquare[x - 1][y].text.IndexOf("白兵") != -1 && ChessScript.abletoenpassant == true)
										{
											ChessScript.Everysquare[x - 1][y + 1].text = ChessScript.Everysquare[x - 1][y - 1].text.PadRight(3, '吃');
										}
									}
									else
									{
										if (ChessScript.Everysquare[x][y - 1].text == "")
										{
											ChessScript.Everysquare[x][y - 1].text = ChessScript.Everysquare[x][y].text.PadRight(3, '動');
										}
									}
									if (x + 1 <= 7)
									{
										if (ChessScript.Everysquare[x + 1][y - 1].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[x + 1][y - 1].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x + 1][y - 1].text = ChessScript.Everysquare[x + 1][y - 1].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x + 1][y - 1].text = ChessScript.Everysquare[x + 1][y - 1].text.PadRight(4, '吃');
											}
										}
									}
									if (x - 1 >= 0)
									{
										if (ChessScript.Everysquare[x - 1][y - 1].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[x - 1][y - 1].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x - 1][y - 1].text = ChessScript.Everysquare[x - 1][y - 1].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x - 1][y - 1].text = ChessScript.Everysquare[x - 1][y - 1].text.PadRight(4, '吃');
											}
										}
									}
								}
								else if (ChessScript.Everysquare[x][y].text.LastIndexOf("騎士") != -1)
								{
									if (x + 1 <= 7)
									{
										if (y + 2 <= 7)
										{
											if (ChessScript.Everysquare[x + 1][y + 2].text == "")
											{
												ChessScript.Everysquare[x + 1][y + 2].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x + 1][y + 2].text.IndexOf("白") != -1)
											{
												if (ChessScript.Everysquare[x + 1][y + 2].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x + 1][y + 2].text = ChessScript.Everysquare[x + 1][y + 2].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x + 1][y + 2].text = ChessScript.Everysquare[x + 1][y + 2].text.PadRight(4, '吃');
												}
											}
										}
										if (y - 2 >= 0)
										{
											if (ChessScript.Everysquare[x + 1][y - 2].text == "")
											{
												ChessScript.Everysquare[x + 1][y - 2].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x + 1][y - 2].text.IndexOf("白") != -1)
											{
												if (ChessScript.Everysquare[x + 1][y - 2].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x + 1][y - 2].text = ChessScript.Everysquare[x + 1][y - 2].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x + 1][y - 2].text = ChessScript.Everysquare[x + 1][y - 2].text.PadRight(4, '吃');
												}
											}
										}
										if (x + 2 <= 7)
										{
											if (y + 1 <= 7)
											{
												if (ChessScript.Everysquare[x + 2][y + 1].text == "")
												{
													ChessScript.Everysquare[x + 2][y + 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
												}
												else if (ChessScript.Everysquare[x + 2][y + 1].text.IndexOf("白") != -1)
												{
													if (ChessScript.Everysquare[x + 2][y + 1].text.IndexOf("兵") != -1)
													{
														ChessScript.Everysquare[x + 2][y + 1].text = ChessScript.Everysquare[x + 2][y + 1].text.PadRight(3, '吃');
													}
													else
													{
														ChessScript.Everysquare[x + 2][y + 1].text = ChessScript.Everysquare[x + 2][y + 1].text.PadRight(4, '吃');
													}
												}
											}
											if (y - 1 >= 0)
											{
												if (ChessScript.Everysquare[x + 2][y - 1].text == "")
												{
													ChessScript.Everysquare[x + 2][y - 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
												}
												else if (ChessScript.Everysquare[x + 2][y - 1].text.IndexOf("白") != -1)
												{
													if (ChessScript.Everysquare[x + 2][y - 1].text.IndexOf("兵") != -1)
													{
														ChessScript.Everysquare[x + 2][y - 1].text = ChessScript.Everysquare[x + 2][y - 1].text.PadRight(3, '吃');
													}
													else
													{
														ChessScript.Everysquare[x + 2][y - 1].text = ChessScript.Everysquare[x + 2][y - 1].text.PadRight(4, '吃');
													}
												}
											}
										}
									}
									if (x - 1 >= 0)
									{
										if (y + 2 <= 7)
										{
											if (ChessScript.Everysquare[x - 1][y + 2].text == "")
											{
												ChessScript.Everysquare[x - 1][y + 2].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x - 1][y + 2].text.IndexOf("白") != -1)
											{
												if (ChessScript.Everysquare[x - 1][y + 2].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x - 1][y + 2].text = ChessScript.Everysquare[x - 1][y + 2].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x - 1][y + 2].text = ChessScript.Everysquare[x - 1][y + 2].text.PadRight(4, '吃');
												}
											}
										}
										if (y - 2 >= 0)
										{
											if (ChessScript.Everysquare[x - 1][y - 2].text == "")
											{
												ChessScript.Everysquare[x - 1][y - 2].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x - 1][y - 2].text.IndexOf("白") != -1)
											{
												if (ChessScript.Everysquare[x - 1][y - 2].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x - 1][y - 2].text = ChessScript.Everysquare[x - 1][y - 2].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x - 1][y - 2].text = ChessScript.Everysquare[x - 1][y - 2].text.PadRight(4, '吃');
												}
											}
										}
										if (x - 2 >= 0)
										{
											if (y + 1 <= 7)
											{
												if (ChessScript.Everysquare[x - 2][y + 1].text == "")
												{
													ChessScript.Everysquare[x - 2][y + 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
												}
												else if (ChessScript.Everysquare[x - 2][y + 1].text.IndexOf("白") != -1)
												{
													if (ChessScript.Everysquare[x - 2][y + 1].text.IndexOf("兵") != -1)
													{
														ChessScript.Everysquare[x - 2][y + 1].text = ChessScript.Everysquare[x - 2][y + 1].text.PadRight(3, '吃');
													}
													else
													{
														ChessScript.Everysquare[x - 2][y + 1].text = ChessScript.Everysquare[x - 2][y + 1].text.PadRight(4, '吃');
													}
												}
											}
											if (y - 1 >= 0)
											{
												if (ChessScript.Everysquare[x - 2][y - 1].text == "")
												{
													ChessScript.Everysquare[x - 2][y - 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
												}
												else if (ChessScript.Everysquare[x - 2][y - 1].text.IndexOf("白") != -1)
												{
													if (ChessScript.Everysquare[x - 2][y - 1].text.IndexOf("兵") != -1)
													{
														ChessScript.Everysquare[x - 2][y - 1].text = ChessScript.Everysquare[x - 2][y - 1].text.PadRight(3, '吃');
													}
													else
													{
														ChessScript.Everysquare[x - 2][y - 1].text = ChessScript.Everysquare[x - 2][y - 1].text.PadRight(4, '吃');
													}
												}
											}
										}
									}
								}
								else if (ChessScript.Everysquare[x][y].text.LastIndexOf("主教") != -1)
								{
									for (int c = x + 1, d = y + 1; c <= 7 && d <= 7; c++, d++)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x - 1, d = y + 1; c >= 0 && d <= 7; c--, d++)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x - 1, d = y - 1; c >= 0 && d >= 0; c--, d--)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x + 1, d = y - 1; c <= 7 && d >= 0; c++, d--)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
								}
								else if (ChessScript.Everysquare[x][y].text.LastIndexOf("城堡") != -1)
								{
									for (int c = x + 1; c <= 7; c++)
									{
										if (ChessScript.Everysquare[c][y].text == "")
										{
											ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][y].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[c][y].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int d = y + 1; d <= 7; d++)
									{
										if (ChessScript.Everysquare[x][d].text == "")
										{
											ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x][d].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[x][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x - 1; c >= 0; c--)
									{
										if (ChessScript.Everysquare[c][y].text == "")
										{
											ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][y].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[c][y].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int d = y - 1; d >= 0; d--)
									{
										if (ChessScript.Everysquare[x][d].text == "")
										{
											ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x][d].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[x][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
								}
								else if (ChessScript.Everysquare[x][y].text.LastIndexOf("皇后") != -1)
								{
									for (int c = x + 1; c <= 7; c++)
									{
										if (ChessScript.Everysquare[c][y].text == "")
										{
											ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][y].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[c][y].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;

									}
									for (int c = x + 1, d = y + 1; c <= 7 && d <= 7; c++, d++)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int d = y + 1; d <= 7; d++)
									{
										if (ChessScript.Everysquare[x][d].text == "")
										{
											ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x][d].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[x][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x - 1, d = y + 1; c >= 0 && d <= 7; c--, d++)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x - 1; c >= 0; c--)
									{
										if (ChessScript.Everysquare[c][y].text == "")
										{
											ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][y].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[c][y].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][y].text = ChessScript.Everysquare[c][y].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x - 1, d = y - 1; c >= 0 && d >= 0; c--, d--)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int d = y - 1; d >= 0; d--)
									{
										if (ChessScript.Everysquare[x][d].text == "")
										{
											ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x][d].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[x][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x][d].text = ChessScript.Everysquare[x][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
									for (int c = x + 1, d = y - 1; c <= 7 && d >= 0; c++, d--)
									{
										if (ChessScript.Everysquare[c][d].text == "")
										{
											ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[c][d].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[c][d].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[c][d].text = ChessScript.Everysquare[c][d].text.PadRight(4, '吃');
											}
											break;
										}
										else
											break;
									}
								}
								else
								{
									if (x == 4 && y == 7)
									{
										if (ChessScript.Everysquare[x + 3][y].text.LastIndexOf("城堡") != -1)
										{
											if (ChessScript.Everysquare[x + 1][y].text == "" && ChessScript.Everysquare[x + 2][y].text == "")
											{
												if (ChessScript.Blackshortcastleprivilege == true)
												{
													ChessScript.Everysquare[x + 2][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '易');
												}
											}
										}
										if (ChessScript.Everysquare[x - 4][y].text.LastIndexOf("城堡") != -1)
										{
											if (ChessScript.Everysquare[x - 1][y].text == "" && ChessScript.Everysquare[x - 2][y].text == "" && ChessScript.Everysquare[x - 3][y].text == "")
											{
												if (ChessScript.Blacklongcastleprivilege == true)
												{
													ChessScript.Everysquare[x - 2][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '易');
												}
											}
										}
									}
									if (x + 1 <= 7)
									{
										if (ChessScript.Everysquare[x + 1][y].text == "")
										{
											ChessScript.Everysquare[x + 1][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x + 1][y].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[x + 1][y].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x + 1][y].text = ChessScript.Everysquare[x + 1][y].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x + 1][y].text = ChessScript.Everysquare[x + 1][y].text.PadRight(4, '吃');
											}
										}
										if (y + 1 <= 7)
										{
											if (ChessScript.Everysquare[x + 1][y + 1].text == "")
											{
												ChessScript.Everysquare[x + 1][y + 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x + 1][y + 1].text.IndexOf("白") != -1)
											{
												if (ChessScript.Everysquare[x + 1][y + 1].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x + 1][y + 1].text = ChessScript.Everysquare[x + 1][y + 1].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x + 1][y + 1].text = ChessScript.Everysquare[x + 1][y + 1].text.PadRight(4, '吃');
												}
											}
										}
										if (y - 1 >= 0)
										{
											if (ChessScript.Everysquare[x + 1][y - 1].text == "")
											{
												ChessScript.Everysquare[x + 1][y - 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x + 1][y - 1].text.IndexOf("白") != -1)
											{
												if (ChessScript.Everysquare[x + 1][y - 1].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x + 1][y - 1].text = ChessScript.Everysquare[x + 1][y - 1].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x + 1][y - 1].text = ChessScript.Everysquare[x + 1][y - 1].text.PadRight(4, '吃');
												}
											}
										}
									}
									if (y + 1 <= 7)
									{
										if (ChessScript.Everysquare[x][y + 1].text == "")
										{
											ChessScript.Everysquare[x][y + 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x][y + 1].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[x][y + 1].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x][y + 1].text = ChessScript.Everysquare[x][y + 1].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x][y + 1].text = ChessScript.Everysquare[x][y + 1].text.PadRight(4, '吃');
											}
										}
									}
									if (y - 1 >= 0)
									{
										if (ChessScript.Everysquare[x][y - 1].text == "")
										{
											ChessScript.Everysquare[x][y - 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x][y - 1].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[x][y - 1].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x][y - 1].text = ChessScript.Everysquare[x][y - 1].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x][y - 1].text = ChessScript.Everysquare[x][y - 1].text.PadRight(4, '吃');
											}
										}
									}
									if (x - 1 >= 0)
									{
										if (ChessScript.Everysquare[x - 1][y].text == "")
										{
											ChessScript.Everysquare[x - 1][y].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
										}
										else if (ChessScript.Everysquare[x - 1][y].text.IndexOf("白") != -1)
										{
											if (ChessScript.Everysquare[x - 1][y].text.IndexOf("兵") != -1)
											{
												ChessScript.Everysquare[x - 1][y].text = ChessScript.Everysquare[x - 1][y].text.PadRight(3, '吃');
											}
											else
											{
												ChessScript.Everysquare[x - 1][y].text = ChessScript.Everysquare[x - 1][y].text.PadRight(4, '吃');
											}
										}
										if (y + 1 <= 7)
										{
											if (ChessScript.Everysquare[x - 1][y + 1].text == "")
											{
												ChessScript.Everysquare[x - 1][y + 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x - 1][y + 1].text.IndexOf("白") != -1)
											{
												if (ChessScript.Everysquare[x - 1][y + 1].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x - 1][y + 1].text = ChessScript.Everysquare[x - 1][y + 1].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x - 1][y + 1].text = ChessScript.Everysquare[x - 1][y + 1].text.PadRight(4, '吃');
												}
											}
										}
										if (y - 1 >= 0)
										{
											if (ChessScript.Everysquare[x - 1][y - 1].text == "")
											{
												ChessScript.Everysquare[x - 1][y - 1].text = ChessScript.Everysquare[x][y].text.PadRight(4, '動');
											}
											else if (ChessScript.Everysquare[x - 1][y - 1].text.IndexOf("白") != -1)
											{
												if (ChessScript.Everysquare[x - 1][y - 1].text.IndexOf("兵") != -1)
												{
													ChessScript.Everysquare[x - 1][y - 1].text = ChessScript.Everysquare[x - 1][y - 1].text.PadRight(3, '吃');
												}
												else
												{
													ChessScript.Everysquare[x - 1][y - 1].text = ChessScript.Everysquare[x - 1][y - 1].text.PadRight(4, '吃');
												}
											}
										}
									}
								}
								ChessScript.Everysquare[x][y].text = ChessScript.Everysquare[x][y].text + "選";
							}
						}
					}
					else if (ChessScript.Everysquare[x][y].text.LastIndexOf("易") != -1)
					{
						if (ChessScript.Whitemoving == true)
						{
							if (x == 6)
							{
								ChessScript.Everysquare[x][y].text = ChessScript.Everysquare[x][y].text.TrimEnd('易');
								ChessScript.Everysquare[x - 1][y].text = ChessScript.Everysquare[x + 1][y].text;
								ChessScript.Everysquare[x + 1][y].text = "";
							}
							else
							{
								ChessScript.Everysquare[x][y].text = ChessScript.Everysquare[x][y].text.TrimEnd('易');
								ChessScript.Everysquare[x + 1][y].text = ChessScript.Everysquare[x - 2][y].text;
								ChessScript.Everysquare[x - 2][y].text = "";
							}
							ChessScript.Whitemoving = false;
						}
						else
						{
							if (x == 6)
							{
								ChessScript.Everysquare[x][y].text = ChessScript.Everysquare[x][y].text.TrimEnd('易');
								ChessScript.Everysquare[x - 1][y].text = ChessScript.Everysquare[x + 1][y].text;
								ChessScript.Everysquare[x + 1][y].text = "";
							}
							else
							{
								ChessScript.Everysquare[x][y].text = ChessScript.Everysquare[x][y].text.TrimEnd('易');
								ChessScript.Everysquare[x + 1][y].text = ChessScript.Everysquare[x - 2][y].text;
								ChessScript.Everysquare[x - 2][y].text = "";
							}
							ChessScript.Whitemoving = true;
						}
						for (int a = 0; a <= 7; a++)
						{
							for (int b = 0; b <= 7; b++)
							{
								if (ChessScript.Everysquare[a][b].text.LastIndexOf('選') != -1 || ChessScript.Everysquare[a][b].text.LastIndexOf('動') != -1)
								{
									ChessScript.Everysquare[a][b].text = "";
								}
							}
						}
					}
					else if (ChessScript.Everysquare[x][y].text.LastIndexOf("吃") != -1)
					{
						if (ChessScript.Whitemoving == true)
						{
							if (ChessScript.Everysquare[x][y].text.IndexOf("黑") != -1)
							{
								for (int a = 0; a <= 7; a++)
								{
									for (int b = 0; b <= 7; b++)
									{
										if (ChessScript.Everysquare[a][b].text.LastIndexOf("動") != -1)
										{
											ChessScript.Everysquare[a][b].text = "";
										}
										else if (ChessScript.Everysquare[a][b].text.LastIndexOf("吃") != -1)
										{
											ChessScript.Everysquare[a][b].text = ChessScript.Everysquare[a][b].text.TrimEnd('吃');
										}
										else if (ChessScript.Everysquare[a][b].text.LastIndexOf("選") != -1)
										{
											ChessScript.Everysquare[x][y].text = ChessScript.Everysquare[a][b].text.TrimEnd('選');
											ChessScript.Everysquare[a][b].text = "";
										}
									}
								}
								ChessScript.Whitemoving = false;
							}
						}
						else
						{
							if (ChessScript.Everysquare[x][y].text.IndexOf("白") != -1)
							{
								for (int a = 0; a <= 7; a++)
								{
									for (int b = 0; b <= 7; b++)
									{
										if (ChessScript.Everysquare[a][b].text.LastIndexOf("動") != -1)
										{
											ChessScript.Everysquare[a][b].text = "";
										}
										else if (ChessScript.Everysquare[a][b].text.LastIndexOf("吃") != -1)
										{
											ChessScript.Everysquare[a][b].text = ChessScript.Everysquare[a][b].text.TrimEnd('吃');
										}
										else if (ChessScript.Everysquare[a][b].text.LastIndexOf("選") != -1)
										{
											ChessScript.Everysquare[x][y].text = ChessScript.Everysquare[a][b].text.TrimEnd('選');
											ChessScript.Everysquare[a][b].text = "";
										}
									}
								}
								ChessScript.Whitemoving = true;
							}
						}
					}
					else if (ChessScript.Everysquare[x][y].text.LastIndexOf("動") != -1)
					{
						if (ChessScript.abletoenpassant == true)
						{
							ChessScript.abletoenpassant = false;
						}
						if (y == 3)
						{
							if (ChessScript.Whitemoving == true)
							{
								if (ChessScript.Everysquare[x][y].text.LastIndexOf("白兵") != -1)
								{
									if (ChessScript.Everysquare[x][y - 1].text.LastIndexOf("白兵動") != -1 && ChessScript.Everysquare[x][y - 2].text.LastIndexOf("白兵選") != -1)
									{
										ChessScript.abletoenpassant = true;
									}
								}
							}
						}
						else if (y == 4)
						{
							if (ChessScript.Whitemoving == false)
							{
								if (ChessScript.Everysquare[x][y].text.LastIndexOf("黑兵") != -1)
								{
									if (ChessScript.Everysquare[x][y + 1].text.LastIndexOf("黑兵動") != -1 && ChessScript.Everysquare[x][y + 2].text.LastIndexOf("黑兵選") != -1)
									{
										ChessScript.abletoenpassant = true;
									}
								}
							}
						}
						if (ChessScript.Whitemoving == true)
						{
							if (ChessScript.Everysquare[x][y].text.LastIndexOf("國王") != -1 || ChessScript.Everysquare[7][0].text.LastIndexOf("城堡選") != -1)
							{
								ChessScript.Whiteshortcastleprivilege = false;
							}
							if (ChessScript.Everysquare[x][y].text.LastIndexOf("國王") != -1 || ChessScript.Everysquare[0][0].text.LastIndexOf("城堡選") != -1)
							{
								ChessScript.Whitelongcastleprivilege = false;
							}
						}
						if (ChessScript.Whitemoving == false)
						{
							if (ChessScript.Everysquare[x][y].text.LastIndexOf("國王") != -1 || ChessScript.Everysquare[7][7].text.LastIndexOf("城堡選") != -1)
							{
								ChessScript.Blackshortcastleprivilege = false;
							}
							if (ChessScript.Everysquare[x][y].text.LastIndexOf("國王") != -1 || ChessScript.Everysquare[0][7].text.LastIndexOf("城堡選") != -1)
							{
								ChessScript.Blacklongcastleprivilege = false;
							}
						}
						ChessScript.Everysquare[x][y].text = ChessScript.Everysquare[x][y].text.TrimEnd('動');
						for (int a = 0; a <= 7; a++)
						{
							for (int b = 0; b <= 7; b++)
							{
								if (ChessScript.Everysquare[a][b].text.LastIndexOf("吃") != -1)
								{
									ChessScript.Everysquare[a][b].text = ChessScript.Everysquare[a][b].text.TrimEnd('吃');
								}
								if (ChessScript.Everysquare[a][b].text.LastIndexOf("動") != -1 || ChessScript.Everysquare[a][b].text.LastIndexOf("選") != -1)
								{
									ChessScript.Everysquare[a][b].text = "";
								}
							}
						}
						ChessScript.Whitemoving = !ChessScript.Whitemoving;
					}
				}
				break;
			case 1:
				break;
			case 2:
				break;
			case 3:
				break;
		}
	}
}