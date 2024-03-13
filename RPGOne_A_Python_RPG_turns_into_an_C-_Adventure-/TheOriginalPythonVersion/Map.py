'''Here could be a map for the player in ASCII mode.
Or at least a dictionary with visited places!'''
from Room import * #do I need these imports??
from Player import *
from Item import *

class Map:
    def __init__(self,name):
        self.name = name


    def path(self):
        '''like a way pointer''' #TODO
        pass

    def map_add(self,key,value):
        map[key] = (value) # dunno if this is right so
        print(map)

    def plan(self):
        print("\n||||||||||||||||||\n||||||none |||||||\n|none|orc  |none |\n|none|peon |store|\n|none|start|rat  |\n|none|gem  |none |\n||||||none |||||||\n||||||||||||||||||")
	#should learn how to make a cli table for proper show of that map
map = Map("MAP") #placeholder[start_room, peon_room, gem_room, orc_room, rat_room, store])
