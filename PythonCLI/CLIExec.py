import argparse
import os

parser = argparse.ArgumentParser(
    description='Takes a user defined input and searches the command palette for appropriate commands.')
parser.add_argument('Searchbox_input', type=str)
args = parser.parse_args()

args.Searchbox_input = args.Searchbox_input.replace('-', ' ')
command_palette = ["start obsidian", 
                   "ping google.com"]


def searcher(string):
    if args.Searchbox_input in command_palette:
        os.system(args.Searchbox_input)

    return args.Searchbox_input


print(searcher(args.Searchbox_input), flush=True)
