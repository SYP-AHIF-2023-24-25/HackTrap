#!/bin/bash

# Function to generate a random character
random_char() {
    characters="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-={}[]|\:;'<>,.?/~\` "
    echo -n "${characters:RANDOM%${#characters}:1}"
}

# Function to print the "H^CKING D€€PSP^C€..." message in bright red
print_hacking_message() {
    echo -e "\e[1;91mH^CKING D€€PSP^C€...\e[0m"
}

# Function to print the "INF€CT€D TH€ D€€€€€PSPAC€€€" message in bright cyan
print_infected_message() {
    echo -e "\e[1;91mINF€CT€D TH€ D€€€€€PSPAC€€€\e[0m"
}

download_bar() {
    local width=$1
    local progress=$2
    local bar=""
    for ((i = 0; i < width; i++)); do
        if [ $i -lt $progress ]; then
            bar+="#"
        else
            bar+=" "
        fi
    done
    echo -e "\e[1;34m[$bar]\e[0m"
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
            if [ $i -gt 5 ] && [ $i -lt 12 ] && [ $j -gt 20 ] && [ $j -lt 30 ]; then
                # Print the "H^CKING D€€PSPAC€..." message in bright red
                print_hacking_message
                j=$((j + 10))  # Move to the next section after the "H^CKING D€€PSPAC€..." message
            else
                # Print a random character in green
                echo -e -n "\e[1;32m$(random_char)\e[0m"
            fi
        done
        echo
    done


    if [ $iteration -eq $total_iterations ]; then
        download_bar 20 20  # Change 20 to the desired width and progress
        # Display the "INF€CT€D TH€ D€€€€€PSPAC€€€" message in bright cyan at the end
        print_infected_message
    else
        # Sleep duration between iterations
        sleep 0.5  # Adjust the sleep duration as needed (e.g., 0.5 seconds)
        clear
    fi
done
