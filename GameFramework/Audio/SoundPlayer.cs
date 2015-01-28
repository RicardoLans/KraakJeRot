using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using HelperFramework;

namespace GameFramework.Audio
{
	public static class SoundPlayer
	{

		public static bool IsMuted { get; set; }
		private static bool IsPaused { get; set; }

		private static Dictionary<String, MediaElement> SoundLibrary
		{
			get;
			set;
		}

		public static void FillDictionary(ResourceDictionary dic)
		{
			SoundLibrary = new Dictionary<String, MediaElement>();
			foreach (DictionaryEntry item in dic)
				SoundLibrary.Add(item.Key.ToString().ToLower(), (MediaElement)item.Value);
		}

		public static void PlaySound(string soundName)
		{
			MediaElement ele;
			SoundLibrary.TryGetValue(soundName, out ele);
			if (ele != null)
				PlaySound(ele);
			if (ele == null) throw new ArgumentException("Music file or name doesn't exist");
		}

		public static void PlaySound(MediaElement element)
		{
			if (IsMuted) return;
			element.Stop();
			element.Play();
		}

		public static void ShuffleMute()
		{
			IsMuted = !IsMuted;
			BackgroundMusic.Pauze();
		}

		public static class BackgroundMusic
		{
			private static List<MediaElement> BackgroundSoundLibrary
			{
				get;
				set;
			}

			public static void FillBgDictionary(ResourceDictionary dic)
			{
				BackgroundSoundLibrary = new List<MediaElement>();
				foreach (DictionaryEntry item in dic)
					BackgroundSoundLibrary.Add((MediaElement)item.Value);
			}

			private static int _currentIndex;
			private static MediaElement _currentMusic;
			private static MediaElement _previousMusic;

			public static void Next()
			{
				_previousMusic = _currentMusic;
				_currentMusic = BackgroundSoundLibrary.Next(ref _currentIndex);
				PlaySound();
			}

			public static void Previous()
			{
				_previousMusic = _currentMusic;
				_currentMusic = BackgroundSoundLibrary.Previous(ref _currentIndex);
				PlaySound();
			}

			private static void PlaySound()
			{
				if (IsMuted) return;
				if (_previousMusic != null) _previousMusic.Stop();
				_currentMusic.MediaEnded += CurrentMusicMediaEnded;
				if (!IsPaused) _currentMusic.Stop();
				_currentMusic.Play();
				IsPaused = false;
			}

			public static void PlaySound(string soundName)
			{
				MediaElement ele;
				SoundLibrary.TryGetValue(soundName, out ele);
				if (ele != null)
				{
					_previousMusic = _currentMusic;
					_currentMusic = ele;
					PlaySound();
				}
				if (ele == null) throw new ArgumentException("Music file or name doesn't exist");
			}

			public static void Start()
			{
				if (BackgroundSoundLibrary == null) throw new ArgumentException("");
				if (_currentMusic == null) _currentMusic = BackgroundSoundLibrary[0];
				PlaySound();
			}

			public static void Stop()
			{
				if (_currentMusic == null) return;
				_currentMusic.Stop();
			}

			public static void Pauze()
			{
				if (_currentMusic == null) return;
				if (IsPaused)
				{
					PlaySound();
					IsPaused = false;
				}
				else
				{
					_currentMusic.Pause();
					IsPaused = true;
				}
			}

			private static void CurrentMusicMediaEnded(object sender, RoutedEventArgs e)
			{
				Next();
			}
		}

	}
}
