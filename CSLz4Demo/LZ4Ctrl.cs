using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using K4os.Compression.LZ4;
using K4os.Compression.LZ4.Streams;

namespace CSLz4Demo
{
	public class LZ4Ctrl
	{
		public static byte[] Lz4Pack(byte[] in_data)
		{
			using (var data_dst = new MemoryStream())
			{
				using (var src = new MemoryStream(in_data))
				using (var dst = LZ4Stream.Encode(data_dst))
				{
					src.CopyTo(dst);
				}

				return data_dst.ToArray();
			}
		}

		public static byte[] Lz4Unpack(byte[] in_data)
		{
			using (var data_dst = new MemoryStream())
			{
				using (var in_stream = new MemoryStream(in_data))
				using (var decoder = LZ4Stream.Decode(in_stream))
				{
					decoder.CopyTo(data_dst); ;
				}

				return data_dst.ToArray();
			}
		}
	}
}
