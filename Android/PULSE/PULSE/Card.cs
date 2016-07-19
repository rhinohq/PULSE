namespace PULSE
{
	public class Card
	{
		public string TextToSpeak { get; set; }

		public void Speak()
		{
			Speech.Speak(TextToSpeak ?? "");
		}
	}
}

