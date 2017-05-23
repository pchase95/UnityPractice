using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessMan : MonoBehaviour {
    public bool Moved { get; set; }
    public int CurrentX { set; get; }
    public int CurrentY { get; set; }
    public bool IsWhite;

    public void SetPosition(int x, int y) {
        CurrentX = x;
        CurrentY = y;
    }

    public virtual bool[,] PossibleMove() {
        return new bool[8, 8];
    }

	// Use this for initialization
	void Start () {
        Moved = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
