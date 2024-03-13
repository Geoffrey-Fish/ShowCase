from Player import *
from Item import *
from Character import *
from subprocess import call
from Main import *
'''I need kind of a dialogue option to open this store here...'''

class Store:
    def __init__(self, name, desc, pos_x, pos_y, npcs, items, weapons, armors, gp):
        self.name = name 
        self.desc = desc
        self.pos_x = pos_x
        self.pos_y = pos_y
        self.npcs = npcs
        self.items = items
        self.weapons = weapons
        self.armors = armors
        self.gp = gp 


    def clear(self):
        _ = call('clear')


    def status(self, player):
        print(self.name + " IS INSTANTIATED")
        self.menu(player)


    


    def menu(self,player):
        print("STORE MENU")
        print("(B)UY | (S)ELL | (L)EAVE")
        user_input = player.user_input()

        if user_input == "B":
            print("BUYING")
            print("BUY (I)TEM | (W)EAPON | (A)RMOR ?")
            user_input = player.user_input()

            if user_input == "I":
                print("BUYING ITEMS")
                self.buy(player, self.items, player.items)
            elif user_input == "W":
                print("BUYING WEAPONS")
                self.buy(player, self.weapons, player.weapons)
            elif user_input == "A":
                print("BUYING ARMOR")
                self.buy(player, self.armors, player.armors)         

        elif user_input == "S":
            print("SELLING")
            print("SELL (I)TEM | (W)EAPON | (A)RMOR ?")
            user_input = player.user_input()
        
            if user_input == "I":
                print("SELLING ITEMS")
                self.sell(player, self.items, player.items)
            elif user_input == "W":
                print("SELLING WEAPONS")
                self.sell(player, self.weapons, player.weapons)
            elif user_input == "A":
                print("SELLING ARMOR")
                self.sell(player, self.armors, player.armors)
        
        elif user_input == "L":
            print(player.name + " IS LEAVING")
            game.options(room, player)

#TODO Here is a massive overhaul to do, this is not nice as it is. there are better options!
    def buy(self, player, store_obj_list, player_obj_list):
        print(player.name + " IS BUYING")
        i = 0
        for obj in store_obj_list:
            print(str(i) + " " + obj.name + " " + str(obj.gp_value) + " GP")
            i +=1
        print("WICH NUMBER DO YOU CHOOSE FROM 0 - " + str(len(store_obj_list)))
        user_input = player.user_input()
        try: #fuckery begins here!
            if user_input == "0":
                if player.gp >= store_obj_list[0].gp_value:
                    print("BUYING " + store_obj_list[0].name)
                    player.gp -= store_obj_list[0].gp_value
                    player_obj_list.append(store_obj_list[0])
                    store_obj_list.remove(store_obj_list[0])
                else:
                    print("NOT ENOUGH COINZ YOU HAS!")
        except:
            print("NO ITEM HERE")

        try:
            if user_input == "1":
                if player.gp >= store_obj_list[1].gp_value:
                    print("BUYING " + store_obj_list[1].name)
                    player.gp -= store_obj_list[1].gp_value
                    player_obj_list.append(store_obj_list[1])
                    store_obj_list.remove(store_obj_list[1])
                else:
                    print("NOT ENOUGH COINZ YOU HAS!")
        except:
            print("NO ITEM HERE")

        try:
            if user_input == "2":
                if player.gp >= store_obj_list[2].gp_value:
                    print("BUYING " + store_obj_list[2].name)
                    player.gp -= store_obj_list[2].gp_value
                    player_obj_list.append(store_obj_list[2])
                    store_obj_list.remove(store_obj_list[2])
                else:
                    print("NOT ENOUGH COINZ YOU HAS!")
        except:
            print("NO ITEM HERE")

    def sell(self, player, store_obj_list, player_obj_list):
        if player_obj_list == []:
            print("YOUR BAG SEEMS EMPTY,MAN!")
            self.menu(player)
        if self.gp == 0:
            print("I`M BROKE, BUDDY,SORRY")
            self.menu(player)
        print(player.name + " IS SELLING")

        i = 0
        for obj in player_obj_list:
            print(str(i) + " " + obj.name + " " + str(obj.gp_value) + " GP")
            i += 1
        print("WHAT YOU WANNA SELL FROM 0 TO " + str(len(player_obj_list)))

        user_input = player.user_input()

        try:
            if user_input == "0":
                print("SELLING " + player_obj_list[0].name)
                print(player.name + " GETS " + str(player_obj_list[0].gp_value* .70) + " GP")
                player.gp += player_obj_list[0].gp_value * .7
                store_obj_list.append(player_obj_list[0])
                player_obj_list.remove(player_obj_list[0])
        except:
            print("NO ITEM HERE")

        try:
            if user_input == "1":
                print("SELLING " + player_obj_list[1].name)
                print(player.name + " GETS " + str(player_obj_list[1].gp_value* .70) + " GP")
                player.gp += player_obj_list[1].gp_value * .7
                store_obj_list.append(player_obj_list[1])
                player_obj_list.remove(player_obj_list[1])
        except:
            print("NO ITEM HERE")

        try:
            if user_input == "2":
                print("SELLING " + player_obj_list[2].name)
                print(player.name + " GETS " + str(player_obj_list[2].gp_value* .70) + " GP")
                player.gp += player_obj_list[2].gp_value * .7
                store_obj_list.append(player_obj_list[2])
                player_obj_list.remove(player_obj_list[2])
        except:
            print("NO ITEM HERE")


 # name, desc, pos_x, pos_y, items, weapons, armors, gp
store = Store("Cramers", "ALL THE STUFF U WANT", 1, 1, [store_clerk],[gem, gem, gem], [stick], [towel], 500)

