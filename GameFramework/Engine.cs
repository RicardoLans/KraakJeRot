using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GameFramework
{
	public class Engine
	{
		private List<UserControl> _list = new List<UserControl>();
		private Boolean _hasStackPnl;
		private Random _random = new Random();

		public Engine(Canvas canvas = null, StackPanel stackPanel = null)
		{
			if (canvas == null) return;

			Container = canvas;

			StackPnl = stackPanel;
			if (_hasStackPnl = (StackPnl != null))
			{
				Container.Children.Add(StackPnl);
			}

			Application.Current.Host.Content.Resized += delegate { OnResize(); };
		}


		#region Virtual methods;
		public virtual void OnResize()
		{
			//_list.ForEach(control =>
			//{
			//    control.Width = Application.Current.Host.Content.ActualWidth;
			//    control.Height = Application.Current.Host.Content.ActualHeight;
			//});
		}

		public virtual void Add<T>(T item, Boolean container = true)
		{
			UserControl i = item as UserControl;
			i.Name = String.Format("UC_{0}_{1}_{2}", i.Name, DateTime.Now.Millisecond, _random.Next());
			UserControl c = i.Content as UserControl;
			if (c != null)
			{
				c.Name = String.Format("UCC_{0}_{1}_{2}", c.Name, DateTime.Now.Millisecond, _random.Next());
			}

			_list.Add(i);

			if (container && Container != null)
			{
				if (_hasStackPnl)
				{
					StackPnl.Children.Add(i);
				}
				else
				{
					if (Container.Dispatcher.CheckAccess())
					{
						DoAdd(i);
					}
					else
					{
						Container.Dispatcher.BeginInvoke(new DoAddDelegate(DoAdd), i);
					}
				}
			}
		}
		private void DoAdd(UserControl uc)
		{
			try
			{
				Container.Children.Add(uc);
			}
			catch (ArgumentException)
			{
				Container.Children.Add(uc);
			}
		}
		private delegate void DoAddDelegate(UserControl uc);
		public virtual void Add<T>(params T[] items)
		{
			Array.ForEach(items, item => Add(item));
		}
		public virtual void Add<T>(Boolean container = true, params T[] items)
		{
			Array.ForEach(items, item => Add(item, container));
		}

		public virtual void Empty()
		{
			Container.Children.Clear();
			_list.Clear();
		}

		public virtual void Remove<T>(T item, Boolean container = true)
		{
			UserControl i = item as UserControl;
			_list.Remove(i);
			if (container && Container != null)
			{
				if (_hasStackPnl)
				{
					StackPnl.Children.Remove(i);
				}
				else
				{
					Container.Children.Remove(i);
				}
			}
		}
		public virtual void Remove<T>(params T[] items)
		{
			Array.ForEach(items, item => Remove(item));
		}
		public virtual void Remove<T>(Boolean container = true, params T[] items)
		{
			Array.ForEach(items, item => Remove(item, container));
		}

		public virtual void Renew()
		{
			if (Renewed != null)
			{
				Renewed(this);
			}
		}
		public virtual void Renew<T>(T item, Boolean container = true)
		{
			Empty();
			Add(item, container);
		}
		public virtual void Renew<T>(params T[] items)
		{
			_list.ForEach(i => Remove(i));
			Add(items);
		}
		public virtual void Renew<T>(Boolean container = true, params T[] items)
		{
			_list.ForEach(i => Remove(i));
			Add(container, items);
		}

		public virtual T GetElement<T>()
		{
			return _list.OfType<T>().FirstOrDefault();
		}

		public virtual void Update(TimeSpan elapsed)
		{
			if (Updated != null)
			{
				Updated(this);
			}
		}
		#endregion Virtual methods;


		#region Virtual getters/setters;
		public virtual Canvas Container { get; protected set; }

		public virtual StackPanel StackPnl { get; protected set; }
		#endregion Virtual getters/setters;


		#region Virtual events;
		public delegate void OnUpdate(object sender);
		public virtual event OnUpdate Updated;

		public delegate void OnRenew(object sender);
		public virtual event OnRenew Renewed;
		#endregion Virtual events;


		#region Hidden;
		protected List<T> GetList<T>()
		{
			return _list.Cast<T>().ToList();
		}
		#endregion Hidden;

	}
}
