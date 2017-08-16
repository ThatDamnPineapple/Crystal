using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

namespace Crystal
{
	public class CrystalWorld : ModWorld
	{
		public static int CrystalTiles = 0;
        

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex == -1)
			{
				// Shinies pass removed by some other mod.
				return;
			}
			tasks.Insert(ShiniesIndex +  1, new PassLegacy("CrystalBiomeGen", delegate(GenerationProgress progress)
			{
                progress.Message = "Growing Crystals";
              for (int num = 0; num < 12; num++)
			  {
				  int xAxis = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
					int yAxis = WorldGen.genRand.Next((int)WorldGen.rockLayer + 200, Main.maxTilesY - 300);
				    WorldMethods.RoundHill(xAxis, yAxis, 100, 100, 45, true, (ushort)mod.TileType("CrystalBlock"));
					for (int C = 0; C < 60; C++)
					{
						int E = xAxis + Main.rand.Next(-115, 115);
						int F = yAxis + Main.rand.Next(-115, 115);
						WorldGen.PlaceTile(E, F, mod.TileType("GlowingCrystal2"));
					}
					for (int D = 0; D < 60; D++)
					{
						int E = xAxis + Main.rand.Next(-115, 115);
						int F = yAxis + Main.rand.Next(-115, 115);
						
							WorldGen.PlaceTile(E, F, mod.TileType("GlowingCrystal"));
						
					}
			  }
			}));
		}

		public override void PostWorldGen()
		{
			
        }
        

        public override void TileCountsAvailable(int[] tileCounts)
		{
			CrystalTiles = tileCounts[mod.TileType("CrystalBlock")];
		}
	}
}
