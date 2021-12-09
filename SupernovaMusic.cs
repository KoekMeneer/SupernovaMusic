using Terraria;
using Terraria.ModLoader;

namespace SupernovaMusic
{
	public class SupernovaMusic : Mod
	{
		public override void UpdateMusic(ref int music, ref MusicPriority priority)
		{
			// Get the Supernova mod
			Mod supernova = ModLoader.GetMod("Supernova");

			// Check if we found the supernova mod
			// If not we can't add music to the supernova mod
			if (supernova != null)
			{
				// Check if the Flying Terror boss is active
				if (NPC.AnyNPCs(supernova.NPCType("FlyingTerror")))
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/b_ft_nyctophobia");
					priority = MusicPriority.BossLow;
				}
			}

			base.UpdateMusic(ref music, ref priority);
		}
	}
}