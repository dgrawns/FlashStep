using System;
using ThunderRoad;
using UnityEngine;

namespace FlashStep
{
	public class FlashStep : SpellCastCharge
	{
		public override void Fire(bool active)
		{
			base.Fire(active);
			float maxDistance = Vector3.Distance(Player.local.locomotion.transform.position, new Vector3(Player.currentCreature.centerEyes.transform.forward.x, Mathf.Clamp(Player.currentCreature.centerEyes.transform.forward.y, 0.05f, 100f), Player.currentCreature.centerEyes.transform.forward.z) * (float)this.flashStepDistance);
			RaycastHit raycastHit;
			bool flag = Physics.Raycast(Player.local.locomotion.transform.position, Player.currentCreature.centerEyes.transform.forward, out raycastHit, maxDistance, this.layer_mask);
			if (flag)
			{
				float num = Vector3.Distance(Player.local.locomotion.transform.position, raycastHit.collider.transform.position);
				bool flag2 = raycastHit.collider.gameObject.GetComponent<Creature>() != null;
				if (flag2)
				{
					Player.local.locomotion.transform.position += new Vector3(Player.currentCreature.centerEyes.transform.forward.x, 0f, Player.currentCreature.centerEyes.transform.forward.z) * (float)this.flashStepDistance;
					bool flag3 = this.customAudio == 1;
					if (flag3)
					{
						EffectInstance effectInstance = Catalog.GetData<EffectData>("FlashStepCharge", true).Spawn(Player.local.transform.position, Quaternion.identity, null, null, true, Array.Empty<Type>());
						effectInstance.Play(0);
					}
					bool flag4 = this.customAudio == 2;
					if (flag4)
					{
						EffectInstance effectInstance2 = Catalog.GetData<EffectData>("FlashStepCharge2", true).Spawn(Player.local.transform.position, Quaternion.identity, null, null, true, Array.Empty<Type>());
						effectInstance2.Play(0);
					}
					this.spellCaster.isFiring = false;
				}
				else
				{
					bool flag5 = raycastHit.collider.gameObject.GetComponent<Creature>() == null;
					if (flag5)
					{
						Player.local.locomotion.transform.position = new Vector3(raycastHit.point.x, 0f, raycastHit.point.z);
						bool flag6 = this.customAudio == 1;
						if (flag6)
						{
							EffectInstance effectInstance3 = Catalog.GetData<EffectData>("FlashStepCharge", true).Spawn(Player.local.transform.position, Quaternion.identity, null, null, true, Array.Empty<Type>());
							effectInstance3.Play(0);
						}
						bool flag7 = this.customAudio == 2;
						if (flag7)
						{
							EffectInstance effectInstance4 = Catalog.GetData<EffectData>("FlashStepCharge2", true).Spawn(Player.local.transform.position, Quaternion.identity, null, null, true, Array.Empty<Type>());
							effectInstance4.Play(0);
						}
						this.spellCaster.isFiring = false;
					}
				}
			}
			bool flag8 = !Physics.Raycast(Player.local.locomotion.transform.position, Player.currentCreature.centerEyes.transform.forward, out raycastHit, maxDistance, this.layer_mask);
			if (flag8)
			{
				Player.local.locomotion.transform.position += new Vector3(Player.currentCreature.centerEyes.transform.forward.x, Mathf.Clamp(Player.currentCreature.centerEyes.transform.forward.y, 0.05f, 100f), Player.currentCreature.centerEyes.transform.forward.z) * (float)this.flashStepDistance;
				bool flag9 = this.customAudio == 1;
				if (flag9)
				{
					EffectInstance effectInstance5 = Catalog.GetData<EffectData>("FlashStepCharge", true).Spawn(Player.local.transform.position, Quaternion.identity, null, null, true, Array.Empty<Type>());
					effectInstance5.Play(0);
				}
				bool flag10 = this.customAudio == 2;
				if (flag10)
				{
					EffectInstance effectInstance6 = Catalog.GetData<EffectData>("FlashStepCharge2", true).Spawn(Player.local.transform.position, Quaternion.identity, null, null, true, Array.Empty<Type>());
					effectInstance6.Play(0);
				}
				this.spellCaster.isFiring = false;
			}
		}

		public int flashStepDistance;

		public int customAudio;

		private int layer_mask = LayerMask.GetMask(new string[]
		{
			"Ragdoll",
			"NPC",
			"NPCGrabbedObject",
			"Ignore Raycast"
		});
	}
}
