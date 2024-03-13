from Character import *
from Item import *
from Room import *
from Player import *


class Game():
  def __init__(self):
    self.name = "GAME"

  def status(self):
    print(self.name + " IS INSTANTIATED")

  def grid(self,player):
    rooms = [start_room,peon_room,gem_room]

    ########################################
    #player.status()
    #self.options(player,rooms)
    ########################################

    player.status()
    self.options(player)

    for room in rooms:
      
      if player.pos_x == room.pos_x and player.pos_y == room.pos_y:
        room.status()
        player.inventory(room)

        for enemy in room.enemies:
          enemy.pos_x = room.pos_x
          enemy.pos_y = room.pos_y
          
          if enemy.pos_x == player.pos_x and enemy.pos_y == player.pos_y:


            if enemy.hp <=0:
              enemy.queue_free(enemy,room)     


  def battle(self,attacker,defender):
    
    def initative(attacker,defender):
      ###   INITIATIVE PHASE
      if attacker.roll_die(100) + (attacker.dex/5) >= defender.roll_die(100) + (defender.dex/5):
        print(attacker.name + " HAS INITIATIVE")
        ###  ATTACKER ATTACK PHASE
        to_hit(attacker,defender)
      else:
        print( defender.name + " HAS INITATIVE ")
        ###   DEFENDER ATTACK PHASE
        to_hit(defender,attacker)
      

    def to_hit(attacker,defender):
      print(attacker.name + " IS ATTACKING " + defender.name)

      if attacker.roll_die(100) >= defender.roll_die(100):
        print(attacker.name + " HITS " + defender.name )
        defender.hp -= attacker.dmg
        print(attacker.name + " DOES " + str(attacker.dmg) + " DAMAGE")
        print(defender.name + " NOW HAS " + str(defender.hp) + " HP")        
      else:
        print(attacker.name + " MISSES " + defender.name)

    ###    RUN BATTLE
    initative(attacker,defender)

    """
        ###   INITIATIVE PHASE
        attacker_roll = attacker.roll_die(100) + (attacker.dex/5) 
        defender_roll = defender.roll_die(100) + (defender.dex/5) 
        if attacker_roll >= defender_roll:
          print(attacker.name + " HAS INITIATIVE")
          ###  ATTACKER ATTACK PHASE
          attacker_roll = attacker.roll_die(100) + (attacker.dex/5) 
          defender_roll = defender.roll_die(100) + (defender.dex/5)
          if attacker_roll >= defender_roll:
            print(attacker.name + " HITS " + defender.name)

        else:
          print(defender.name + " HAS INITIATIVE")
          ###  DEFENDER ATTACK PHASE
          #defender_roll = defender.roll_die(100) + (defender.dex/5) 
          #attacker_roll = attacker.roll_die(100) + (attacker.dex/5)
          self.battle(defender,attacker) 

    """

  def options(self,player):
     #player.status()
     print("MOVE: (N), (E), (S), (W) | (L)OOK")
     ###   PLAYER USER INPUT 
     user_input = player.user_input()

     if user_input == "N":
       player.pos_y += 1
     elif user_input == "E":
       player.pos_x += 1
     elif user_input == "S":
       player.pos_y -= 1
     elif user_input == "W":
       player.pos_x -= 1
     elif user_input == "L":
       print("LOOKING")
     #elif user_input == "D":
       #player.drop()

     else:
       print("INVALID CHOICE")
     return

  def main_loop(self,player):
      self.status()
      player.create()
      while True:
        self.grid(player)
        #player.status()
        #self.options(player)

game = Game()
game.main_loop(player)


#game.battle(player,orc_peon)

#orc_peon.status()
#player.status()
