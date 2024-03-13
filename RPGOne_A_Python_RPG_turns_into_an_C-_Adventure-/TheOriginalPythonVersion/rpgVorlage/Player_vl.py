import random
from Item import *

class Player():
  def __init__(self):
    self.name = "PLAYER"
    self.pos_x = 0
    self.pos_y = 0
    self.max_hp = 20
    self.hp = self.max_hp
    self.st = 60
    self.dex = 60
    self.gp = 0
    self.xp = 0
    self.items = []
    self.weapons = [short_sword]
    self.armors = [leather_armor]
    self.dmg = self.weapons[0].dmg_value
    self.ar = self.armors[0].ar_value

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
      print(item.name)
    for weapon in self.weapons:
      print(weapon.name) 
    for armor in self.armors:
      print(armor.name)
     
  

  def user_input(self):
    user_input = input(">>> ").upper()
    return user_input

  def create(self):
    player.status()
    print("CREATE YOUR CHARACTER")
    print("(N)AME YOUR CHARACTER")
    print("(R)OLL YOUR STATS")
    print("(P)LAY GAME")

    user_input = self.user_input()

    if user_input == "N":
      print("WHAT IS YOUR NAME")
      user_input = self.user_input()
      self.name = user_input
      self.create()

    elif user_input == "R":
      print("ROLLING STATS")
      #user_input = self.user_input()

      print("ROLLING HP")
      roll = self.roll_die(20)
      self.hp = roll

      print("ROLLING STRENGTH")
      roll = self.roll_die(100)
      self.st = roll

      print("ROLLING DEXTERITY")
      roll = self.roll_die(100)
      self.dex = roll

      self.create()

    elif user_input == "P":
      print("PLAY THE GAME")
      if self.name == None or self.hp == None:
        print("FINISH MAKING YOUR CHARACTER")
        self.create()
    else:
      print(" INVALID CHOOSE AN OPTION N, R, P")
      self.create()

  def roll_die(self,die):
    roll = random.randint(0,die)
    print(self.name + " ROLLS: " + str(roll))
    return roll

  def inventory(self,room):
    
    def pick_up(room_obj_list,player_obj_list):
      for obj in room_obj_list:  
        if obj in room_obj_list and len(room.enemies) == 0:
          print("(P)ICK UP?")
          user_input = self.user_input()
          if user_input == "P":
            
              print(self.name + " PICKS UP " + obj.name )
              room_obj_list.remove(obj)
              player_obj_list.append(obj)
           
        else:
          pass
          

    def drop(room):
      print("DROP (I)TEM | (W)EAPON | (A)RMOR ")
      user_input = self.user_input()
      if user_input == "I":
        print("DROPPING ITEM")
        for item in self.items:
          print("DROPPING " + item.name)
          self.items.remove(item)
          room.items.append(item)

        
      elif user_input == "W":
        print("DROPPING WEAPON")
        
      elif user_input == "A":
        print("DROPPING ARMOR")
        
      else:
        pass


      
    print("INVENTORY OPTIONS (P)ICK UP | (D)ROP | (ENTER) TO RETURN")
    user_input = self.user_input()

    if user_input == "P":
      pick_up(room.items,self.items)
      pick_up(room.weapons,self.weapons)
      pick_up(room.armors,self.armors)
    elif user_input == "D":
      drop(room)
    else:
      print("GOING BACK TO MOVEMENT MENU")

player = Player()

