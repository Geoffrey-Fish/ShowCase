import random
from Item import *


class Character:
    def __init__(self, name, pos_x, pos_y, max_hp, st, dex, gp, xp,
     items, weapons, armors, dialog):
        self.name = name
        self.pos_x = pos_x
        self.pos_y = pos_y
        self.max_hp = max_hp
        self.hp = self.max_hp
        self.st = st
        self.dex = dex
        self.gp = gp
        self.xp = xp
        self.items = items
        self.weapons = weapons
        self.armors = armors
        self.dmg = self.weapons[0].dmg_value
        self.ar = self.armors[0].ar_value
        self.dialog = dialog

    def status(self):
        print(self.name)
        print(str(self.name) + " POS X: " + str(self.pos_x))
        print(str(self.name) + " POS Y: " + str(self.pos_y))
        print("HP: " + str(self.hp))
        print("STR: " + str(self.st))
        print("DEX: " + str(self.dex))
        print("DMG: " + str(self.dmg))
        print("AR: " + str(self.ar))
        print("GP: " + str(self.gp))
        print("XP: " + str(self.xp))

        for item in self.items:
            print("ITEMS: ")
            print(item.name)
        for weapon in self.weapons:
            print("WEAPONS: ")
            print(weapon.name)
        for armor in self.armors:
            print("ARMORS: ")
            print(armor.name)

    def roll_dice(self, min, max):
        roll = random.randint(min, max)
        print(self.name + " ROLLS: " + str(roll))
        return roll

    def dialog(self): # test for chat
        print(self.dialog)

    def queue_free(self, room):
        print(self.name + " IS DEAD.")
        for item in self.items:
            self.items.remove(item)
            room.items.append(item)
        for weapon in self.weapons:
            self.weapons.remove(weapon)
            room.weapons.append(weapon)
        for armor in self.armors:
            self.armors.remove(armor)
            room.armors.append(armor)

# name, pos_x, pos_y, max_hp, st, dex, gp, xp, items, weapons, armors

orc_peon = Character("ORC PEON", 0, 0, 6, 30, 60, 50, 20,
                     [gem], [short_sword], [leather_armor],
                     "DIE DIE DIE BART, DIE!!!")

orc_peewee = Character("ORC PEEWEE", 0, 0, 6, 30, 60, 50, 20,
                     [gem], [short_sword], [leather_armor],
                     "DIEDABADUU!!!")

orc_boner = Character("ORC BONER", 0, 0, 6, 30, 60, 50, 20,
                     [gem], [short_sword], [leather_armor],
                         "DER BART, DER!!!")

orc_baba = Character("ORC BABA", 0, 0, 6, 30, 60, 50, 20,
                     [gem], [short_sword], [leather_armor],
                         "LOREM IPSUM!!!")


friendly_wizard = Character("FRIENDLY WIZARD", 0, 0, 6, 30, 60, 50, 20,
                            [], [wizards_staff], [cloth_robe],
                            "HELLO ADVENTURER I AM A FRIENDLY WIZARD.I HAVE BROUGHT YOU TO THIS REALITY!")

rat_man = Character("RAT MAN", 1, 2, 5, 10, 20, 2, 5,
                    [poison], [stick], [towel], "RAT TITTIES,FRESH RAT TITTIES!!!")

store_clerk = Character("STORE CLERK", 1, 0, 2, 3, 4, 5, 5,
                        [gem, minor_health], [stick], [towel], "Hi THERE, STRANGER")
