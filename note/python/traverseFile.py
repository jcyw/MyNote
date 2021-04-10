##########查找并输出重名文件
import os, re

arrFiles = []
arrPath = []

# 遍历文件夹
def walkFile(file):
    for root, dirs, files in os.walk(file):

        # root 表示当前正在访问的文件夹路径
        # dirs 表示该文件夹下的子目录名list
        # files 表示该文件夹下的文件list

        # 遍历文件 f->文件名
        for f in files:
            # print(os.path.join(root, f))
            # 查找后缀名为.txt的文件
            # if f.endswith('.txt'):
            #     print(f)

            # if re.match(r'^.*?\.(txt)+$',f):
            #     print(f)  <==> print(os.path.basename)[文件名全称包括后缀]
            arrFiles.append(f)
            arrPath.append(os.path.join(root, f))

        # 遍历所有的文件夹
        # for d in dirs:
        #     # print(os.path.join(root, d))
        #     arrPath.append(d)

##输出重名文件
def findSameName(fileList):
    tempArr = fileList.copy()
    for k in range(len(tempArr)):
        for k1 in range(len(fileList)):
            if tempArr[k] == fileList[k1] and k < k1:
                print("\n重名文件名============>",tempArr[k])
                printSmaeNamePath(tempArr[k])

##输出重名路径
def printSmaeNamePath(fileName):
    print("<=================重名路径===================>")
    for v in arrPath:
        if fileName in v:
            print(v)


##输出数组
def printArr(arr):
    for v in arr:
        print(v)

def main():
    walkFile("d:/test/")
    #########
    # print(arrFiles)
    # print("----------------------------------")
    findSameName[arrFiles]


if __name__ == '__main__':
    main()


# os.path.abspath(path) #返回绝对路径（包含文件名的全路径）

# os.path.basename(path) —— 去掉目录路径获取带后缀的文件名

# os.path.dirname(path) —— 去掉文件名获取目录

# os.path.split(path) —— 将全路径分解为(文件夹,文件名)的元组

# os.path.splitext(path)  #分割全路径，返回路径名和文件扩展名的元组

# os.path.join()  #路径拼接

# os.path.isdir()  #用于判断对象是否为一个全路径

# os.path.isfile(path)  #判断文件是否存在？如果path是一个存在的文件，返回True。否则返回False。

# os.path.isdir(path)  #判断目录是否存在？如果path是一个存在的目录，则返回True。否则返回False。