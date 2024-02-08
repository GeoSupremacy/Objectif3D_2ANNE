import os
'''
result = int(input("Enter : "))
closeResult = result*0.5
verycloseResult = result*0.3
loop =True

os.system("cls")

while loop:
    guess = int(input("Guess : "))
   
    if guess == result :
        loop =False
    elif guess > result:
        if guess <= result+verycloseResult:
            print("you burn")
        elif guess <= result+closeResult:
            print("you warm up")
        else:
            print("So cold")
    elif  guess < result:
        if guess >= verycloseResult:
            print("you burn")
        elif guess >= closeResult:
            print("you warm up") 
        else:
            print("So cold")  
    
 

print("You win")
'''
#############correction#############
#############VAR#############
secret_prompt ="Enter a secret number: "
stargame_prompt ="It's time to guess a number !"
guess_prompt ="Enter a number : "
win_guess_prompt ="Succes! It was :"
wrong_low_prompt ="Wrong, too low, trty again !"
win_hight_prompt ="Wrong, too high, trty again !"
#############

number_input = input(secret_prompt)

while (number_input.isdigit() == False):
    number_input = input(secret_prompt)

os.system("cls")

print(stargame_prompt)

game_is_won =False

while(game_is_won == False):
    guess = input(guess_prompt)
    game_is_won = guess == number_input
    if game_is_won:
        print(win_guess_prompt, number_input)
    elif guess < number_input:
            print(wrong_low_prompt)
    elif  guess > number_input:
         print(win_hight_prompt)

#############    