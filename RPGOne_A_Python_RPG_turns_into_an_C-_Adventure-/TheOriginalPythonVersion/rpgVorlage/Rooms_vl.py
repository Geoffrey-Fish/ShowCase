from Character import *
from Item import *

class Room():
  def __init__(self,name,desc,pos_x,pos_y,npcs,enemies,items,weapons,armors):
    self.name = name
    self.desc = desc
    self.pos_x = pos_x
    self.pos_y = pos_y
    self.npcs = npcs
    self.enemies = enemies
    self.items = items
    self.weapons = weapons
    self.armors = armors

  def status(self):
    print(self.name)
    print(self.desc)
    print("ROOM: X: " + str(self.pos_x))
    print("ROOM Y: " + str(self.pos_y))

    print("YOU SEE:")
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

###       name,desc,pos_x,pos_y,npcs,enemies,items,weapons,armors

start_room = Room("START ROOM","THIS IS THE STARTING ROOM",0,0,[friendly_wizard],[],[],[],[])

peon_room = Room("ORC PEON ROOM","THIS IS THE ORC PEON ROOM",0,1,[],[orc_peon,orc_peon,orc_peon],[],[],[])

gem_room = Room("GEM ROOM","THIS IS THE GEM ROOM",0,-1,[],[],[gem,gem,gem],[],[]) 
