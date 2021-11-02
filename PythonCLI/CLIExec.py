import os
import sys

user_input = sys.argv[0]
command_palette = ["start obisidan"]
if user_input in command_palette:
    os.system(str(user_input))
