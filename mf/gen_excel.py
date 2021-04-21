import os
import shutil

cmd = "git rev-parse --abbrev-ref HEAD"
branch = os.open('git rev-parse --abbrev-ref HEAD').read().strip()