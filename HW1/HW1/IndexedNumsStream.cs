using System;
using System.IO;

namespace CS420
{
	public class IndexedNumStream : Stream
	{
		private long currentStreamPos; private long strmLen;
		
		public IndexedNumStream (long len)
		{
			if (len < 0) {
				strmLen = 0;
			} else {
				strmLen = len;
			}
		}

		#region implemented abstract members of Stream

		public override void Flush ()
		{
			throw new NotImplementedException ();
		}

		public override long Seek (long offset, SeekOrigin origin)
		{
			throw new NotImplementedException ();
		}

		public override void SetLength (long value)
		{
			if (value < 0) {
				strmLen = 0;
			} else {
				strmLen = value;
			}
				
		}

		public override int Read (byte[] buffer, int offset, int count)
		{
			if ((offset + count) > buffer.Length) {
				throw new ArgumentException ();
			} else if (offset < 0 || count < 0) {//offset count is negitive.
				throw new ArgumentOutOfRangeException ();
			} else if (buffer == null) {//buffer is null
				throw new ArgumentNullException ();
			} else if (CanRead == false) {//The stream does not support reading.
				throw new NotSupportedException ();
			} else {
				if (count > (Length - Position)) {
					count = unchecked((int)(Length - Position));
				}
				for (int i = 0; i < count; i++) {
					buffer [i + offset] = (byte)(Position++ % 256);
				}
			}
			return count;
		}

		public override void Write (byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException ();
		}

		public override bool CanRead {
			get {
				return true;
			}
		}

		public override bool CanSeek {
			get {
				return true;
			}
		}

		public override bool CanWrite {
			get {
				return false;
			}
		}

		public override long Length {
			get {
				return strmLen;
			}
		}

		public override long Position {
			get {
				return currentStreamPos;
			}
			set {
				if (value < 0) {
					currentStreamPos = 0;
				} else if (value > strmLen) {
					currentStreamPos = strmLen;
				} else {
					currentStreamPos = value;
				}
			}
		}

		#endregion
	}
}

