import random
from Item import *
from time import sleep
from subprocess import call

class Player:
    def __init__(self):
        self.name = "PLAYER"
        self.pos_x = 0
        self.pos_y = 0
        self.max_hp = None
        self.hp = self.max_hp
        self.xp = 0
        self.gp = 0
        self.st = None
        self.dex = None
        self.items = []
        self.weapons = [short_sword]
        self.armors = [leather_armor]
        self.dmg = self.weapons[0].dmg_value
        self.ar = self.armors[0].ar_value

    def status(self):
        print(self.name + "`S POS X: " + str(self.pos_x))
        print(self.name + "`S POS Y: " + str(self.pos_y))
        print("HP: " + str(self.hp))
        print("STR: " + str(self.st))
        print("DEX: " + str(self.dex))
        print("DMG: " + str(self.dmg))
        print("AR: " + str(self.ar))
        print("GP: " + str(self.gp))
        print("XP: " + str(self.xp))

        for item in self.items:
            print(item.name)
        for weapon in self.weapons:
            print(weapon.name)
        for armor in self.armors:
            print(armor.name)

    def user_input(self):
        user_input = input(">>> ").upper()
        return user_input

    def clear(self):
        _ = call('clear')

    def create(self):
        #player.status()
        print("CREATING YOU CHARACTER:")
        print("(N)AME YOUR CHARACTER")
        print("(R)OLL YOUR CHARACTER")
        print("(P)LAY GAME")
        user_input = self.user_input()
        if user_input == "N":
            print("WHAT IS YOUR NAME? ")
            user_input = self.user_input()
            self.name = user_input
            print(self.name + " ?\nSOUNDS ABOUT RIGHT.")
            sleep(1)
            self.create()
        elif user_input == "R":
            print(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::")
            print("LET`S SEE YOUR HEALTH...")
            print("ROLLING HP...")
            sleep(1)
            roll = self.roll_dice(20, 40)
            self.hp = roll
            print("YOU HAVE NOW " + str(self.hp) + " HP!")
            sleep(1)
            print("---------------------------------------------------------")
            print("LET`S SEE YOUR MUSCLES THEN...")
            print("ROLLING...")
            sleep(1)
            roll = self.roll_dice(20, 60)
            self.st = roll
            print("YOUR POWER IS " + str(self.st) + " !")
            sleep(1)
            print("---------------------------------------------------------")
            print("AT LAST YOUR DEXTERITY...")
            print("ROLLING...")
            sleep(1)
            roll = self.roll_dice(20, 60)
            self.dex = roll
            print(str(self.dex) + " IS YOUR DEXTERITY.")
            print("---------------------------------------------------------")
            sleep(1)
            self.create()
        elif user_input == "P":
            if self.name is None or self.hp is None:
                print(" FINISH MAKING YOUR CHARACTER!")
                print("---------------------------------------------------------")
                self.clear()
                self.create()
            else:
                print("PLAY THE GAME!")
                return 
        else:
            print("INVALID!\nCHOOSE AN OPTION:\n 'N', 'R' OR 'P'")
            print("---------------------------------------------------------")
            self.create()

    def roll_dice(self,min, max):
        roll = random.randint(min, max)
        print(self.name + " ROLLS: " + str(roll))
        return roll

    def inventory(self, room):
        def pick_up(room_obj_list, player_obj_list):
            #for obj in room_obj_list:
                #if obj in room_obj_list and len(room.enemies) == 0: #enemyscanning just for saftey purpose?
            if len(room_obj_list)> 0:
                for obj in room_obj_list:
                    print(obj.name) 
                    print("(P)ICK UP?\n| (N)EXT?\n| (B)ACK?")
                    user_input = self.user_input()
                    if user_input == "P":
                        print(self.name + " PICKS UP " + obj.name)
                        room_obj_list.remove(obj)
                        player_obj_list.append(obj)
                    elif user_input == "N":
                        continue
                    elif user_input == "B":
                        pass #or return?? or options call?
            else:
                print("THERE IS NOTHING!WANNA DROP INSTEAD?\n| (Y)ES\n| (N)O")
                user_input = self.user_input()
                if user_input == "Y":
                    drop(room)
                elif user_input == "N":
                    pass
                
        def drop(room):
            if len(self.items) == 0 and len(self.weapons) == 0 and len(self.armors) == 0:
                print("OH BOY,HOW DID YOU GET NEKKID???CYA...")
                self.grid(player)
            print("DROP:\n| (I)TEM ? \n| (W)EAPON ?\n| (A)RMOR ?")
            user_input = self.user_input()
            if user_input == "I":
                print("DROPPING ITEM")
                for item in self.items:
                    print("DROPPING " + item.name)
                    print("You sure?\n| (Y)ES\n| OR (N)O")
                    user_input = self.user_input()
                    if user_input == "Y":
                        self.items.remove(item)
                        room.items.append(item)
                    elif user_input == "N":
                        continue
                    else:
                        print("WRONG INPUT, DUDE.")
                        drop(room)
            elif user_input == "W":
                print("DROPPING WEAPON")
                for weapon in self.weapons:
                    print("DROPPING " + weapon.name)
                    print("You sure?\n| (Y)ES\n| OR (N)O")
                    user_input = self.user_input()
                    if user_input == "Y":
                        self.weapons.remove(weapon)
                        room.weapons.append(weapon)
                    elif user_input == "N":
                        continue
                    else:
                        print("WRONG INPUT, DUDE.")
                        drop(room)
            elif user_input == "A":
                print("DROPPING ARMOR")
                for armor in self.armors:
                    print("DROPPING " + armor.name)
                    print("You sure?\n| (Y)ES\n| OR (N)O")
                    user_input = self.user_input()
                    if user_input == "Y":
                        self.armors.remove(armor)
                        room.armors.append(armor)
                    elif user_input == "N":
                        continue
                    else:
                        print("WRONG INPUT, DUDE.")
                        drop(room)
            else:
                print("WRONG INPUT, GOOD LORD!")
                drop(room)
                
        print("INVENTORY OPTIONS: \n| (P)ICK UP \n| (D)ROP \n| (B)ACK")
        user_input = self.user_input() 
        if user_input == "P":
            print("LOOK AT THE ITEMS HERE:")
            sleep(1)
            pick_up(room.items, self.items)
            print("WHAT ABOUT THESE WEAPONS?")
            sleep(1)
            pick_up(room.weapons, self.weapons)
            print("SOME ARMOR, MAYBE?")
            sleep(1)
            pick_up(room.armors, self.armors)
        elif user_input == "D":
            drop(room)
        elif user_input == "B":
            print("GOING BACK TO MOVEMENT MENU")
            return

    def queue_free(self, room):
        if self.hp <= 0:
            print("YOU DED!!11ELF")
        for item in self.items:
            self.items.remove(item)
            room.items.append(item)
        for weapon in self.weapons:
            self.weapons.remove(weapon)
            room.weapons.append(weapon)
        for armor in self.armors:
            self.armors.remove(armor)
            room.armors.append(armor)
        #loop = False some kind of exit strategy


# Why the fuck now this following part in an external module???
player = Player()
