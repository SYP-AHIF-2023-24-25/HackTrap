#!/bin/bash

echo -e "\e[1;31m[0m"

# Function to generate a random character
random_char() {
    characters="!@#$%^&*()_+-={}[]|\:;'<>,.?/~\`"
    echo -n "${characters:RANDOM%${#characters}:1}"
}

# Function to print the skull
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

while true; do
    for ((i = 1; i <= $(tput lines); i++)); do
        for ((j = 1; j <= $(tput cols); j++)); do
            if [ $i -gt 5 ] && [ $i -lt 12 ] && [ $j -gt 20 ] && [ $j -lt 60 ]; then
                # Print the skull
                print_skull
                j=$((j + 36))  # Move to the next section after the skull
            else
                # Print a random character
                echo -n "$(random_char)"
            fi
        done
        echo
    done
    sleep 0.1
    clear
done
