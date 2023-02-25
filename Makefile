STEAMAPPS = $${HOME}/.steam/steam/steamapps
GAME_DIR = ${STEAMAPPS}/common/ChilloutVR
CONFIG_DIR = ${STEAMAPPS}/compatdata/661130/pfx/drive_c/users/steamuser/AppData/LocalLow/Alpha\ Blend\ Interactive/ChilloutVR

.PHONY: build
build:
	ln -sf $(GAME_DIR) ChilloutVR
	msbuild

.PHONY: install
install:
	ln -sf $(shell pwd)/Output/ConfigHack.dll $(GAME_DIR)/Mods/

.PHONY: links
links:
	-mv -n $(CONFIG_DIR)/camera.config $(CONFIG_DIR)/camera.config.old
	-mv -n $(CONFIG_DIR)/game.config $(CONFIG_DIR)/game.config.old
	-mv -n $(CONFIG_DIR)/menu.config $(CONFIG_DIR)/menu.config.old
	-mv -n $(CONFIG_DIR)/moderationIndex.json $(CONFIG_DIR)/moderationIndex.json.old
	-mv -n $(CONFIG_DIR)/saved_calibrations.json $(CONFIG_DIR)/saved_calibrations.json.old
	-mv -n $(CONFIG_DIR)/UrlWhitelist.json $(CONFIG_DIR)/UrlWhitelist.json.old
	ln -sf /dev/null $(CONFIG_DIR)/camera.config
	ln -sf /dev/null $(CONFIG_DIR)/game.config
	ln -sf /dev/null $(CONFIG_DIR)/menu.config
	ln -sf /dev/null $(CONFIG_DIR)/moderationIndex.json
	ln -sf /dev/null $(CONFIG_DIR)/saved_calibrations.json
	ln -sf /dev/null $(CONFIG_DIR)/UrlWhitelist.json
