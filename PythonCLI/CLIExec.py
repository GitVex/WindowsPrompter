import argparse
import os
import re

parser = argparse.ArgumentParser(
    description='Takes a user defined input and searches the command palette for appropriate commands.')
parser.add_argument('Searchbox_input', type=str)
args = parser.parse_args()

args.Searchbox_input = args.Searchbox_input.replace('-', ' ')
command_palette = ["start obsidian", 
                   "ping google.com"]


def searcher(string):
    re_pattern = re.compile(string)
    hit_list = []

    for i in command_palette:
        matchObject = re_pattern.search(i)
        if matchObject:
            hit_list.append(i)

    return hit_list


print(searcher(args.Searchbox_input), flush=True)
