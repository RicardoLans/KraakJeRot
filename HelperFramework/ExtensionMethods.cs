using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HelperFramework
{
	public static class ExtensionMethods
	{
		public static T Next<T>(this List<T> list, ref int index)
		{
			index = ++index >= 0 && index < list.Count ? index : 0;
			return list[index];
		}

		public static T Previous<T>(this List<T> list, ref int index)
		{
			index = --index >= 0 && index < list.Count ? index : list.Count - 1;
			return list[index];
		}

		public static T FindChild<T>(this DependencyObject parent, string childName) where T : DependencyObject
		{
			if (parent == null)
				return null;
			T foundChild = null;

			int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
			for (int i = 0; i < childrenCount; i++)
			{
				var child = VisualTreeHelper.GetChild(parent, i);

				T childType = child as T;
				if (childType == null)
				{
					foundChild = FindChild<T>(child, childName);

					if (foundChild != null)
						break;
				}
				else if (!string.IsNullOrEmpty(childName))
				{
					var frameworkElement = child as FrameworkElement;
					if (frameworkElement != null && frameworkElement.Name == childName)
					{
						foundChild = (T)child;
						break;
					}
				}
				else
				{
					foundChild = (T)child;
					break;
				}
			}
			return foundChild;
		}

		public static T FindAncestor<T>(DependencyObject obj, String name = null) where T : DependencyObject
		{
			while (obj != null)
			{
				T o = obj as T;
				if (o != null)
				{
					if (!String.IsNullOrEmpty(name))
					{
						if ((String)o.GetValue(Canvas.NameProperty) == name)
						{
							return o;
						}
					}
					else
					{
						return o;
					}
				}
				obj = VisualTreeHelper.GetParent(obj);
			} return null;
		}
		public static T FindAncestor<T>(this UIElement obj, String name = null) where T : UIElement
		{
			return FindAncestor<T>((DependencyObject)obj, name);
		}

		/*		public static Point FindAncestorBounds<T>(DependencyObject obj, String name = null) where T : DependencyObject
				{
					Double top = 0;
					Double left = 0;
					while (obj != null)
					{
						top += Convert.ToDouble(obj.GetValue(Canvas.TopProperty));
						left += Convert.ToDouble(obj.GetValue(Canvas.LeftProperty));
						T o = obj as T;
						if (o != null)
						{
							if (!String.IsNullOrEmpty(name))
							{
								if ((String)o.GetValue(Canvas.NameProperty) == name)
								{
									break;
								}
							}
							else
							{
								break;
							}
						}
						obj = VisualTreeHelper.GetParent(obj);
					}
					return new Point(left, top);
				}
				public static Point FindAncestorBounds<T>(this UIElement obj, String name = null) where T : UIElement
				{
					return FindAncestorBounds<T>((DependencyObject)obj, name);
				}*/

		public static object CreateANewInstance(this Type type)
		{
			Assembly a = Assembly.Load(type.Assembly.FullName);
			return a.CreateInstance(type.FullName);
		}
	}
}