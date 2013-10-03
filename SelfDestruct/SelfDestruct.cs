using System;
using UnityEngine;

namespace SelfDestruct
{
	public class SelfDestruct : PartModule
	{
		[KSPEvent(guiActive=true, guiName="Explode")]
		public void explode()
		{
			Part[] partsToExplode = this.getParts (); // Pour pas se couper l'herbe sous les pieds, (on peut pas supprimer des éléments d'une liste en même temps qu'on itère dessus)

			foreach (Part p in partsToExplode) {
				p.explode ();
				p.Die ();
			}

			this.part.explode ();
			this.vessel.Die ();

		}

		private Part[] getParts() {
			Part[] parts = new Part[this.vessel.Parts.Count];

			int i = 0;
			foreach (Part p in this.vessel.Parts)
				parts[i++] = p;

			return parts;
		}
	}
}