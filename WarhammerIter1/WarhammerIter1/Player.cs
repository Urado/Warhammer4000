///////////////////////////////////////////////////////////
//  Player.cs
//  Implementation of the Class Player
//  Generated by Enterprise Architect
//  Created on:      04-���-2014 14:59:26
//  Original author: Samurai
///////////////////////////////////////////////////////////

using System.Collections.Generic;


public class Player {

	public Unit[] PlayersUnit;
    int m_PlayersUnit;

    public List<Unit> GetUnits()
    {
        List<Unit> L = new List<Unit> { };
        foreach(Unit u in PlayersUnit)
        {
            L.Add(u);
        }
        return L;
    }

	public Player()
    {
        PlayersUnit = new Unit[1];
        PlayersUnit[0] = new Unit();
        m_PlayersUnit = 1;
        foreach(Unit w in PlayersUnit)
        {
            w.w_Player = this;
        }
	}

	~Player()
    {

	}

}//end Player