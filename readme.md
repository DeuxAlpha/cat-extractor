# Introduction

This project is a console application for X4 Foundations that simply
extracts all .cat files it finds in the specified folder, as well as all
sub folders, and extracts them to 'unpacked' folders within the
directory the .cat files were encountered.  
This helps to understand the structure of the original files vs.
extensions by keeping them together.

# Disclaimer

This program relies on the
[XRCatTool](https://www.egosoft.com/download/x_rebirth/bonus_en.php?download=589)
in order to actually extract the .cat files.  
The program expects XRCatTool to be specified in your `Path` variable.
If this is not the case, you will need to specify the location yourself
via providing the location as a parameter.  
The program utilizes `cmd.exe` by default to call XRCatTool. If you do
not have that, you will need to provide a different executor (e.g.
`bash`).

# Options

You may run `Extractor --help` to see various options you can run the
extractor with.

# Requirements

- [.NET Core Runtime](https://dotnet.microsoft.com/download)