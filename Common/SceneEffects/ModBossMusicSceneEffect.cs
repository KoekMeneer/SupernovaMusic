using log4net.Repository.Hierarchy;
using Terraria;
using Terraria.ModLoader;

namespace SupernovaMusic.Common.SceneEffects
{
	[Autoload(false)]
	public class ModBossMusicSceneEffect : ModSceneEffect
	{
		private readonly string _musicName;

		private readonly int _npcType;

		public ModBossMusicSceneEffect(string musicName, ModNPC npc)
			:this(musicName, npc.Type)
		{
		}

		public ModBossMusicSceneEffect(string musicName, int npcType)
		{
			_musicName	= musicName;
			_npcType	= npcType;
		}

		public override string Name => base.Name + $"/{_musicName}";

		public override int Music => MusicLoader.GetMusicSlot(Mod, $"Assets/Music/{_musicName}");

		public override bool IsSceneEffectActive(Player player)
		{
			// Check if any of our boss npc is active
			//
			if (NPC.AnyNPCs(_npcType))
			{
				return true;
			}
			return false;
		}
		public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
	}
}
