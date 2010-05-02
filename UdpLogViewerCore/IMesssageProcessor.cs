using System.Drawing;

namespace stej.Tools.UdpLogViewer.Core
{
    public interface IProcessor
    {
		/// <summary>
		/// Called to process the message.
		/// </summary>
        ProcessingResult Process(LogItem item, object[] parameters);

		/// <summary>
		/// Called when processor will be destroyed or the application finishes.
		/// </summary>
		void Close();

		/// <summary>
		/// If <c>true</c>, the processor is active.
		/// </summary>
		bool Enabled { get; set; }

		/// <summary>
		/// Name of the processor.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Detail info about the processor.
		/// </summary>
		string DetailsInfo { get; set; }
    }

    public class ProcessingResult
    {
        public bool Stop { get; set; }
		public bool ShowToUser { get; set; }
		public bool RuleIsMatching { get; set; }
        public Color? Color { get; set; }
        public Color? BackColor { get; set; }

        public static ProcessingResult ContinueWithProcessing()
        {
            return new ProcessingResult() { Stop = false, RuleIsMatching = false };
        }
		public static ProcessingResult StopSilently()
		{
			return new ProcessingResult() { Stop = true, ShowToUser = false, RuleIsMatching = true };
		}
        public static ProcessingResult Matches(Color? color, Color? backColor)
        {
            return new ProcessingResult() { 
				Stop = true, ShowToUser = true, RuleIsMatching = true, Color = color, BackColor = backColor };
        }
    }
}
