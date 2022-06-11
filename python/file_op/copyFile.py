
import os 
from os import path
import shutil
from telnetlib import theNULL 

src  = "C:/Users/xiaojiang\Desktop/pycopy/file1/test.txt"
src1  = "C:/Users/xiaojiang\Desktop/pycopy/test.txt"
des = "C:/Users/xiaojiang/Desktop/pycopy/file2"
rootfile = "C:/Users/xiaojiang/Desktop/pycopy"

# assert not os.path.isabs(source)
# taget = os.path.join(taget, os.path.dirname(source))

# os.makedirs(taget)

# try:
#     shutil.copy(source, taget)
# except IOError as e:
#         print("Unable to copy file. %s" % e)
# except:
#         print("Unexpected error:", sys.exc_info())

# if os.path.isfile(src):#用于判断某一对象(需提供绝对路径)是否为文件
#         shutil.copy(src, des)#shutil.copy函数放入原文件的路径文件全名  然后放入目标文件夹

# for file in os.listdir(src):
#     #遍历原文件夹中的文件
#     full_file_name = os.path.join(src, file)#把文件的完整路径得到
#     print("要被复制的全文件路径全名:",full_file_name)
#     if os.path.isfile(full_file_name):#用于判断某一对象(需提供绝对路径)是否为文件
#         shutil.copy(full_file_name, des)#shutil.copy函数放入原文件的路径文件全名  然后放入目标文件夹

# for file in os.listdir(rootfile):
#         full_file_name = os.path.join(rootfile, file)
#         print("file name = ",full_file_name)
        # if os.path.isfile(full_file_name):
                

 
def scaner_file (url, fileName):
        file  = os.listdir(url)
        for f in file:
                real_url = path.join (url , f)
                if path.isfile(real_url) and f==fileName:
                        print(f)
                        print(path.abspath(real_url))

                        # 如果是文件，则以绝度路径的方式输出
                elif path.isdir(real_url):
                #如果是目录，则是地柜调研自定义函数 scaner_file (url)进行多次
                        scaner_file(real_url)
                else:
 
                        print("其他情况")
                        pass


def update_file (url, fileurl, fileName):
        file  = os.listdir(url)
        for f in file:
                real_url = path.join (url , f)
                if path.isfile(real_url):
                        # 如果是文件，则以绝度路径的方式输出
                        print("文件的绝对路径路径 = ",path.abspath(real_url))

                        print("更新文件名称 = ",fileName)
                        print("当前文件名 = ",f)
                        if f==fileName:
                                if os.path.exists(real_url):
                                        os.remove(real_url)
                                print("当前路径 = ",url)
                                print("更新文件绝对路径 = ",fileurl)
                                if os.path.exists(fileurl):
                                        shutil.copy(fileurl, url)
                elif path.isdir(real_url):
                #如果是目录，则是地柜调研自定义函数 scaner_file (url)进行多次
                        update_file(real_url,fileurl, fileName)
                else:
 
                        print("其他情况")
                        pass

# scaner_file(rootfile)
update_file(rootfile, src1, "test.txt")
