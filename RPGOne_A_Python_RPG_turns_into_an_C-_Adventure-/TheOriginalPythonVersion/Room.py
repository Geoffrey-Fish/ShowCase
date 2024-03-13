from Character import *
from Item import *
from Store import * #maybe for connecting them usefull?


class Room:
    def __init__(self, name, desc, pos_x, pos_y, npcs, enemies, items, weapons, armors):
        self.name = name
        self.desc = desc
        self.pos_x = pos_x
        self.pos_y = pos_y
        self.npcs = npcs
        self.enemies = enemies
        self.items = items
        self.weapons = weapons
        self.armors = armors

    def status(self): #maybe talk to the npc and so trigger the shop? shop works for now
        print(self.name)
        print(self.desc)
        print("ROOM: X: " + str(self.pos_x))
        print("ROOM: Y: " + str(self.pos_y))
        print("YOU SEE: ")
        for npc in self.npcs:
            print(npc.name)
        for enemy in self.enemies:
            print(enemy.name)
        for item in self.items:
            print(item.name)
        for weapon in self.weapons:
            print(weapon.name)
        for armor in self.armors:
            print(armor.name)
        for npc in self.npcs:
            print("\n\nTHE " + npc.name + " SAYS: " + npc.dialog + "\n\n") 
        
    def locate(self, player): #and what now?
        rooms = [start_room, peon_room,gem_room, orc_room, rat_room, stor, wallm1m1, wall1m1, wallm10, wallm11, wallm12, wall12, wall03, wall0m2]  
        for room in rooms:
            if room.pos_x == player.pos_x and room.pos_y == player.pos_y :
                return room   


# name,desc,pos_x,pos_y,npcs,enemies,items,weapons,armors


start_room = Room("START ROOM", "THIS IS THE STARTING ROOM", 0, 0, [friendly_wizard], [], [], [], [])
peon_room = Room("ORC PEON ROOM", "THIS IS THE ORC PEON ROOM", 0, 1, [], [orc_peon, orc_peewee, orc_boner], [], [], [])
gem_room = Room("GEM ROOM", "THIS IS THE GEM ROOM", 0, -1, [], [], [gem, gem, gem], [], [])
orc_room = Room("ORC ROOM", "THIS IS AN ORC ROOM", 0, 2, [], [orc_baba], [], [], [])
rat_room = Room("RAT ROOM", "LOOK! THE RAT MAN!", 1, 0, [rat_man], [], [], [], [])
stor = Room("STORE", "BUY IT NOW!", 1, 1, [store_clerk], [], [gem, gem, poison], [short_sword, stick], [leather_armor, towel]) # shit name because of problems otherwise, it calls store.status() wich leads to the store method...that brakes the game
# the store is a class for itself...
# these are just blockers, to be reworked laterwith waypoint tips
wallm1m1 = Room("WALL","NO WAY,TURN AROUND",-1,-1,[], [], [], [], [])
wall1m1 = Room("WALL","NO WAY,TURN AROUND",1,-1,[], [], [], [], [])
wallm10 = Room("WALL","NO WAY,TURN AROUND",-1,0,[], [], [], [], [])
wallm11 = Room("WALL","NO WAY,TURN AROUND",-1,1,[], [], [], [], [])
wallm12 = Room("WALL","NO WAY,TURN AROUND",-1,2,[], [], [], [], [])
wall12 = Room("WALL","NO WAY,TURN AROUND",1,2,[], [], [], [], [])
wall03 = Room("WALL","NO WAY,TURN AROUND",0,3,[], [], [], [], [])
wall0m2 = Room("WALL","NO WAY,TURN AROUND",0,-2,[], [], [], [], [])
