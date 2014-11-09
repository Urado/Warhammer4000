///////////////////////////////////////////////////////////
//  Infantry.cs
//  Implementation of the Class Infantry
//  Generated by Enterprise Architect
//  Created on:      04-���-2014 12:01:10
//  Original author: Samurai
///////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Drawing;

public class Infantry : BasicModel {

	private int ArmorSave = 7;
	private int Leadership;
	private int Toughnes;

	public Infantry()
    {
        x = y = 100;
        BalisticSkill = 3;
        WeaponSkill = 3;
        Strength = 3;
        Toughnes = 3;
        ArmorSave = 5;
        Weapons = new Weapon[1];
        Weapons[0] = new Weapon();
        m_Weapons = Weapons[0];
        foreach(Weapon w in Weapons)
        {
            w.w_BasicModel = this;
        }
	}

    public override int Save(Wound x, int dice,int Cover)
    {
        int ASave = ArmorSave;
        if (x.GetAP() <= ASave)
            ASave = 7;
        ASave = Math.Min(ASave, Math.Min(Cover, InvulnerableSave));
        if(ASave>dice)
        {
            Wound--;
        }
        if (Wound <= 0)
        {
            Alive = 1;
            return 1;
        }
        return 0;
    }

	~Infantry()
    {

	}

	public override void Paint(PaintEventArgs e,Player now)
    {
        SolidBrush B;
        if (w_Unit.w_Player == now)
            B = new SolidBrush(Color.Snow);
        else
            B = new SolidBrush(Color.DarkRed);
        if(Alive==0)
            e.Graphics.FillEllipse(B, x-50, y-50, 100, 100);
	}

}//end Infantry