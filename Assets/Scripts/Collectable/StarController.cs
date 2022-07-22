using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StarController : MonoBehaviour
{
	private int stars = 0;

	public void PickupStar()
	{
		++stars;
	}

	public int Star
	{
		get
		{
			return stars/2;
		}

	}
}
