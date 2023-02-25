# ConfigHack
## Why does it exist?
On some systems, having *any* regular config file for ChilloutVR will cause the game to crash after about 2 minutes, when using Proton in VR. It can be worked around by symlinking the files to `/dev/null`, but then of course you always have the default settings when you start. This mod saves the main settings in a separate file. I don't know why this works but it does.

[This thread](https://github.com/ValveSoftware/Proton/issues/6044#issuecomment-1207293309) describes the issue a bit more.

## Usage
Install [Melonloader](https://melonwiki.xyz/#/README?id=linux-instructions).

Download the [latest release of ConfigHack](https://github.com/CrispyPin/CVR-ConfigHack/releases). Put the dll in the `Mods` folder and create the necessary `/dev/null` symlinks (back up any settings you want to keep first):
```sh
cd ~/.steam/steam/steamapps/compatdata/661130/pfx/drive_c/users/steamuser/AppData/LocalLow/Alpha\ Blend\ Interactive/ChilloutVR/
ln -sf /dev/null camera.config
ln -sf /dev/null game.config
ln -sf /dev/null menu.config
ln -sf /dev/null moderationIndex.json
ln -sf /dev/null saved_calibrations.json
ln -sf /dev/null UrlWhitelist.json
```
If you are installing from source (or just download the `Makefile`), use `make links` to automate this process. The makefile will also first rename any existing configs to `<name>.old`.

## Status
- [x] `game.config`
- [x] `saved_calibrations.json`
- [ ] `camera.config`
- [ ] `moderationIndex.json`
- [ ] `UrlWhitelist.json`
- [ ] `menu.config`

I may add support for saving more of these in the future.


