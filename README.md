# HEICtoJPG

Converter for HEIC files to jpg or png

ToDo:
All possible command line format and features:
HeicConvert.exe /source = "{source directory}"  /target = "{target directory}"  /{jpg|png} {/delete}
Example:

HeicConvert.exe /source = "C:\MyPath" /target = "D:\SomeOtherFolder\SubFolder\" /jpg

HeicConvert.exe /source = "C:\MyPath" /target = "D:\SomeOtherFolder\SubFolder\" /png

HeicConvert.exe /source ="C:\MyPath" /target="D:\SomeOtherFolder\SubFolder\" /jpg /delete

If you don't want to specify the source and target dir, you can just use this format, and it will process all the HEIC files in the current DOS directory.:

HeicConvert.exe /jpg

HeicConvert.exe /jpg /delete

User can specify a /target flag without specifying a /source flag. In this case, all procesing is done on HEIC files found current DOS directory and the location of the converted files will be as the user specified in the /target flag. Example

HeicConvert.exe /target="D:\SomeOtherFolder\SubFolder\" /jpg /delete
