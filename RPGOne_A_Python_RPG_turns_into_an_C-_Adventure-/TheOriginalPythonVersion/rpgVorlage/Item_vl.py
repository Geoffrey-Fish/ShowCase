import random
from Item import *

class Item():
  def __init__(self,name,dmg_value,ar_value,gp_value,weight):
    self.name = name
    self.dmg_value = dmg_value
    self.ar_value = ar_value
    self.gp_value = gp_value
    self.weight = weight
    
  def status(self):
    print(self.name)

    print("DMG VALUE: " + str(self.dmg_value))
    print("AR VALUE: " + str(self.ar_value))
    print("GP VALUE: " + str(self.gp_value))
    print("WEIGHT " + str(self.weight))


###   INSTANCE ITEM name,dmg_value,ar_value,gp_value,weight
###   WEAPONS
short_sword = Item("SHORT SWORD",random.randint(1,6),0,50,3)
wizards_staff = Item("WIZARDS STAFF",random.randint(1,40),0,400,4)
###   ARMORS
leather_armor = Item("LEATHER ARMOR",0,2,80,12)
cloth_robe = Item("CLOTH ROBE",0,1,5,2)
###   ITEMS
gem = Item("GEM",0,0,100,.1)

