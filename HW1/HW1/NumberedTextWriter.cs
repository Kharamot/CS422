using System;
using System.IO;
using System.Text;
namespace CS420
{
	public class NumberedTextWriter : TextWriter
	{
		private int line; private TextWriter tw;

		public NumberedTextWriter (TextWriter wrapThis)
		{
			line = 1;
			tw = wrapThis;
		}

		public NumberedTextWriter(TextWriter wrapThis, int startLine)
		{
			line = startLine;
			tw = wrapThis;
		}

		public override Encoding Encoding {get { return tw.Encoding;}}

		public override void WriteLine (string value)
		{
			tw.WriteLine (line + ": " + value);
			line++;
		}
	}
}

