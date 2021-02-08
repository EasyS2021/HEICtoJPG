using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;
using System.IO;
using System.Threading;

namespace HEICtoJPG
{
	class Program
	{
		public static string imageType;
		static void Main(string[] args)
		{

			int fileLeft = 0;
			string sourcePath = "", targetPath = "";
			string[] filesInFolder;
			bool flag = false;

			if (args[0] == "/jpg" && args.Length > 1 && args[1] == "/delete")
			{
			
				flag = true;
			}
			if (args[0] == "/jpg")
			{
				sourcePath = Directory.GetCurrentDirectory();
				targetPath = sourcePath;

			}
			if (args.Length == 3 && args[0].Contains("/source") && args[1].Contains("/target") && args[2] == "/jpg")
			{
				sourcePath = GetPath(args[0]);
				targetPath = GetPath(args[1]);
			}
			if (args.Length == 4 && args[0].Contains("/source") && args[1].Contains("/target") && args[2] == "/jpg" && args[3] == "/delete")
			{
				sourcePath = GetPath(args[0]);
				targetPath = GetPath(args[1]);
				flag = true;
			}

			if (args.Length == 2 && args[0].Contains("/target") &&  args[1] == "/jpg")
			{
				sourcePath = Directory.GetCurrentDirectory();
				targetPath = GetPath(args[0]);
			}
			if (args.Length == 3 && args[0].Contains("/target") && args[1] == "/jpg" && args[2] == "/delete")
			{
				sourcePath = Directory.GetCurrentDirectory();
				targetPath = GetPath(args[0]);
			}
			imageType = args[0];
			filesInFolder = Directory.GetFiles(sourcePath);
			foreach (var file in filesInFolder)
			{
				string ext = Path.GetExtension(file).ToLower();
				if (ext == ".heic") fileLeft++;
			}
			foreach (var file in filesInFolder)
			{
				string ext = Path.GetExtension(file).ToLower();
				if (ext == ".heic")
				{
					Console.WriteLine(file);
					ConvertImage(file, targetPath);
				}
			}
	
			foreach (var file in filesInFolder)
			{
				string ext = Path.GetExtension(file).ToLower();
				if (ext == ".heic" && flag && File.Exists(file))
				{
					File.Delete(file);
					System.IO.File.Delete(file);

				}
			}
		
		}
		static void ConvertImage(string fileToConvert, string exportPath)
		{
			string exportFilePath = Path.Combine(exportPath, Path.GetFileNameWithoutExtension(Path.GetFileName(fileToConvert))) + ".jpg";
			string outFilename = Path.GetFileName(exportFilePath);
			string ext = Path.GetExtension(outFilename);
			string imageExtension = Path.GetExtension(fileToConvert).ToLower();
			string inFilename = Path.GetFileName(fileToConvert);

			if (File.Exists(exportFilePath) && (ext == ".jpg") || (ext == ".png"))
			{
				Console.WriteLine("Skipped file  " + inFilename + " becuase it has already been converted.");
				return;
			}
			if (imageExtension.Contains("heic") || imageExtension.Contains("png"))
			{
				Console.Write("Processing Item " + inFilename + "...");
				
				using (MagickImage image = new MagickImage(File.ReadAllBytes(fileToConvert)))
				{
					image.Write(exportFilePath);
					Console.WriteLine("Ok");
					
				}
			}
			else if (imageExtension.Contains("jpg"))
				File.Copy(fileToConvert, exportFilePath);
		}
		static string GetPath(string str)
		{
			
			string[] ptr = str.Split(new char[] { '=' });
			return ptr[1];

		}
	}
}
