import os 
from os import path

# 目标文件
testurl = "D:/Other/jc/FGUI_project"

# 遍历目标文件
def foreach_file (targetUrl):
    file  = os.listdir(targetUrl)
    for f in file:
        real_url = path.join(targetUrl , f)
        if path.isfile(real_url):
            if f.endswith(".xml"):
                # 只处理xml文件
                replace(real_url)
        elif path.isdir(real_url):
            foreach_file(real_url)
        else:
            print("其他情况")
            pass
# 需要替换字符
oldstr = "#000000"
# 替换字符
newstr = "#00CC00"

def replace(file_path):  
    print("file_path  = "+file_path)
    f = open(file_path,'r+')  
    all_lines = f.readlines()  
    f.seek(0)  
    f.truncate()  
    for line in all_lines: 
        if oldstr in line:
            print("发现字符 ： oldstr = " + line)
            line = line.replace(oldstr, newstr)  
        f.write(line)  
    f.close() 


foreach_file(testurl)