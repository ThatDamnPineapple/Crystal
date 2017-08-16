using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Crystal
{
	public class CrystalPlayer : ModPlayer
	{
		
		public bool ZoneCrystal = false;


		public override void UpdateBiomes()
		{
			ZoneCrystal = (CrystalWorld.CrystalTiles > 400);
		}
    }
}
