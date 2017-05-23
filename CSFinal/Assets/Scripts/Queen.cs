using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessMan {
    public override bool[,] PossibleMove() {
        bool[,] r = new bool[8, 8];

        ChessMan c;
        int i, j;

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

        // Up Left
        i = CurrentX;
        j = CurrentY;
        while (true) {
            i--;
            j++;
            if (i < 0 || j >= 8)
                break;

            c = BoardManager.Instance.ChessMans[i, j];
            if (c == null)
                r[i, j] = true;
            else {
                if (this.IsWhite != c.IsWhite)
                    r[i, j] = true;

                break;
            }
        }

        // Up Right
        i = CurrentX;
        j = CurrentY;
        while (true) {
            i++;
            j++;
            if (i >= 8 || j >= 8)
                break;

            c = BoardManager.Instance.ChessMans[i, j];
            if (c == null)
                r[i, j] = true;
            else {
                if (this.IsWhite != c.IsWhite)
                    r[i, j] = true;

                break;
            }
        }

        // Down Left
        i = CurrentX;
        j = CurrentY;
        while (true) {
            i--;
            j--;
            if (i < 0 || j < 0)
                break;

            c = BoardManager.Instance.ChessMans[i, j];
            if (c == null)
                r[i, j] = true;
            else {
                if (this.IsWhite != c.IsWhite)
                    r[i, j] = true;

                break;
            }
        }

        // Down Right
        i = CurrentX;
        j = CurrentY;
        while (true) {
            i++;
            j--;
            if (i >= 8 || j < 0)
                break;

            c = BoardManager.Instance.ChessMans[i, j];
            if (c == null)
                r[i, j] = true;
            else {
                if (this.IsWhite != c.IsWhite)
                    r[i, j] = true;

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
