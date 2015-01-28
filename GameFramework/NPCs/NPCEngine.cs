using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace GameFramework.NPCs
{
	public class NPCEngine : Engine
	{
		public NPCEngine(Canvas canvas = null) : base(canvas) { }

		public List<NPC> GetList()
		{
			return GetList<NPC>();
		}

		public NPC GetItemByType<T>()
		{
			return GetList().FirstOrDefault();
		}

		public override void Update(TimeSpan elapsed)
		{
			base.Update(elapsed);
			GetList().Where(npc => !npc.Dead).ToList().ForEach(npc => npc.Update(elapsed));
		}
	}
}