#!/bin/bash

echo -n -e "HACK DeepSpace (142.250.180.206) 56(84) bytes of data."
echo 

counter_seq=0

for ((i=0; i<37; i++)); do
    ((counter_seq++))
    echo -n -e "\e[1;32m.64 bytes from bud02s33-in-f14.1e100.net (142.250.180.206): icmp_seq=${counter_seq} ttl=111 time=41.9 ms\e[0m"
    echo
    sleep 0.3
done

echo  # Neue Zeile für eine bessere Formatierung
echo -e "#####################################################################################################"

echo -e "GOT SIGNALS SUCCESFULLY..."
sleep 0.7
echo -e "#####################################################################################################"
sleep 0.3
echo -e "\e[1;31mHACKING DEEPSPACE NOW...\e[0m"
sleep 2.0
