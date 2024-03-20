#!/bin/bash

directory="/home/kir4oras/Documents/test/"
extension=".ref"

cd "$directory" || exit
rm *"$extension"

echo "Файлы $extension удалены."


