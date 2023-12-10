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
	class Program
	{
		static string BytesArrayToString(byte[] data)
		{
			var sb = new StringBuilder("new byte[] { ");

			foreach (var b in data)
			{
				sb.Append(b + ", ");
			}

			sb.Append("}");
			return sb.ToString();
		}
		static void Main(string[] args)
		{
			{
				var in_string = "1234567890_1234567890_1234567890_1234567890";
				var in_bytes = Encoding.ASCII.GetBytes(in_string);
				var out_bytes = LZ4Ctrl.Lz4Pack(in_bytes);
				Console.WriteLine(BytesArrayToString(out_bytes));
				Console.WriteLine($"out_bytes len: {out_bytes.Length}");
			}

			Console.WriteLine();
			Console.WriteLine();

			{
				var in_bytes = new byte[] { 4, 34, 77, 24, 100, 112, 185, 32, 0, 0, 0, 185, 49, 50, 51, 52, 53, 54, 55, 56, 57, 48, 95, 11, 0, 0, 11, 0, 0, 22, 0, 176, 95, 49, 50, 51, 52, 53, 54, 55, 56, 57, 48, 0, 0, 0, 0, 153, 61, 16, 238, };
				var out_bytes = LZ4Ctrl.Lz4Unpack(in_bytes);
				Console.WriteLine(BytesArrayToString(out_bytes));
				Console.WriteLine($"out_bytes string: {Encoding.UTF8.GetString(out_bytes)}");
				Console.WriteLine($"out_bytes len: {out_bytes.Length}");
			}
		}
	}
}
