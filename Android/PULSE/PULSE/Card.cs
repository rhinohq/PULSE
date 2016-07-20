using Android.Graphics;

namespace PULSE
{
	public class Card
	{
		public CardType CardType { get; set; }
		public string TextToSpeak { get; set; }
		public string CardTitle { get; set; }

		public string CardText { get; set; }
		public Bitmap CardImage { get; set; }
		public string CardUrl { get; set; }

		public void Speak()
		{
			Speech.Speak(TextToSpeak ?? "");
		}
	}

	public enum CardType
	{
		None,
		Text = 1,
		Image = 2,
		Video = 3,
		WebView = 4
	}
}
