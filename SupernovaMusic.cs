using Terraria.ModLoader;

namespace SupernovaMusic
{
	public class SupernovaMusic : Mod
	{
		public static SupernovaMusic Instance { get; private set; }

		public Mod supernova = null;
		public Mod musicDisplay = null;

		public SupernovaMusic()
		{
			Instance = this;
		}

		public override void Load()
		{
			supernova = null;
			ModLoader.TryGetMod("SupernovaMod", out supernova);
			musicDisplay = null;
			ModLoader.TryGetMod("MusicDisplay", out musicDisplay);
		}
		public override void Unload()
		{
			supernova = null;
			musicDisplay = null;
			Instance = null;
		}
	}
}