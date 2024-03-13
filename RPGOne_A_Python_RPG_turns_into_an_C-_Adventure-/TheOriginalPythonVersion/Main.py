from Player import *
from Character import *
from Item import *
from Room import *
from Store import *
from Quest import *
from Map import *
from subprocess import call
from time import sleep

'''IDEAS: Make wall rooms for not going into the abyss
maybe give possible directions in the rooms if looked at?

give hints about a store
need interaction and talk with npcs
use of health potions
maybe even a game break for drinking with an alert or so 
whilst in fight-better than dying,right?
exit method?
'''

class Game:
    def __init__(self):
        self.name = "GAME"
        self.loop = True

        
    def clear(self):
        _ = call('clear')


    def status(self):
        print(self.name + " IS INSTANTIATED")
         #TODO: I need a more fancy Intro, fuck dammnit!


    def grid(self, player):
        rooms = [start_room, peon_room, gem_room, orc_room, rat_room,
         stor,wallm1m1, wall1m1, wallm10, wallm11, wallm12,
          wall12, wall03, wall0m2]
        for room in rooms:
            if room.pos_x == player.pos_x and room.pos_y == player.pos_y:
                room.status()
                if len(room.enemies) > 0:
                    while len(room.enemies) > 0:
                        for enemy in room.enemies:
                            self.battle(enemy, player)
                            if enemy.hp <= 0:
                                player.xp += enemy.xp
                                enemy.queue_free(room)
                                room.enemies.remove(enemy)
                self.options(room, player)


    def options(self, room, player):
        print("MOVE:\n| (N)ORTH\n| (E)AST\n| (S)OUTH\n| (W)EST\n|")
        print(" (L)OOK AT ME!\n| SHOW (R)OOM!\n|(M)AP?\n| ")
        print("  (I)NVENTORY?\n| (Q)UIT GAME")
        user_input = player.user_input()
        if user_input == "N":
            player.pos_y += 1
            self.grid(player)
        elif user_input == "S":
            player.pos_y -= 1
            self.grid(player)
        elif user_input == "W":
            player.pos_x -= 1
            self.grid(player)
        elif user_input == "E":
            player.pos_x += 1
            self.grid(player)
        elif user_input == "L":
            print("LOOK AT YOU!")
            player.status()
            print("---------------------------------------------------------")
            self.options(room, player)
        elif user_input == "R":
            room.status() 
            '''print(Room.status(room) maybe
             a function in rooms for locating the player
              and return the corresponding room?''' 
            self.options(room, player)
        elif user_input == "M":
            map.plan()
            self.options(room, player)
        elif user_input == "I":
            player.inventory(room)
        elif user_input == "Q":
            self.game_over()
        else:
            print("DUDE, WRONG INPUT!!!") 
            # maybe here after choose drop,pick up?
            print("---------------------------------------------------------")
            self.options(room, player)


    def battle(self, attacker, defender):


        def initiative(attacker, defender):
            # INITIATIVE PHASE
            if attacker.roll_dice(0, 100) + (attacker.dex / 5) >=
             defender.roll_dice(0, 100) + (defender.dex / 5):
                print(attacker.name + " HAS INITIATIVE")
                # ATTACKER ATTACK PHASE
                to_hit(attacker, defender)
            else:
                print(defender.name + " HAS INITIATIVE")
                # DEFENDER ATTACK PHASE
                to_hit(defender, attacker)


        def to_hit(attacker, defender):
            print(attacker.name + " IS ATTACKING " + defender.name)
            if attacker.roll_dice(0, 100) >= defender.roll_dice(0, 100):
                print(attacker.name + " HITS " + defender.name)
                defender.hp -= attacker.dmg
                print(attacker.name + " DOES " + str(attacker.dmg) + " DAMAGE")
                print(defender.name + " NOW HAS " + str(defender.hp) + " HP")
            else:
                print(attacker.name + " MISSES " + defender.name)

        # RUN BATTLE
        initiative(attacker, defender)
#TODO
    '''def random_encounter(self,player) :
        rooms = [start_room,orc_room,peon_room,rat_room]
        enemies = [orc_peon,orc_peon]
        roll = random.randint(0,100)
        if roll <= 10:
            print("TWO ORC PEONS")
            print(enemies[0].name)
            print(enemies[1].name)

            enemies[0].pos_x = player.pos_x and
             enemies[0].pos_y = player.pos_y
            enemies[1].pos_x = player.pos_x and
             enemies[1].pos_y = player.pos_y

        elif roll >= 11 and roll <= 20 :
            print("ORC PEON")
            #WIP
        elif roll >= 21 and roll <= 95 :
            print("NO ENCOUNTERS")
            #WIP
        elif roll >= 96 :
            print("TREASURE ROOM")'''
            #WIP


	#def game_over():
	#	sys.exit(1)

    def main_loop(self,player):
        self.status()
        sleep(1)
        print("WELCOME TO THE GAME!")
        player.create()
      

        while self.loop:
            self.grid(player)




if __name__== "__main__":

    game = Game()
    game.main_loop(player)
#    player = Player() #TODO Try this out



