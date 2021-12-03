import argparse
import os
import re

# init parser
parser = argparse.ArgumentParser(
    description='Takes a user defined input and searches the command palette for appropriate commands.')
# adding argument to parser
parser.add_argument('Searchbox_input', type=str)
# building arguments in parser
args = parser.parse_args()

# unpacking argument parsed from MainWindow.xaml.cs
args.Searchbox_input = args.Searchbox_input.replace('-', ' ')

# command palette
command_palette = ["start obsidian", "start firefox", "start sublime",
                   "ping google.com"]

# function to search through the command palette
def searcher(string):

    # regex compilation
    re_pattern = re.compile(string)
    hit_list = []

    # regex search 
    for i in command_palette:
        matchObject = re_pattern.search(i)
        if matchObject:
            hit_list.append(i)
    if len(hit_list) == 0:
        hit_list.append(string)

    return hit_list


print(searcher(args.Searchbox_input), flush=True)
