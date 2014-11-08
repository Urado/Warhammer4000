///////////////////////////////////////////////////////////
//  Unit.cs
//  Implementation of the Class Unit
//  Generated by Enterprise Architect
//  Created on:      04-���-2014 12:01:12
//  Original author: Samurai
///////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Windows.Forms;
using System;

public class Unit 
{
	private int Alive = 0;
	private Effect[] Effects;
	public BasicModel[] Models;
	public BasicModel m_BasicModel;
	public Effect m_Effect;
    public Player w_Player;

	public Unit()
    {
        Models = new BasicModel[1];
        Models[0] = (BasicModel)new Infantry();
        m_BasicModel = Models[0];
        foreach(BasicModel w in Models)
        {
            w.w_Unit=this;
        }
	}

    public void Paint(PaintEventArgs e)
    {
        foreach(BasicModel B in Models)
        {
            B.Paint(e);
        }
    }

    public List<Wound> Shoot(Unit Target, int type, DiceGenerator d)
    {
        List<Wound> L=new List<Wound>{};
        foreach(BasicModel ShootModel in Models)
        {
            L.AddRange(ShootModel.Shoot(type,d));
        }
        return L;
    }
    public List<Wound> Wonding(Unit Sourse, List<Wound> Wounds, DiceGenerator DiceGen)
    {
        int n = Wounds.Count;
        int t=0,Majority=0;
        List<int> dices = DiceGen.manyD6(n);
        foreach(BasicModel m in Models)
        {
            t++;
            Majority += m.GetToughnes(Sourse);
        }

        char a = ' ';
        string TextDices = new string(a, 1);
        foreach (int d in dices)
        {
            char c = (char)('0' + d);
            TextDices += c;
            TextDices += " ";
        }
        MessageBox.Show(TextDices);

        Majority = Majority / t;
        for (int i = 0; i < n;i++)
        {
            if((Wounds[i].GetStrenght() - Majority + 4)>dices[i])
                Wounds[i].fail();
            if((Wounds[i].GetStrenght()- Majority +4 ) == 7 && dices[i]==6)
                Wounds[i].win();
            if (dices[i] == 1)
                Wounds[i].fail();
        }
        if (Wounds.Count != 0)
            Wounds[0].deleteFail(Wounds);
        return Wounds;
    }

    public BasicModel Furst(Unit Sourse)
    {
        for(int i=0;Models[i]!=m_BasicModel;i++)
        {
            if(Models[i].IsAlive()==0)
            {
                return Models[i];
            }
        }
        return null;
    }

    public void Save(int Cover, Unit Sourse, List<Wound> Wounds, DiceGenerator DiceGen)
    {
        int n = Wounds.Count;
        List<int> dices = DiceGen.manyD6(n);
        char a = ' ';
        string TextDices = new string(a, 1);
        foreach (int d in dices)
        {
            char c = (char)('0' + d);
            TextDices += c;
            TextDices += " ";
        }
        MessageBox.Show(TextDices);


        for (int i = 0; i < n; i++)
        {
            BasicModel m = Furst(Sourse);
            if (m == null)
                break;
            m.Save(Wounds[i], dices[i], Cover);
        }
    }

	~Unit()
    {

	}

	public virtual void Dispose(){

	}

}//end Unit