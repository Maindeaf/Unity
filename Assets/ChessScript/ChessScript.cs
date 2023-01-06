using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChessScript : MonoBehaviour
{
	public Button[] ALine = new Button[8];
	public Button[] BLine = new Button[8];
	public Button[] CLine = new Button[8];
	public Button[] DLine = new Button[8];
	public Button[] ELine = new Button[8];
	public Button[] FLine = new Button[8];
	public Button[] GLine = new Button[8];
	public Button[] HLine = new Button[8];
	public Button[] Promotion = new Button[8];
	public Text[] ALinePiece = new Text[8];
	public Text[] BLinePiece = new Text[8];
	public Text[] CLinePiece = new Text[8];
	public Text[] DLinePiece = new Text[8];
	public Text[] ELinePiece = new Text[8];
	public Text[] FLinePiece = new Text[8];
	public Text[] GLinePiece = new Text[8];
	public Text[] HLinePiece = new Text[8];
	public Text[][] Everysquare;
	public Text[] PromotionText = new Text[8];
	public PieceMovement PieceMovement;
	public PromotionControl PromotionControl;
	public bool Whitemoving;
	public int incheck;
	public bool abletoenpassant;
	public bool incheckvaluereturnswitch;
	public bool promotion;
	public bool Whiteshortcastleprivilege;
	public bool Whitelongcastleprivilege;
	public bool Blackshortcastleprivilege;
	public bool Blacklongcastleprivilege;
	public bool Promotionenablebuttonswitch;
	public void Start()
	{
		PieceMovement = GetComponent<PieceMovement>();
		PromotionControl = GetComponent<PromotionControl>();
		Initialize();
		Buttonaddlistener();
	}
	void Update()
	{
	}
	public void Initialize()
	{
		ALinePiece[0].text = "白城堡";
		ALinePiece[1].text = "白兵";
		ALinePiece[2].text = "";
		ALinePiece[3].text = "";
		ALinePiece[4].text = "";
		ALinePiece[5].text = "";
		ALinePiece[6].text = "黑兵";
		ALinePiece[7].text = "黑城堡";
		BLinePiece[0].text = "白騎士";
		BLinePiece[1].text = "白兵";
		BLinePiece[2].text = "";
		BLinePiece[3].text = "";
		BLinePiece[4].text = "";
		BLinePiece[5].text = "";
		BLinePiece[6].text = "黑兵";
		BLinePiece[7].text = "黑騎士";
		CLinePiece[0].text = "白主教";
		CLinePiece[1].text = "白兵";
		CLinePiece[2].text = "";
		CLinePiece[3].text = "";
		CLinePiece[4].text = "";
		CLinePiece[5].text = "";
		CLinePiece[6].text = "黑兵";
		CLinePiece[7].text = "黑主教";
		DLinePiece[0].text = "白皇后";
		DLinePiece[1].text = "白兵";
		DLinePiece[2].text = "";
		DLinePiece[3].text = "";
		DLinePiece[4].text = "";
		DLinePiece[5].text = "";
		DLinePiece[6].text = "黑兵";
		DLinePiece[7].text = "黑皇后";
		ELinePiece[0].text = "白國王";
		ELinePiece[1].text = "白兵";
		ELinePiece[2].text = "";
		ELinePiece[3].text = "";
		ELinePiece[4].text = "";
		ELinePiece[5].text = "";
		ELinePiece[6].text = "黑兵";
		ELinePiece[7].text = "黑國王";
		FLinePiece[0].text = "白主教";
		FLinePiece[1].text = "白兵";
		FLinePiece[2].text = "";
		FLinePiece[3].text = "";
		FLinePiece[4].text = "";
		FLinePiece[5].text = "";
		FLinePiece[6].text = "黑兵";
		FLinePiece[7].text = "黑主教";
		GLinePiece[0].text = "白騎士";
		GLinePiece[1].text = "白兵";
		GLinePiece[2].text = "";
		GLinePiece[3].text = "";
		GLinePiece[4].text = "";
		GLinePiece[5].text = "";
		GLinePiece[6].text = "黑兵";
		GLinePiece[7].text = "黑騎士";
		HLinePiece[0].text = "白城堡";
		HLinePiece[1].text = "白兵";
		HLinePiece[2].text = "";
		HLinePiece[3].text = "";
		HLinePiece[4].text = "";
		HLinePiece[5].text = "";
		HLinePiece[6].text = "黑兵";
		HLinePiece[7].text = "黑城堡";
		Everysquare = new Text[8][]
		{
			ALinePiece,
			BLinePiece,
			CLinePiece,
			DLinePiece,
			ELinePiece,
			FLinePiece,
			GLinePiece,
			HLinePiece
		};
		PromotionText[0].text = PromotionText[4].text = "皇后";
		PromotionText[1].text = PromotionText[5].text = "城堡";
		PromotionText[2].text = PromotionText[6].text = "主教";
		PromotionText[3].text = PromotionText[7].text = "騎士";
		Whitemoving = true;
		abletoenpassant = false;
		Whiteshortcastleprivilege = true;
		Whitelongcastleprivilege = true;
		Blackshortcastleprivilege = true;
		Blacklongcastleprivilege = true;
		incheckvaluereturnswitch = true;
		incheck = 0;
	}
	public void Buttonaddlistener()
	{
		ALine[0].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(0, 0);
		});
		ALine[1].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(0, 1);
		});
		ALine[2].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(0, 2);
		});
		ALine[3].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(0, 3);
		});
		ALine[4].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(0, 4);
		});
		ALine[5].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(0, 5);
		});
		ALine[6].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(0, 6);
		});
		ALine[7].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(0, 7);
		});
		BLine[0].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(1, 0);
		});
		BLine[1].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(1, 1);
		});
		BLine[2].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(1, 2);
		});
		BLine[3].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(1, 3);
		});
		BLine[4].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(1, 4);
		});
		BLine[5].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(1, 5);
		});
		BLine[6].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(1, 6);
		});
		BLine[7].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(1, 7);
		});
		CLine[0].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(2, 0);
		});
		CLine[1].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(2, 1);
		});
		CLine[2].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(2, 2);
		});
		CLine[3].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(2, 3);
		});
		CLine[4].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(2, 4);
		});
		CLine[5].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(2, 5);
		});
		CLine[6].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(2, 6);
		});
		CLine[7].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(2, 7);
		});
		DLine[0].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(3, 0);
		});
		DLine[1].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(3, 1);
		});
		DLine[2].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(3, 2);
		});
		DLine[3].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(3, 3);
		});
		DLine[4].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(3, 4);
		});
		DLine[5].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(3, 5);
		});
		DLine[6].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(3, 6);
		});
		DLine[7].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(3, 7);
		});
		ELine[0].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(4, 0);
		});
		ELine[1].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(4, 1);
		});
		ELine[2].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(4, 2);
		});
		ELine[3].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(4, 3);
		});
		ELine[4].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(4, 4);
		});
		ELine[5].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(4, 5);
		});
		ELine[6].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(4, 6);
		});
		ELine[7].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(4, 7);
		});
		FLine[0].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(5, 0);
		});
		FLine[1].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(5, 1);
		});
		FLine[2].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(5, 2);
		});
		FLine[3].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(5, 3);
		});
		FLine[4].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(5, 4);
		});
		FLine[5].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(5, 5);
		});
		FLine[6].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(5, 6);
		});
		FLine[7].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(5, 7);
		});
		GLine[0].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(6, 0);
		});
		GLine[1].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(6, 1);
		});
		GLine[2].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(6, 2);
		});
		GLine[3].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(6, 3);
		});
		GLine[4].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(6, 4);
		});
		GLine[5].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(6, 5);
		});
		GLine[6].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(6, 6);
		});
		GLine[7].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(6, 7);
		});
		HLine[0].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(7, 0);
		});
		HLine[1].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(7, 1);
		});
		HLine[2].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(7, 2);
		});
		HLine[3].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(7, 3);
		});
		HLine[4].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(7, 4);
		});
		HLine[5].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(7, 5);
		});
		HLine[6].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(7, 6);
		});
		HLine[7].onClick.AddListener(delegate ()
		{
			PieceMovement.Piecemoving(7, 7);
		});
	}
}