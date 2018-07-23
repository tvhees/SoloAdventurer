using System;
using System.Collections;
using System.Collections.Generic;
using Core.Extensions;
using Core.Utilities;
using UnityEngine;

namespace SA._View {
	public class CardCollectionView : MonoBehaviour
	{
		[SerializeField]
		private int _numberOfCards;
		[SerializeField]
		private GameObject _cardViewPrefab;

		private GameObject[] _cards;

		void Start ()
		{
			_cards = _numberOfCards.Times(_ => fp.Reduce(Instantiate, SetAsChildOf(transform))(_cardViewPrefab));
		}

		Func<GameObject, GameObject> SetAsChildOf (Transform parent)
		{
			return gameObject => {
				gameObject.transform.SetParent(parent);
				return gameObject;
			};
		}

		public void DoForViews (Action<GameObject[]> cardViews)
		{
			cardViews.Invoke(_cards);
		}
	}
}