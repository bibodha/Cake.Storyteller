# Cake.Storyteller

[![Build status](https://ci.appveyor.com/api/projects/status/hd7ibs6f6a22f56y/branch/master?svg=true)](https://ci.appveyor.com/project/bibodha/cake-storyteller/branch/master)

Storyteller 3 Alias for Cake

## Installation
Install Storyteller tool and this addin

```
#tool "nuget:?package=Storyteller&version=3.0.1"
#addin "Cake.Storyteller"
```

## Usage
```C#
Task("StOpen")
    .Does(() => {
        StorytellerOpen("src/Cake.StoryTeller.Integration", new StorytellerSettings{
            Timeout = 300,
            Profile = "Phantom"
        });
    });

Task("StRun")
    .Does(() => {
        StorytellerRun("src/Cake.StoryTeller.Integration", new StorytellerSettings{
            Timeout = 300,
            Profile = "Phantom",
            Retries = 1
        });
    });
```

### Settings
Available settings are:
```
string ResultsPath
string Workspace
string ExcludeTags
bool Open
string Csv
string Json
string Dump
string Build
string Profile
int Timeout
string Lifecycle
bool TeamCity
string Config
int Retries
```

Refer to [Storyteller Documentation](http://storyteller.github.io/documentation/)
