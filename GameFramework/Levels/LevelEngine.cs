using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace GameFramework.Levels
{
	public class LevelEngine : Engine
	{

		public LevelEngine(Canvas canvas)
			: base(canvas)
		{
			CurrentIndex = 0;
		}

		private Int32 _currentIndex;
		public Int32 CurrentIndex
		{
			get
			{
				return _currentIndex;
			}
			set
			{
				_currentIndex = value;
				if (_currentIndex >= GetList().Count) _currentIndex = 0;
				if (_currentIndex <= -1) _currentIndex = GetList().Count - 1;
			}
		}

		public List<Level> GetList()
		{
			return base.GetList<Level>();
		}

		public Level GetCurrentLevel()
		{
			return GetList()[CurrentIndex];
		}

		public void Next()
		{
			Hide();

			if (BeforeNextLevel != null)
			{
				BeforeNextLevel(this);
			}

			var prev = CurrentIndex++;
			if (prev + 1 >= GetList().Count)
			{
				if (Finished != null)
				{
					Finished(this);
				}
			}
			else
			{
				Show();
				if (NextLevel != null)
				{
					NextLevel(this);
				}
			}
		}

		public void Show()
		{
			Show(CurrentIndex);
		}
		public void Show(Int32 index)
		{
			if (index == 0 && Started != null)
			{
				Started(this);
			}
			GetList()[index].Show();
		}

		public void Hide()
		{
			Hide(CurrentIndex);
		}
		public void Hide(Int32 index)
		{
			GetList()[index].Hide();
		}

		public override void Update(TimeSpan elapsed)
		{
			base.Update(elapsed);

			foreach (Level level in GetList())
			{
				if (!level.Done)
				{
					level.Update(elapsed);
				}
			}

			if (GetCurrentLevel().Done)
			{
				Next();
			}
		}

		#region Events;
		public delegate void OnFinished(object sender);
		public event OnFinished Finished;

		public delegate void OnNext(object sender);
		public event OnNext NextLevel;

		public delegate void BeforeNext(object sender);
		public event BeforeNext BeforeNextLevel;

		public delegate void OnStart(object sender);
		public event OnStart Started;
		#endregion Events;
	}
}