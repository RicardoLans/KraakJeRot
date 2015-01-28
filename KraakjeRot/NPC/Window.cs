using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameFramework.Levels;
using HelperFramework;
using Action = GameFramework.NPCs.AI.Action;

namespace KraakjeRot.NPC
{
	public class Window : GameFramework.Levels.Window
	{
		private static ResourceFramework.UserControls.NPCs.Window _window;

		private Random _rand = new Random();
		private Kraker _kraker;

		public Window(Rect positionAndSize)
			: base(_window = new ResourceFramework.UserControls.NPCs.Window(), positionAndSize)
		{
			NPC = new Kraker { Position = new Point(0, 0), CollisionBound = _window.Parent as FrameworkElement };
			_kraker = NPC as Kraker;

			Canvas npcSurface = _window.FindName("NPCSurface") as Canvas;
			if (npcSurface == null) throw new NotImplementedException("No NPCSurface implemented");
			npcSurface.Children.Add(NPC);


			Action walk = new Action(1000, 3000);
			walk.onAction += WalkOnAction;
			_kraker.AI.Actions.Add(walk);

			Action switchWeapon = new Action(3000, 10000);
			switchWeapon.onAction += SwitchWeaponOnAction;
			_kraker.AI.Actions.Add(switchWeapon);

			Action shoot = new Action(1000, 5000);
			shoot.onAction += ShootOnAction;
			_kraker.AI.Actions.Add(shoot);
		}

		void ShootOnAction(object sender)
		{
			GeneralTransform objGeneralTransform = Level.Player.CollisionRoot.TransformToVisual(_kraker.CollisionRoot);
			Vector v = (Vector)objGeneralTransform.Transform(new Point(0, 0));
			Double rad = MathHelpers.GetAngleFromVector(v);
			Int32 angle = (Int32)MathHelpers.RadiansToDegrees(rad);

			Int32 random = _rand.Next(0, 2);
			if (random == 0) angle += 10;
			else if (random == 2) angle -= 10;

			_kraker.WeaponEngine.CurrentWeapon.ProjectoryAngle = 180 - angle;
			_kraker.Fire();
		}

		void SwitchWeaponOnAction(object sender)
		{
			_kraker.ShuffleWeaponUp();
		}

		void WalkOnAction(object sender)
		{
			Int32 random = _rand.Next(0, 1000) % 2;
			if (random == 1) _kraker.MoveRight(this);
			else _kraker.MoveLeft(this);
		}
	}
}