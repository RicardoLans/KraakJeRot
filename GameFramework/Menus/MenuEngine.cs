using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace GameFramework.Menus
{
	public class MenuEngine : Engine
	{
		private Menu _previous, _current;
	
		public MenuEngine(Canvas canvas) : base(canvas) { }

		public override void Add<T>(T item, Boolean container = true)
		{
			Menu m = item as Menu;
			if (_current == null) _current = m;
			base.OnResize();
			m.MenuEngineReference = this;
			base.Add(m);
		}

		private List<Menu> GetList()
		{
			return base.GetList<Menu>();
		}

		public Boolean IsElement<T>()
		{
			return _current.GetType() == typeof(T);
		}

		public void Previous()
		{
			var temp = _previous;
			_previous = _current;
			_current = temp;
			Show();
		}

		public void Show()
		{
			HideAll();
			List<Menu> menus = GetList();
			menus[menus.IndexOf(_current)].Show();
		}
		public void Show<T>() where T : Menu
		{
			_previous = _current;
			List<Menu> menus = GetList();
			_current = menus.OfType<T>().FirstOrDefault();
			Show();
		}

		public void Hide(Int32 index)
		{
			List<Menu> menus = GetList();
			menus[index].Hide();
		}
		public void Hide(Menu menu)
		{
			List<Menu> menus = GetList();
			Hide(menus.IndexOf(menu));
		}
		public void HideAll()
		{
			List<Menu> menus = GetList();
			menus.ForEach(Hide);
		}

		public override void Update(TimeSpan elapsed)
		{
			//base.Update(elapsed);
			GetList().ForEach(item => item.Update(elapsed));
			if (Updated != null)
				Updated(this, _current);
		}

		#region Events;
		public new delegate void OnUpdate(object sender, Menu menu);
		public new event OnUpdate Updated;
		#endregion Events;

	}
}