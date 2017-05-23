using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessMan {
    public override bool[,] PossibleMove() {
        bool[,] r = new bool[8, 8];
        ChessMan c, c2, c3, c4;
        int i, j;

        // Top Side
        i = CurrentX - 1;
        j = CurrentY + 1;
        if (CurrentY != 7) {
            for (int k = 0; k < 3; k++) {
                if (i >= 0 || i < 8) {
                    c = BoardManager.Instance.ChessMans[i, j];
                    if (c == null)
                        r[i, j] = true;
                    else if (this.IsWhite != c.IsWhite)
                        r[i, j] = true;
                }
                i++;
            }
        }

        // Down Side
        i = CurrentX - 1;
        j = CurrentY - 1;
        if (CurrentY != 0) {
            for (int k = 0; k < 3; k++) {
                if (i >= 0 || i < 8) {
                    c = BoardManager.Instance.ChessMans[i, j];
                    if (c == null)
                        r[i, j] = true;
                    else if (this.IsWhite != c.IsWhite)
                        r[i, j] = true;
                }
                i++;
            }
        }

        // Middle Left
        if (CurrentX != 0) {
            c = BoardManager.Instance.ChessMans[CurrentX - 1, CurrentY];
            if (c == null)
                r[CurrentX - 1, CurrentY] = true;
            else if (this.IsWhite != c.IsWhite)
                r[i, j] = true;
        }

        // Middle Left
        if (CurrentX != 7) {
            c = BoardManager.Instance.ChessMans[CurrentX + 1, CurrentY];
            if (c == null)
                r[CurrentX + 1, CurrentY] = true;
            else if (this.IsWhite != c.IsWhite)
                r[i, j] = true;
        }

        // Castle Right
        if (!Moved) {
            c = BoardManager.Instance.ChessMans[CurrentX + 3, CurrentY];
            c2 = BoardManager.Instance.ChessMans[CurrentX + 1, CurrentY];
            c3 = BoardManager.Instance.ChessMans[CurrentX + 2, CurrentY];
            if (!c.Moved && c2 == null && c3 == null) {
                r[CurrentX + 3, CurrentY] = true;
            }
        }

        // Castle Right
        if (!Moved) {
            c = BoardManager.Instance.ChessMans[CurrentX - 4, CurrentY];
            c2 = BoardManager.Instance.ChessMans[CurrentX - 1, CurrentY];
            c3 = BoardManager.Instance.ChessMans[CurrentX - 2, CurrentY];
            c4 = BoardManager.Instance.ChessMans[CurrentX - 3, CurrentY];
            if (!c.Moved && c2 == null && c3 == null && c4 == null) {
                r[CurrentX - 4, CurrentY] = true;
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
