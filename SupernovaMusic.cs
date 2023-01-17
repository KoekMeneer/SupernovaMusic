using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using SupernovaMusic.Common.SceneEffects;

namespace SupernovaMusic
{
	public class SupernovaMusic : Mod
	{
		public Mod Supernova { get; private set; }

		public SupernovaMusic()
		{
			MusicAutoloadingEnabled = true;
		}

		/// <summary>
		/// Activates on load and registers all music files
		/// </summary>
		private void RegisterMusic()
		{
			Logger.Info("Loading Music...");

			AddContent(new ModBossMusicSceneEffect(
				"nyctophobia", 
				GetSupernovaNpc("FlyingTerror")
			));
			Logger.Info("Registered: nyctophobia -> FlyingTerror");

			AddContent(new ModBossMusicSceneEffect(
				"anomaly",
				GetSupernovaNpc("HarbingerOfAnnihilation")
			));
			Logger.Info("Registered: anomaly -> HarbingerOfAnnihilation");

		}
		public override void Load()
		{
			// Get the Supernova mod
			Supernova = ModLoader.GetMod("Supernova");

			// Check if we found the supernova mod
			//
			if (Supernova == null)
			{
				Logger.Warn("This mod requires the Supernova mod. Make sure it is downloaded and active.");
				return; // Don't load this mod
			}

			// Register mod music
			RegisterMusic();
			base.Load();
		}

		/// <summary>
		/// Gets a Supernova mod npc by name.
		/// </summary>
		/// <param name="name">Name of the npc</param>
		/// <returns>An NPC or null when none where found</returns>
		private ModNPC? GetSupernovaNpc(string name)
		{
			// Try to find the npc
			//
			if (Supernova.TryFind(name, out ModNPC npc))
			{
				return npc;
			}

			Logger.Warn("GetSupernovaNpc(): Could not find npc with name '" + name + "'");
			return null;
		}
	}
}