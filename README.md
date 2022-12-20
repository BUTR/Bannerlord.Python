# Bannerlord.IronPython
<p align="center">
  <a href="https://github.com/BUTR/Bannerlord.Python" alt="Logo">
    <img src="https://staticdelivery.nexusmods.com/mods/3174/images/4252/4252-1658955784-1316861016.png" />
  </a>
  </br>
  <a href="https://github.com/BUTR/Bannerlord.Python" alt="Lines Of Code">
    <img src="https://aschey.tech/tokei/github/BUTR/Bannerlord.Python?category=code" />
  </a>
  <a href="https://www.codefactor.io/repository/github/butr/bannerlord.python">
    <img src="https://www.codefactor.io/repository/github/butr/bannerlord.python/badge" alt="CodeFactor" />
  </a>
  <a href="https://codeclimate.com/github/BUTR/Bannerlord.Python/maintainability">
    <img alt="Code Climate maintainability" src="https://img.shields.io/codeclimate/maintainability-percentage/BUTR/Bannerlord.Python">
  </a>
  </br>
  <a href="https://codecov.io/gh/BUTR/Bannerlord.Python">
    <img src="https://codecov.io/gh/BUTR/Bannerlord.Python/branch/dev/graph/badge.svg" />
  </a>
  </br>
  <a href="https://www.nexusmods.com/mountandblade2bannerlord/mods/4252" alt="NexusMods IronPython">
    <img src="https://img.shields.io/badge/NexusMods-IronPython%20Support-yellow.svg" />
  </a>  
  <a href="https://www.nexusmods.com/mountandblade2bannerlord/mods/4252" alt="NexusMods IronPython">
    <img src="https://img.shields.io/endpoint?url=https%3A%2F%2Fnexusmods-version-pzk4e0ejol6j.runkit.sh%3FgameId%3Dmountandblade2bannerlord%26modId%3D4252" />
  </a>
  <a href="https://www.nexusmods.com/mountandblade2bannerlord/mods/4252" alt="NexusMods IronPython">
    <img src="https://img.shields.io/endpoint?url=https%3A%2F%2Fnexusmods-downloads-ayuqql60xfxb.runkit.sh%2F%3Ftype%3Dunique%26gameId%3D3174%26modId%3D4252" />
  </a>
  <a href="https://www.nexusmods.com/mountandblade2bannerlord/mods/4252" alt="NexusMods IronPython">
    <img src="https://img.shields.io/endpoint?url=https%3A%2F%2Fnexusmods-downloads-ayuqql60xfxb.runkit.sh%2F%3Ftype%3Dtotal%26gameId%3D3174%26modId%3D4252" />
  </a>
  <a href="https://www.nexusmods.com/mountandblade2bannerlord/mods/4252" alt="NexusMods IronPython">
    <img src="https://img.shields.io/endpoint?url=https%3A%2F%2Fnexusmods-downloads-ayuqql60xfxb.runkit.sh%2F%3Ftype%3Dviews%26gameId%3D3174%26modId%3D4252" />
  </a>
  </br>
</p>

This is an experimental module for installing modules written in [IronPython3](https://github.com/IronLanguages/ironpython3).  
Requires [BUTRLoader](https://www.nexusmods.com/mountandblade2bannerlord/mods/2513) v1.8.2 to be installed and the game to be run via [BUTRLoader](https://www.nexusmods.com/mountandblade2bannerlord/mods/2513). We will try to create a workaround for running the game via Vortex in the future.

## For Players
Make sure that [BUTRLoader](https://www.nexusmods.com/mountandblade2bannerlord/mods/2513) is installed and the game is run via [BUTRLoader](https://www.nexusmods.com/mountandblade2bannerlord/mods/2513).  
[Bannerlord.Harmony](https://www.nexusmods.com/mountandblade2bannerlord/mods/2006) and [Bannerlord.ButterLib](https://www.nexusmods.com/mountandblade2bannerlord/mods/2018) are also required!

## For Modders
Use [this](https://github.com/BUTR/Bannerlord.Python/tree/master/src/Bannerlord.IronPythonExample) as an example of how to create a IronPython module. We'll create a dotnet template once we are sure the template is correct.  
We don't have anyone who knows Python enough to provide support. Please check [IronPython3 documentation](https://ironpython.net/documentation/dotnet/) on how to interact with C#, the documentation contains enough examples.  
Please note that IronPython does not provide all features of Python3! [Check the CPython differences](https://github.com/IronLanguages/ironpython3/blob/master/Documentation/differences-from-c-python.md) and [the Whats New files on GitHub](https://github.com/IronLanguages/ironpython3)!
