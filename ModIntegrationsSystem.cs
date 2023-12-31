using Terraria.Localization;
using Terraria.ModLoader;

namespace SupernovaMusic
{
	public class ModIntegrationsSystem : ModSystem
	{
		public override void PostSetupContent()
		{
			HandleIntegrationMusicDisplay();
		}

		private void HandleIntegrationMusicDisplay()
		{
			if (SupernovaMusic.Instance.musicDisplay == null)
			{
				return;
			}

			MusicDisplay_AddMusic("HarbingerOfAnnihilation", "theexiiedfeiiow");
			MusicDisplay_AddMusic("FlyingTerror", "theexiiedfeiiow");
		}
		private void MusicDisplay_AddMusic(string songKey, string authorKey)
		{
			short slot = (short)MusicLoader.GetMusicSlot(Mod, $"Assets/Music/{songKey}");
			SupernovaMusic.Instance.musicDisplay.Call("AddMusic", slot, Language.GetTextValue("Mods.SupernovaMusic.ModSupport.MusicDisplay.SongNames." + songKey), Language.GetTextValue("Mods.SupernovaMusic.ModSupport.MusicDisplay.Authors." + authorKey), Mod.DisplayName);
		}
	}
}
