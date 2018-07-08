using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Components
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(SpriteRenderer))]
	public class UpdateSortOrderByHeight : MonoBehaviour {
		[SerializeField] private bool _everyFrame;
		private Transform _transform;
		private SpriteRenderer _renderer;
		void OnEnable ()
		{
			_transform = GetComponent<Transform>();
			_renderer = GetComponent<SpriteRenderer>();
		}

		void Start()
		{
			UpdateSortingOrder();
		}
		
		// Update is called once per frame
		void Update ()
		{
			if (_everyFrame && _transform.hasChanged)
			{
				UpdateSortingOrder();
				_transform.hasChanged = false;
			}
		}

		void UpdateSortingOrder () {
			_renderer.sortingOrder = Mathf.CeilToInt(-transform.position.y * 1000);
		}
	}
}
