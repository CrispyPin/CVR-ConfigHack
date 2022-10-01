# ConfigHack
This mod allows you to still save game settings after symlinking the regular config file to /dev/null as described in [this thread](https://github.com/ValveSoftware/Proton/issues/6044#issuecomment-1207293309). You should only need to do this if you are using VR.

You should still symlink the following files to /dev/null: `camera.config`, `game.config`, `UrlWhitelist.json`, `moderationIndex.json`. They can usually be found in `~/.steam/steam/steamapps/compatdata/661130/pfx/drive_c/users/steamuser/AppData/LocalLow/Alpha Blend Interactive/ChilloutVR/`

I may add support for saving `camera.config`, `moderationIndex.json` and `UrlWhitelist.json` in the future, but right now it only handles `game.config`(renamed to `game2.config`).

