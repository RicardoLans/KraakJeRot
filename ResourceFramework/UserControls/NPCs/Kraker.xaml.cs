using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ResourceFramework.UserControls.NPCs.Arms;
using ResourceFramework.UserControls.NPCs.Hands;
using ResourceFramework.UserControls.NPCs.Heads;
using ResourceFramework.UserControls.NPCs.Necks;
using ResourceFramework.UserControls.NPCs.Shirts;
using ResourceFramework.UserControls.NPCs.Trousers;

namespace ResourceFramework.UserControls.NPC
{
	public partial class Kraker : UserControl
	{
		private List<UIElement> shirts = new List<UIElement> { new Shirt1 { Name = "Shirt" }, new Shirt2 { Name = "Shirt" }, new Shirt3 { Name = "Shirt" }, new Shirt4 { Name = "Shirt" }, new Shirt5 { Name = "Shirt" }, new Shirt6 { Name = "Shirt" } };
		private List<UIElement> heads = new List<UIElement> { new Head1 { Name = "Head" }, new Head2 { Name = "Head" }, new Head3 { Name = "Head" }, new Head4 { Name = "Head" }, new Head5 { Name = "Head" }, new Head2 { Name = "Head" }, };

		Random random = new Random((int)DateTime.Now.Ticks);

		public Kraker()
		{
			InitializeComponent();
			
			Kraker0.Children.Add(shirts[random.Next(0, 5)]);
			Kraker0.Children.Add(new Neck1 { Name = "Neck" });

			Kraker0.Children.Add(heads[random.Next(0, 5)]);
			Kraker0.Children.Add(new Trouser1 { Name = "Trouser" });

			Kraker0.Children.Add(new RightHand1 { Name = "RightHand" });
			Kraker0.Children.Add(new RightArm1 { Name = "RightArm" });

			Kraker0.Children.Add(new LeftHand1 { Name = "LeftHand" });
			Kraker0.Children.Add(new LeftArm1 { Name = "LeftArm" });
			
			foreach (UIElement ele in Kraker0.Children)
			{
				ele.Projection = new PlaneProjection();
				ele.RenderTransform = new CompositeTransform();
			}

		}
	}
}
