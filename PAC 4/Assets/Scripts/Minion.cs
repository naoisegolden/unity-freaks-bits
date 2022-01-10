using System;
using UnityEngine;

public class Minion : Collectible
{
	override public void Collected()
	{
		OnCollected?.Invoke();

		this.disappearable.Disappear();
	}
}