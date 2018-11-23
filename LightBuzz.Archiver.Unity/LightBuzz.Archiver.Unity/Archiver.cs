using System;
using System.IO;
using System.IO.Compression;

namespace LightBuzz.Archiver
{
    /// <summary>
    /// Compresses and decompresses single files and folders.
    /// </summary>
    public static class Archiver
    {
        public static readonly string Extension = ".zip";

        /// <summary>
        /// Compresses a folder (including its subfolders) or file.
        /// </summary>
        /// <param name="source">The fodler or file to compress.</param>
        /// <param name="destination">The compressed zip file.</param>
        /// <param name="replaceExisting">Choose whether you'll replace the file if it already exists.</param>
        public static void Compress(string source, string destination, bool replaceExisting = true)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException("Source path is null or empty.");
            }

            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentNullException("Destination path is null or empty.");
            }

            if (Path.GetExtension(destination) != Extension)
            {
                throw new ArgumentException("Destination path is not valid. You need to specify the name of a zip file, instead.");
            }
            
            if (replaceExisting && File.Exists(destination))
            {
                File.Delete(destination);
            }

            if (File.GetAttributes(source).HasFlag(FileAttributes.Directory))
            {
                // Compress a folder.
                ZipFile.CreateFromDirectory(source, destination);
            }
            else
            {
                // Compress a file.
                FileInfo file = new FileInfo(source);

                using (FileStream originalFileStream = file.OpenRead())
                {
                    if (file.Attributes != FileAttributes.Hidden & file.Extension != Extension)
                    {
                        using (FileStream compressedFileStream = File.Create(destination))
                        {
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);
                            }
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Compresses a folder, including all of its files and sub-folders.
        /// </summary>
        /// <param name="source">The folder containing the files to compress.</param>
        /// <param name="destination">The compressed zip file.</param>
        /// <param name="replaceExisting">Choose whether you'll replace the file if it already exists.</param>
        public static void Compress(DirectoryInfo source, FileInfo destination, bool replaceExisting = true)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source directory is null.");
            }

            if (destination == null)
            {
                throw new ArgumentNullException("Destination file is null.");
            }

            Compress(source.FullName, destination.FullName, replaceExisting);
        }

        /// <summary>
        /// Compresses a single file.
        /// </summary>
        /// <param name="source">The file to compress.</param>
        /// <param name="destination">The compressed zip file.</param>
        /// <param name="replaceExisting">Choose whether you'll replace the file if it already exists.</param>
        public static void Compress(FileInfo source, FileInfo destination, bool replaceExisting)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source directory is null.");
            }

            if (destination == null)
            {
                throw new ArgumentNullException("Destination file is null.");
            }

            Compress(source.FullName, destination.FullName, replaceExisting);
        }

        /// <summary>
        /// Decompresses the specified file to the specified folder.
        /// </summary>
        /// <param name="source">The compressed zip file.</param>
        /// <param name="destination">The directory where the file will be decompressed.</param>
        public static void Decompress(string source, string destination)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException("Source file path is null or empty.");
            }

            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentNullException("Destination path is null or empty.");
            }

            if (File.GetAttributes(source).HasFlag(FileAttributes.Directory))
            {
                throw new ArgumentException("Source is a directory. You need to specify the name of a zip file, instead.");
            }

            if (!File.GetAttributes(destination).HasFlag(FileAttributes.Directory))
            {
                throw new ArgumentException("Destination is not a directory. You need to specify the name of a directory, instead.");
            }

            if (!File.Exists(source))
            {
                throw new FileNotFoundException("Source file does not exist.");
            }

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            ZipFile.ExtractToDirectory(source, destination);
        }

        /// <summary>
        /// Decompresses the specified file to the specified folder.
        /// </summary>
        /// <param name="source">The compressed zip file.</param>
        /// <param name="destination">The directory where the file will be decompressed.</param>
        public static void Decompress(FileInfo source, DirectoryInfo destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source file is null.");
            }

            if (destination == null)
            {
                throw new ArgumentNullException("Destination directory is null.");
            }

            Decompress(source.FullName, destination.FullName);
        }
    }
}
