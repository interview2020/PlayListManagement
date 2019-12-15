# PlayListManagement
PlayListManagement is a console application for managing playlists. The application provides the following features.

1. Add an existing song to an existing playlist.
2. Add a new playlist for an existing user; the playlist should contain at least one existing song.
3. Remove an existing playlist.

The application is written in .NET Core 3.0 using C#.  .NET Core is a free and open-source, managed computer software framework for Windows, Linux, and macOS operating systems. It is a cross-platform successor to .NET Framework.

##### Prerequisites

​	Install [.NET Core SDK 3.0](https://dotnet.microsoft.com/download) 

​	*Note: Details on how to run .NET Core on Mac and Linux can be found [here](https://docs.microsoft.com/en-us/dotnet/core/tutorials/cli-create-console-app#prerequisites).*

### **How to run the application**

A distributable copy of the build is uploaded to the "publish" folder. Copy this folder to the local machine. Open the command prompt and navigate to the copied folder. Provide execute permission for the application.  e.g. (chmod 777  <app name>)

The application takes 3 arguments. The application can be called from the command line as follows:

```
PlayListManagement.exe <input-file> <changes-file> <output-file>
```

e.g.  PlayListManagement.exe mixtape-data.json change-data.json output.json

The input, change and output files can reside in the sub folder as well. In that case, provide the file path in the argument. Ensure the folder/files have proper access privileges for the application to read from file and create/write to a file.

A sample of the input (mixtape-data.json) and change (change-data.json) file is uploaded to the git repo for reference. These files are in the "publish" folder as well to test right from the folder once it is copied locally.

*Note: In the current state, format validation of the json is not done and the application may crash if the format is not right.* 

**The format and usage of change file is as follows:**

​	Change file consists of 3 sections

- Additions - Used of all new data additions. The addition of new songs to an existing playlist is specified here. To do so, specify the Playlist Id and User Id along with the new songs to be added to the playlist as shown in the change-data.json file. For creation of the new playlist the application expects the new Playlist Id, existing User Id and the list of existing song Id's.
- Updates - Used for all update actions. ( The updates will completely updates the item with the new data provided. Not implemented)
- Deletes - Used for all delete action. For playlist removal, specify the Playlist Id and User Id as shown in the sample file change-data.json file.

### Handling extremely large input files

The application needs modifications to handle extremely large files. Changes should be applied while reading the file, processing and writing the file.

Changes for reading the file:

- Use memory mapped files. A memory-mapped file maps the contents of a file to an application's logical address space. This can be used to create views of parts of the file. Details can be found [here](https://docs.microsoft.com/en-us/dotnet/api/system.io.memorymappedfiles.memorymappedfile?view=netcore-3.0).
- Another option is to Load the data to a DB by reading each section of the files as chunks. Make the changes in the DB. In this case, once DB is loaded, all the subsequent runs will only need the change set file.

Changes for processing the file:

- Parallel processing for items that does not have conflicting changes. e.g. Add/Updates for the playlist for the different users. Need more analysis on how this can be done.

Changes for writing the files:

- Use memory mapped files. Changes are automatically propagated to disk when the file is unmapped.
- Write the file as chunks asynchronously. Details can be found [here](https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream.writeasync?view=netcore-3.0).

