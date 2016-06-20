using Refractored.Xam.TTS;

using Android.Content;
using Android.OS;
using Android.Speech;
using Android.Widget;

using System;
using System.Linq;

namespace PULSE
{
	public static class Speech
	{
		public static void Speak(string TextToSpeak)
		{
			CrossTextToSpeech.Current.Speak(TextToSpeak);
		}

		public class SpeechRec : Java.Lang.Object, IRecognitionListener
		{ 
			private Action<string> onGot;
			public bool listening;
			private Context context;

			public SpeechRec(Action<string> onGot, Context context)
			{
				this.onGot = onGot;
				this.context = context;
				listening = false;
			}

			public void OnReadyForSpeech(Bundle bundle)
			{
			}

			public void OnBeginningOfSpeech()
			{
				listening = true;
			}

			public void OnRmsChanged(float rmsdB)
			{
			}

			public void OnBufferReceived(byte[] buffer)
			{
			}

			public void OnEndOfSpeech()
			{
				onGot(null);
				listening = false;
			}

			public void OnError(SpeechRecognizerError error)
			{
				if (error != SpeechRecognizerError.NoMatch)
					Toast.MakeText(context, "Speech recognition error: " + error.ToString(), ToastLength.Long).Show();
			}

			public void OnResults(Bundle results)
			{
				var commands = results.GetStringArrayList(SpeechRecognizer.ResultsRecognition);
				string topcommand = commands.FirstOrDefault();
				onGot.Invoke(topcommand);
			}

			public void OnPartialResults(Bundle results)
			{
			}

			public void OnEvent(int eventType, Bundle bundle)
			{
			}
		}                             
	}
}

