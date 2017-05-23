using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessMan {
    public override bool[,] PossibleMove() {
        bool[,] r = new bool[8, 8];
        ChessMan c;
        int i;

        // Right
        i = CurrentX;
        while (true) {
            i++;
            if (i >= 8)
                break;

            c = BoardManager.Instance.ChessMans[i, CurrentY];
            if (c == null)
                r[i, CurrentY] = true;
            else {
                if (c.IsWhite != this.IsWhite)
                    r[i, CurrentY] = true;
                break;
            }
        }

        // Left
        i = CurrentX;
        while (true) {
            i--;
            if (i < 0)
                break;

            c = BoardManager.Instance.ChessMans[i, CurrentY];
            if (c == null)
                r[i, CurrentY] = true;
            else {
                if (c.IsWhite != this.IsWhite)
                    r[i, CurrentY] = true;
                break;
            }
        }

        // Up
        i = CurrentY;
        while (true) {
            i++;
            if (i >= 8)
                break;

            c = BoardManager.Instance.ChessMans[CurrentX, i];
            if (c == null)
                r[CurrentX, i] = true;
            else {
                if (c.IsWhite != this.IsWhite)
                    r[CurrentX, i] = true;
                break;
            }
        }

        // Down
        i = CurrentY;
        while (true) {
            i--;
            if (i < 0)
                break;

            c = BoardManager.Instance.ChessMans[CurrentX, i];
            if (c == null)
                r[CurrentX, i] = true;
            else {
                if (c.IsWhite != this.IsWhite)
                    r[CurrentX, i] = true;
                break;
            }
        }

        return r;
    }
        // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
