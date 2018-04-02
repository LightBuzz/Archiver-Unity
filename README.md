# Archiver for Unity3D

Archiver for Unity3D is a powerful utility for compressing and decompressing files and folders in Unity 2017.3 or later. Moreover, using the built-in mechanism, you couldn't compress a folder with its subfolders and files.

Archiver makes compressing and decompressing amazingly easy, using just two lines of code:

```
Archiver.Compress(source, destination);   // Zip
Archiver.Decompress(source, destination); // Unzip
```
        
Where source and destination are the specified files and folders. You can run the included demo and test by yourselves.

## Installation

* Build the project in ```Release``` mode using Visual Studio 2017 or later.
* Drag and drop the ```LightBuzz.Archiver.dll``` to your Asset folder.
* In Unity, select ```Edit``` → ```Project Settings``` → ```Other Settings``` → ```Configuration``` and set the ```Scripting Runtime Version``` to ```.NET 4.6```.

## Compatibility

The archiving functionality is compatible with **Unity 2017.3** or later version. The following platforms are supported:

* iOS
* Android
* Windows Standalone (x86 and x64)
* Universal Windows Platform (UWP)

## Examples

To use the Archiver, first include a reference to the assembly:

```
using LightBuzz.Archiver;
```

### Compressing a single file

```
string source = @"C:\Users\LightBuzz\Desktop\Foo.txt";
string destination = @"C:\Users\LightBuzz\Desktop\Foo.zip";

Archiver.Compress(source, destination);
```
    
### Compressing a folder with all of its files and subfolders

```
string source = @"C:\Users\LightBuzz\Desktop\Foo";
string destination = @"C:\Users\LightBuzz\Desktop\Foo.zip";

Archiver.Compress(source, destination);
```
    
### Decompressing a zip file

```
string source = @"C:\Users\LightBuzz\Desktop\Foo.zip";
string destination = @"C:\Users\LightBuzz\Desktop\";

Archiver.Compress(source, destination);
```
    
That's it!

## Contributors
* [Vangos Pterneas](http://pterneas.com) from [LightBuzz](http://lightbuzz.com)

## License
You are free to use these libraries in personal and commercial projects by attributing the original creator. Licensed under [Apache v2 License](https://github.com/LightBuzz/archiver-unity/blob/master/LICENSE).

## Support Archiver
Do you use Archiver in your projects? Do you find it helpful? [Buy us a beer](https://paypal.me/lightbuzz)!
