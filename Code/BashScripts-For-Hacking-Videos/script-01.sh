#!/bin/bash

# Function to generate a random character
random_char() {
    characters="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-={}[]|\:;'<>,.?/~\` "
    echo -n "${characters:RANDOM%${#characters}:1}"
}

# Function to print a skull
print_skull() {
    echo "                    #..###############################..#        "
    echo "⠀⠀⠀⠀             /⠀⠀⠀⠀                                  \       "    
    echo "               .-~                                        ~-.⠀⠀ "
    echo "              /                                              \⠀⠀"
    echo "            ;;                                                ;;⠀⠀"
    echo "          #/   ;            .                 .            ;    \#⠀"
    echo "          ;    ;                                           ;     ;⠀⠀"
    echo "          ;             ___________     ___________              ;⠀⠀"
    echo "        ;           /~``            \|/             ´´~\          ;⠀⠀"
    echo "        ;           /~``             |              ´´~\          ;⠀⠀"
    echo "        ;           \               } {                /          ;⠀⠀"
    echo "        ;            \             /    \             /          ;⠀⠀"
    echo "      ; ; ~           <_~~~~~~~~;;;       ;;;~~~~~~~~_,>       ~ ;⠀;" 
    echo "       ;                            >  <                          ;⠀⠀"
    echo "       ;                     I     /    \       I                 ;⠀⠀"
    echo "       ,           ##########################################     ,⠀⠀"
    echo "       ;           ############/                \############     ;⠀⠀"
    echo "        .          ######/            /   \           \######    .⠀⠀"
    echo "         \                I                                    /⠀⠀"
    echo "           \___.                   \ / \ / \ /            .___/⠀⠀"
    echo "            UU | \                                     /⠀| UU"
    echo "               |       IT~\______________________/~TI    |⠀"
    echo "               |       I ' IIII_I_I_I_I_I_I_I_IIII 'I    |⠀⠀"
    echo "                 \      \      III_I_I_I_I_III    /    /⠀⠀"
    echo "                    \      ~~~~~~~~~~~~~~~~~~~~~~   /⠀⠀"
    echo "                       \.                       ./⠀⠀"
    echo "                         #                     #⠀⠀"
    echo "                         U~~~~~~~~~~~~~~~~~~~~~~U    ⠀⠀"
}

# Function to simulate a dramatic download bar
download_bar() {
    local width=$1
    local progress=$2
    local bar=""
    for ((i = 0; i < width; i++)); do
        if [ $i -lt $progress ]; then
            bar+="Encrypting data..."
        else
            bar+=" "
        fi
    done
    echo -e "\e[1;32m$bar\e[0m"
}

# Function to print random characters with spaces
print_random_characters() {
    local count=$1
    for ((i = 0; i < count; i++)); do
        echo -e -n "\e[1;32m$(random_char)\e[0m"
        sleep 0.005  # Adjusted for a more rapid and chaotic appearance
    done
}

# Function to get a random position within the terminal
get_random_position() {
    local lines=$(tput lines)
    local cols=$(tput cols)
    local line=$((RANDOM % lines))
    local col=$((RANDOM % cols))
    echo -e "\e[${line};${col}H"
}


# Clear the screen
clear

# Trap for Ctrl+C
trap ctrl_c INT

# Ctrl+C handler
ctrl_c() {
    echo "Interrupted. Cleaning up..."
    tput cnorm  # restore cursor
    exit 0
}

# Hide the cursor
tput civis

# Print a skull
print_skull

# Print random characters with spaces
print_random_characters 200

# Print message
echo -e "\e[1;91m"
echo "H^CKING D€€PSP^C€..."
echo -e "\e[0m"

# Print random characters with spaces
print_random_characters 200

# Simulate a dramatic download bar with random positions and characters
for ((progress = 0; progress <= 100; progress+=5)); do
    position=$(get_random_position)
    echo -n "$position"
    download_bar 20 $progress  # Adjust the width of the download bar
    print_random_characters 25
    sleep 0.01  # Adjusted for a more rapid fluttering effect
done

# Print random characters with spaces
print_random_characters 200

# Print message
echo -e "\e[1;91m"
echo "D€€PSPAC€ HAS B€€N HACK€D"""
echo -e "\e[0m"

sleep 0.1 # Adjust the delay as needed

# Print random characters with spaces
print_random_characters 200

# Restore the cursor
tput cnorm
