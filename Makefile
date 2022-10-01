GAME_DIR=$${HOME}/.steam/steam/steamapps/common/ChilloutVR

build:
	ln -sf $(GAME_DIR) ChilloutVR
	msbuild

install: build
	ln -sf $(shell pwd)/Output/ConfigHack.dll $(GAME_DIR)/Mods/
