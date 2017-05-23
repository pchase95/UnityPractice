using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessMan {
    public override bool[,] PossibleMove() {
        bool[,] r = new bool[8, 8];
        // Up Left
        KnightMove(CurrentX - 1, CurrentY + 2, ref r);

        // Up Right
        KnightMove(CurrentX + 1, CurrentY + 2, ref r);

        // Right Up
        KnightMove(CurrentX + 2, CurrentY + 1, ref r);

        // Right Down
        KnightMove(CurrentX + 2, CurrentY - 1, ref r);

        // Down Left
        KnightMove(CurrentX - 1, CurrentY - 2, ref r);

        // Down Right
        KnightMove(CurrentX + 1, CurrentY - 2, ref r);

        // Left Up
        KnightMove(CurrentX - 2, CurrentY + 1, ref r);

        // Left Down
        KnightMove(CurrentX - 2, CurrentY - 1, ref r);

        return r;
    }

    public void KnightMove(int x, int y, ref bool[,] r) {
        ChessMan c;
        if (x >= 0 && x < 8 && y >=0 && y < 8) {
            c = BoardManager.Instance.ChessMans[x, y];
            if (c == null)
                r[x, y] = true;
            else if (this.IsWhite != c.IsWhite)
                r[x, y] = true;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
